using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ActionTrigger : MonoBehaviour
{
    [SerializeField]
    private string _action;

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<StateMachine>()?.Change(_action);
    }
}
