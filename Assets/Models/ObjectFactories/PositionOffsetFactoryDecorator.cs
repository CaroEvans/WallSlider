using UnityEngine;

namespace ObjectFactories
{
    public class PositionOffsetFactoryDecorator : IObjectFactory
    {
        private readonly IObjectFactory _factory;
        private readonly Vector3 _offset;

        public PositionOffsetFactoryDecorator(IObjectFactory factory, Vector3 offset)
        {
            _factory = factory;
            _offset = offset;
        }

        public GameObject Create(Vector3 position)
        {
            return _factory.Create(position + _offset);
        }
    }
}