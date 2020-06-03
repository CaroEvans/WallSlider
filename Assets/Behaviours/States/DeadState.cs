using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class DeadState : State
{
    [SerializeField]
    private CameraFocus _cameraFocus;
    [SerializeField]
    private Rigidbody _rigidBody;
    [SerializeField]
    private Collider _collider;
    [SerializeField, Range(0, 100f)]
    private float _fallDistance;

    protected override void Enter()
    {
        StartCoroutine(StopAfterFalling(transform.position.y));
        _cameraFocus.Detach();
        _cameraFocus.Shake();
    }

    private IEnumerator StopAfterFalling (float y)
    {
        _collider.enabled = false;
        yield return new WaitUntil(() => transform.position.y < y - _fallDistance);
        _rigidBody.useGravity = false;
    }

}
