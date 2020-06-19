using System.Collections;
using UnityEngine;
using Values;

[RequireComponent(typeof(StateMachine))]
public class Life : MonoBehaviour
{
    [SerializeField]
    private StateMachine _stateMachine;
    [SerializeField]
    private AnimationFlag _immunityStatus, _shieldStatus;
    [SerializeField]
    private float _immunityDuration = 3f;
    [SerializeField]
    private ParticleSystem _shieldDropEffect;

    public void Damage ()
    {
        if(!_immunityStatus.Active)
        {
            if (_shieldStatus.Active)
            {
                StartCoroutine(Immunity());
                _shieldStatus.Active = false;
                _shieldDropEffect.Play();
            } else {
                _stateMachine.Change("Die");
            }
        }
    }


    private IEnumerator Immunity ()
    {
        _immunityStatus.Active = true;
        yield return new WaitForSeconds(_immunityDuration);
        _immunityStatus.Active = false;
    }
}
