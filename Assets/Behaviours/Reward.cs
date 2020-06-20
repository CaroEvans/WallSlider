using UnityEngine;
using UnityEngine.Events;

public class Reward : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onCollected = new UnityEvent();
    [SerializeField]
    private LayerMask _mask;
    [SerializeField]
    private Color _color;

    public void OnTriggerEnter(Collider other)
    {
        if (_mask == (_mask | (1 << other.gameObject.layer)))
        {
            _onCollected.Invoke();
            other.GetComponent<FruitShield>()?.AddFruit(_color);
        }
    }
}
