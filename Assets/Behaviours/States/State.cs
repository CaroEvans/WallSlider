using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class State : MonoBehaviour
{
    [SerializeField]
    private StateMachine _stateMachine;

    protected virtual void Enter() { }

    protected virtual void Exit() { }

    protected virtual void ChangeState(string action)
    {
        _stateMachine.Change(action);
    }

    public void Reset()
    {
        _stateMachine = GetComponent<StateMachine>();
    }

    public void OnEnable()
    {
        Enter();
    }

    public void OnDisable()
    {
        Exit();
    }
}