using Structures;
using UnityEngine;

namespace ObjectFactories
{
    public class NearbyObstacles : IObjectFactory
    {
        private IObjectFactory _objectFactory;
        private readonly CircularList<GameObject> _leftSide, _rightSide;

        public NearbyObstacles(IObjectFactory factory, int capacity)
        {
            _objectFactory = factory;
            _leftSide = new CircularList<GameObject>(capacity);
            _rightSide = new CircularList<GameObject>(capacity);
        }

        public GameObject[] LeftSide ()
        {
            return _leftSide.ToArray();
        }

        public GameObject[] RightSide ()
        {
            return _rightSide.ToArray();
        }

        public GameObject Create(Vector3 position)
        {
            var obj = _objectFactory.Create(position);
            if (position.x < 4)
                _leftSide.Add(obj);
            else
                _rightSide.Add(obj);
            return obj;
        }
    }
}