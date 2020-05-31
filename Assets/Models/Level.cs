using Chutes;
using Obstacles;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Levels
{
    public class Level
    {
        private readonly Chute _chute;
        private readonly Obstacle _obstacle;
        private readonly AnimationCurve _difficultyCurve;

        public Level(Chute chute, Obstacle obstacle, AnimationCurve difficultyCurve)
        {
            _chute = chute;
            _obstacle = obstacle;
            _difficultyCurve = difficultyCurve;
        }

        public IEnumerator Play(RectInt origin, Transform player)
        {
            int spawnedChunks = 0;
            foreach (var rect in _chute.From(origin).Skip(1))
            {
                float difficulty = _difficultyCurve.Evaluate(spawnedChunks++);
                _obstacle.Fill(rect, difficulty);
                yield return new WaitUntil(() => player.position.y < rect.yMax);
            }
        }
    }
}

