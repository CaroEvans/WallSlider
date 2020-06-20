using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Values;

public class FruitShield : MonoBehaviour, IDamageable
{
    [Serializable]
    class FruitEvent : UnityEvent<int, int> { };

    [SerializeField]
    private AnimationFlag _shieldStatus;
    [SerializeField]
    private string _fruitPrefsKey;
    [SerializeField]
    private int _max = 10;
    [SerializeField]
    private Life _life;
    [SerializeField]
    private float _drainRate;
    [SerializeField]
    private UnityEvent _onShieldBroken, _onShieldActivated, _onShieldDeactivated;
    [SerializeField]
    private FruitEvent _onStart, _onChanged;

    private int _fruitCount
    {
        get { return PlayerPrefs.GetInt(_fruitPrefsKey, 0); }
        set {
            PlayerPrefs.SetInt(_fruitPrefsKey, Mathf.Clamp(value, 0, _max));
            _onChanged.Invoke(_fruitCount, _max);
        }
    }

    private bool _isActive
    {
        get { return _shieldStatus.Active; }
        set
        {
            _shieldStatus.Active = value;
            if (value)
                _onShieldActivated.Invoke();
            else
                _onShieldDeactivated.Invoke();
        }
    }

    public void Start()
    {
        _onStart.Invoke(_fruitCount, _max);
    }

    public void Damage()
    {
        if (_shieldStatus.Active)
        {
            StopAllCoroutines();
            _fruitCount = 0;
            _life.GrantImmunity();
            _isActive = false;
            _onShieldBroken.Invoke();
        } else
        {
            _life.Damage();
        }
    }

    public void AddFruit(Color color)
    {
        _fruitCount = _fruitCount + 1;
        if (!_shieldStatus.Active && _fruitCount == _max)
            StartCoroutine(ActivateShield());
    }

    public IEnumerator ActivateShield ()
    {
        _isActive = true;
        var delay = new WaitForSeconds(_drainRate);
        while(_fruitCount > 0)
        {
            yield return delay;
            _fruitCount -= 1;
        }
        _isActive = false;
    }
}