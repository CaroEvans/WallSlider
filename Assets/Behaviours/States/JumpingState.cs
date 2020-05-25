using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpingState : State
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private Vector2 _jumpForce;
    [SerializeField]
    private float _postJumpDelay = 0.2f;

    protected override void Enter()
    {
        var jumpForce = new Vector2(_jumpForce.x * Mathf.Sign(4 - transform.position.x), _jumpForce.y);
        _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        StartCoroutine(WaitForRest());
    }

    private bool IsAtRest()
    {
        return Mathf.Approximately(Mathf.Abs(_rigidbody.velocity.x), 0);
    }

    private IEnumerator WaitForRest()
    {
        yield return new WaitForSeconds(_postJumpDelay);
        yield return new WaitUntil(IsAtRest);
        ChangeState("Slide");
    }
}
