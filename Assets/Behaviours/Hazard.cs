using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Hazard : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Life>()?.Damage();
    }
}
