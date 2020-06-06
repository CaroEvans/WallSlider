using Chutes;
using Obstacles;
using System.Collections;
using System.Linq;
using UnityEngine;
using Values;

namespace Levels
{
    public class Level
    {
        private readonly Chute _chute;
        private readonly Obstacle _obstacle;
        private readonly Curve _difficulty;

        public Level(Chute chute, Obstacle obstacle, Curve difficulty)
        {
            _chute = chute;
            _obstacle = obstacle;
            _difficulty = difficulty;
        }

        public IEnumerator Play(RectInt origin, Transform player)
        {
            int spawnedChunks = 0;
            foreach (var rect in _chute.From(origin).Skip(1))
            {
                _obstacle.Fill(rect, _difficulty.Evaluate(spawnedChunks++));
                yield return new WaitUntil(() => player.position.y < rect.yMax);
            }
        }
    }
}

