using UnityEngine;

public class StopState : State
{
    protected override void Enter()
    {
        Debug.Log("Start Red");
    }

    protected override void Exit()
    {
        Debug.Log("Exit Red");
    }

    public void Update()
    {
        Debug.Log("Update Red");
        if (Input.GetKeyUp(KeyCode.Space))
            ChangeState("Toggle");
    }
}
