using ExtensionMethods;
using UnityEngine;

namespace Obstacles
{
    /// <summary>
    /// Debug obstacles acts as a wrapper that provides debug info for a given obstacle.
    /// </summary>
    public class DebugObstacle : Obstacle
    {
        private readonly Obstacle _obstacle;

        public DebugObstacle(Obstacle obstacle)
        {
            _obstacle = obstacle;
        }

        public override RectInt Fill(RectInt area, float difficulty)
        {
            return _obstacle.Fill(area, difficulty).DrawBounds(Color.red, Vector2.one * 0.5f);
        }
    }
}

