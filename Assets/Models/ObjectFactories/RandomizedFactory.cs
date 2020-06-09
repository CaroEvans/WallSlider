using UnityEngine;

namespace ObjectFactories
{
    public class RandomizedFactory : IObjectFactory
    {
        private readonly IObjectFactory[] _factories;
        private readonly System.Random _random;

        public RandomizedFactory(IObjectFactory[] factories, System.Random random)
        {
            _factories = factories;
            _random = random;
        }

        public GameObject Create(Vector3 position)
        {
            return _factories[_random.Next(0, _factories.Length)].Create(position);
        }
    }
}
