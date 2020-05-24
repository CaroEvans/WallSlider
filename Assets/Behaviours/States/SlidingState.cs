using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlidingState : State
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private Vector2 _jumpForce;

    public void Update()
    {
        // TODO: Refactor actual jumping behaviour into a jumping state.
        // Sliding simply waits for input and then does a Jump action to change states.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var jumpForce = new Vector2(_jumpForce.x * Mathf.Sign(4 - transform.position.x), _jumpForce.y);
            _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    // TODO: Refactor so the Enter\Exit methods are used instead.
    public void OnCollisionEnter(Collision collision)
    {
        _rigidbody.drag = 3;
    }

    public void OnCollisionExit(Collision collision)
    {
        _rigidbody.drag = 1;
    }
}
