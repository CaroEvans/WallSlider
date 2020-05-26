using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpingState : State
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private Vector2 _jumpStrength, _fallStrength;
    [SerializeField]
    private float _postJumpDelay, _wallTouchPadding = 0.5f;
    [SerializeField]
    private AnimationCurve _fallCurve;

    protected override void Enter()
    {
        float xDirection = Mathf.Sign(4 - transform.position.x);
        _rigidbody.AddForce(new Vector2(_jumpStrength.x * xDirection, _jumpStrength.y), ForceMode.VelocityChange);
        StartCoroutine(ApplyJumpForce(Time.time, xDirection));
    }

    private IEnumerator ApplyJumpForce (float startTime, float xDirection)
    {
        float timer = 0;
        int layerMask = LayerMask.GetMask("Default");
        while (!Physics.Raycast(transform.position, Vector3.right * xDirection, _wallTouchPadding, layerMask, QueryTriggerInteraction.Ignore))
        {
            float fallX = xDirection * _fallStrength.x;
            float fallY = -_fallCurve.Evaluate(timer) * _fallStrength.y;
            _rigidbody.AddForce(new Vector2(fallX, fallY) * Time.deltaTime);
            yield return null;
            timer = Time.time - startTime;
        }
        _rigidbody.velocity = Vector3.up * _rigidbody.velocity.y;
        ChangeState("Slide");
    }
}
