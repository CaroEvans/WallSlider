using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class State : MonoBehaviour
{
    [SerializeField]
    private StateMachine _stateMachine;

    protected virtual void Enter(StateMachine stateMachine) { }
    protected virtual void Exit(StateMachine stateMachine) { }
    protected virtual void Run(StateMachine stateMachine) { }

    public void Reset()
    {
        _stateMachine = GetComponent<StateMachine>();
    }

    public void OnEnable()
    {
        Enter(_stateMachine);
    }

    public void Update()
    {
        Run(_stateMachine);
    }

    public void OnDisable()
    {
        Exit(_stateMachine);
    }
}