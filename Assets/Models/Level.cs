using Chutes;
using Obstacles;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Levels
{
    public class Level
    {
        private readonly Chute _chute;
        private readonly Obstacle _obstacle;
        private readonly Func<float, float> _difficultyFunction;

        public Level(Chute chute, Obstacle obstacle, Func<float, float> difficultyFunction)
        {
            _chute = chute;
            _obstacle = obstacle;
            _difficultyFunction = difficultyFunction;
        }

        public IEnumerator Play(RectInt origin, Transform player)
        {
            int spawnedChunks = 0;
            foreach (var rect in _chute.From(origin).Skip(1))
            {
                _obstacle.Fill(rect, _difficultyFunction.Invoke(spawnedChunks++));
                yield return new WaitUntil(() => player.position.y < rect.yMax);
            }
        }
    }
}

