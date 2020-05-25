using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlidingState : State
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField, Range(1f, 5f)]
    private float _slidingDrag = 3;

    protected override void Enter()
    {
        _rigidbody.drag = _slidingDrag;
    }

    protected override void Exit()
    {
        _rigidbody.drag = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeState("Jump");
    }
}
