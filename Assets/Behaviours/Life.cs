using System.Collections;
using UnityEngine;
using Values;

[RequireComponent(typeof(StateMachine))]
public class Life : MonoBehaviour, IDamageable
{
    [SerializeField]
    private StateMachine _stateMachine;
    [SerializeField]
    private AnimationFlag _immunityStatus;
    [SerializeField]
    private float _immunityDuration = 3f;

    public void Damage ()
    {
        if(!_immunityStatus.Active)
        {
            _stateMachine.Change("Die");
        }
    }

    public void GrantImmunity()
    {
        StartCoroutine(Immunity());
    }

    private IEnumerator Immunity ()
    {
        _immunityStatus.Active = true;
        yield return new WaitForSeconds(_immunityDuration);
        _immunityStatus.Active = false;
    }
}
