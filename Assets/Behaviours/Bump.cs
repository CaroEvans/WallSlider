using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bump : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _target;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
            _target.AddForce(Vector3.up * 50, ForceMode.Impulse);
    }
}
