using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private AnimationCurve _xForce, _yForce;
    [SerializeField]
    private float _forceScale, _torqueScale;
    [SerializeField, Range(0, 100f)]
    private float _fallDistance;
    [SerializeField]
    private PhysicMaterial _deadMaterial;
    [SerializeField]
    private ParticleSystem _deathParticles;

    protected override void Enter()
    {
        StartCoroutine(StopAfterFalling(transform.position.y));
        StartCoroutine(WaitForRestart());
        _cameraFocus.Detach();
        Vector2 randomForce = Random.insideUnitCircle;
        Vector2 forceFromCurves = new Vector2(_xForce.Evaluate(randomForce.x), _yForce.Evaluate(randomForce.y));
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
        _collider.material = _deadMaterial;
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(forceFromCurves * _forceScale, ForceMode.Impulse);
        _rigidBody.AddTorque(Random.insideUnitSphere * _torqueScale, ForceMode.Impulse);
        _deathParticles.Play();
    }

    private IEnumerator StopAfterFalling (float y)
    {
        yield return new WaitUntil(() => transform.position.y < y - _fallDistance);
        _rigidBody.useGravity = false;
    }

    private IEnumerator WaitForRestart ()
    {
        yield return new WaitUntil(() => Input.anyKeyDown);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
