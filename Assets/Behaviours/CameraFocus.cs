using System.Collections;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _target;
    [SerializeField, Range(0, 20.0f)]
    private float _moveSpeed, _limit, _velocityScale, _velocityAcceleration;
    [SerializeField]
    private AnimationCurve _accelationCurve;
    [SerializeField]
    private float _anchorX = 4;

    private float _velocity = 0;

    public void Start ()
    {
        StartCoroutine(FollowTarget());
    }

    public void Detach ()
    {
        StopAllCoroutines();
        transform.SetParent(null);
        Vector3 position = transform.position;
        position.x = 4;
        transform.position = position;
    }

    private IEnumerator FollowTarget ()
    {
        while (true)
        {
            float accel = _accelationCurve.Evaluate(Mathf.Abs(_velocity));
            _velocity = Mathf.MoveTowards(_velocity, _target.velocity.y, Time.deltaTime * _velocityAcceleration * Mathf.Max(accel, 0));
            float clampedVelocity = Mathf.Clamp(_velocity, -_limit, _limit) * _velocityScale;
            Vector3 targetPos = Vector2.MoveTowards(transform.localPosition, Vector2.up * clampedVelocity, Time.deltaTime * _moveSpeed);
            targetPos.x = _anchorX - _target.transform.position.x;
            targetPos.z = transform.localPosition.z;
            transform.localPosition = targetPos;
            yield return null;
        }
    }
}
