using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    public virtual GameObject Create(Vector3 position)
    {
        return Instantiate(_prefab, position, transform.rotation);
    }

    public virtual void DisposeOf(GameObject obj)
    {
        Destroy(obj);
    }
}
