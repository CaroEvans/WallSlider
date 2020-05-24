using UnityEngine;

public class GoState : State
{
    protected override void Enter()
    {
        Debug.Log("Start Green");
    }

    public void Update()
    {
        Debug.Log("Update Green");
        if (Input.GetKeyUp(KeyCode.Space))
            ChangeState("Toggle");
    }

    protected override void Exit()
    {
        Debug.Log("Exit Green");
    }
}
