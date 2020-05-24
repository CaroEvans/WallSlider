using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _target;
    [SerializeField, Range(0, 20.0f)]
    private float _moveSpeed, _limit, _velocityScale, _velocityAcceleration;
    [SerializeField]
    private AnimationCurve _accelationCurve;

    private float _velocity = 0;

    void Update()
    {
        float accel = _accelationCurve.Evaluate(Mathf.Abs(_velocity));
        _velocity = Mathf.MoveTowards(_velocity, _target.velocity.y, Time.deltaTime * _velocityAcceleration * Mathf.Max(accel, 0));
        float clampedVelocity = Mathf.Clamp(_velocity, -_limit, _limit) * _velocityScale;
        Vector3 targetPos = Vector2.MoveTowards(transform.localPosition, Vector2.up * clampedVelocity, Time.deltaTime * _moveSpeed);
        targetPos.z = transform.localPosition.z;
        transform.localPosition = targetPos;
    }
}
