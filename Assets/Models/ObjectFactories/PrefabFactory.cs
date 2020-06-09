using ObjectFactories;
using UnityEngine;

public class PrefabFactory : MonoBehaviour, IObjectFactory
{
    [SerializeField]
    private GameObject _prefab;

    public virtual GameObject Create(Vector3 position)
    {
        return Instantiate(_prefab, position, transform.rotation, transform);
    }

    public virtual void DisposeOf(GameObject obj)
    {
        Destroy(obj);
    }
}
