using ExtensionMethods;
using UnityEngine;

namespace Obstacles
{
    /// <summary>
    /// An ObjectStringObstacle places objects in a line to guide or interrupt
    /// the player's path.
    /// </summary>
    public class ObjectStringObstacle : Obstacle
    {
        private readonly AnimationCurve _path;
        private readonly float _spawnThreshold;
        private readonly ObjectFactory _objectFactory;

        public ObjectStringObstacle(AnimationCurve path, float spawnThreshold, ObjectFactory objectFactory)
        {
            _path = path;
            _spawnThreshold = spawnThreshold;
            _objectFactory = objectFactory;
        }

        public override RectInt Fill(RectInt area)
        {
            foreach (var y in area.FromTopToBottom())
            {
                CreateObject(area, y);
            }
            return area;
        }

        private void CreateObject (RectInt area, int y)
        {
            var t = Mathf.Abs((y - area.yMax) / (float)(area.yMin - area.yMax));
            t = _path.Evaluate(t);
            if (t < _spawnThreshold || t > 1 - _spawnThreshold)
            {
                var x = Mathf.Lerp(area.xMin, area.xMax, 1 - Mathf.Round(t));
                _objectFactory.Create(new Vector2(x, y));
            }
        }
    }
}
