using UnityEngine;

public class GoState : State
{
    protected override void Enter(StateMachine stateMachine)
    {
        Debug.Log("Start Green");
    }

    protected override void Run(StateMachine stateMachine)
    {
        Debug.Log("Update Green");
        if (Input.GetKeyUp(KeyCode.Space))
            stateMachine.Change("Toggle");
    }

    protected override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Exit Green");
    }
}
