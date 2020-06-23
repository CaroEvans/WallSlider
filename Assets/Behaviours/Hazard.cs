using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Hazard : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onHit;

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IDamageable>()?.Damage();
        _onHit.Invoke();
    }
}
