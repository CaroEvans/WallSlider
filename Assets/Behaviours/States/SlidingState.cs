using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class SlidingState : State
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField, Range(1f, 5f)]
    private float _slidingDrag = 3;
    [SerializeField]
    private ParticleSystem _slideParticles;
    [SerializeField]
    private UnityEvent _onLanded;

    protected override void Enter()
    {
        _slideParticles.transform.localPosition = new Vector2(0.5f * Mathf.Sign(transform.position.x - 4), 0.5f);
        _slideParticles.Play();
        _rigidbody.drag = _slidingDrag;
        _onLanded.Invoke();
    }

    protected override void Exit()
    {
        _slideParticles.Stop();
        _rigidbody.drag = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeState("Jump");
    }
}
