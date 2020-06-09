using UnityEngine;
using UnityEngine.Events;

public class Reward : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onCollected = new UnityEvent();

    public void OnTriggerEnter(Collider other)
    {
        _onCollected.Invoke();
        transform.parent.gameObject.SetActive(false);
    }
}
