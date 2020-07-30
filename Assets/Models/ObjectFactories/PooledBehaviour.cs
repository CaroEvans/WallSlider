using UnityEngine;
using UnityEngine.Events;

namespace ObjectFactories
{
    public class PooledBehaviour : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onEntered;

        public void Enter()
        {
            _onEntered.Invoke();
        }
    }
}
