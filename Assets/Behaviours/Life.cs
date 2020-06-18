using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class Life : MonoBehaviour
{
    [SerializeField]
    private StateMachine _stateMachine;
    [SerializeField]
    private bool _protected = true;

    public void Damage ()
    {
        if(!_protected)
            _stateMachine.Change("Die");
    }
}
