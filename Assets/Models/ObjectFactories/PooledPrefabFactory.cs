using System.Collections.Generic;
using UnityEngine;

namespace ObjectFactories
{
    public class PooledPrefabFactory : MonoBehaviour, IObjectFactory
    {
        [SerializeField]
        private PooledBehaviour _prefab;
        [SerializeField, Range(1, 50)]
        private int _capacity;

        private Queue<PooledBehaviour> _pool = new Queue<PooledBehaviour>();

        public GameObject Create(Vector3 position)
        {
            PooledBehaviour obj = _pool.Count < _capacity ? CreateNew() : UseExisting();
            obj.Enter();
            obj.transform.position = position;
            _pool.Enqueue(obj);
            return obj.gameObject;
        }

        private PooledBehaviour CreateNew()
        {
            return Instantiate(_prefab, transform);
        }

        private PooledBehaviour UseExisting()
        {
            return _pool.Dequeue();
        }
    }
}

