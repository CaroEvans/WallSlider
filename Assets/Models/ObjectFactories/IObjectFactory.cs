using UnityEngine;

namespace ObjectFactories
{
    public interface IObjectFactory
    {
        GameObject Create(Vector3 position);
    }
}