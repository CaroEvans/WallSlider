using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Views;

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
    [SerializeField]
    private Distance _distance;
    [SerializeField]
    private HighScore _highScore;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private TransitionScreen _screen;
    [SerializeField]
    private UnityEvent _onDied;

    protected override void Enter()
    {
        _animator.SetTrigger("Die");
        _onDied.Invoke();
        gameObject.layer = 8;
        _distance.CheckBest(_highScore);
        StartCoroutine(StopAfterFalling(transform.position.y));
        StartCoroutine(WaitForRestart());
        _distance.enabled = false;
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
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.anyKeyDown);
        _screen.Reverse(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
}
