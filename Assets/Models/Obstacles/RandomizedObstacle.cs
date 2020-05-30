using System;

namespace Obstacles
{
    public class RandomizedObstacle : Obstacle
    {
        private readonly Obstacle[] _obstacles;
        private readonly Random _random;

        public RandomizedObstacle(Random random, params Obstacle[] obstacles)
        {
            _obstacles = obstacles;
            _random = random;
        }

        public override UnityEngine.RectInt Fill(UnityEngine.RectInt area, float difficulty)
        {
            return _obstacles[_random.Next(0, _obstacles.Length)].Fill(area, difficulty);
        }
    }
}
