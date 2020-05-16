using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _target;
    [SerializeField]
    private float _moveSpeed, _limit;
    [SerializeField]
    private AnimationCurve _accelationCurve;

    void Update()
    {
        Vector2 targetVelocity = _target.velocity;
        targetVelocity.y = Mathf.Clamp(targetVelocity.y, -_limit, _limit);
        float time = Mathf.InverseLerp(0, targetVelocity.y, transform.localPosition.y);
        Vector3 targetPos = Vector2.MoveTowards(transform.localPosition, targetVelocity, Time.deltaTime * _moveSpeed * _accelationCurve.Evaluate(time));
        targetPos.z = transform.localPosition.z;
        transform.localPosition = targetPos;
    }
}
