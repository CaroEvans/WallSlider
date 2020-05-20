using UnityEngine;

public class StopState : State
{
    protected override void Enter(StateMachine stateMachine)
    {
        Debug.Log("Start Red");
    }

    protected override void Run(StateMachine stateMachine)
    {
        Debug.Log("Update Red");
        if (Input.GetKeyUp(KeyCode.Space))
            stateMachine.Change("Toggle");
    }

    protected override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Exit Red");
    }
}
