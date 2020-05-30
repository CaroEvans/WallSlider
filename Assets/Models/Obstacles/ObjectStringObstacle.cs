using ExtensionMethods;
using UnityEngine;
using Values;

namespace Obstacles
{
    /// <summary>
    /// An ObjectStringObstacle places objects in a line to guide or interrupt
    /// the player's path.
    /// </summary>
    public class ObjectStringObstacle : Obstacle
    {
        private readonly AnimationCurve _path;
        private readonly ObjectFactory _objectFactory;
        private readonly Range<float> _spawnThreshold;

        public ObjectStringObstacle(AnimationCurve path, ObjectFactory objectFactory, Range<float> spawnThreshold)
        {
            _path = path;
            _objectFactory = objectFactory;
            _spawnThreshold = spawnThreshold;
        }

        public override RectInt Fill(RectInt area, float difficulty)
        {
            foreach (var y in area.FromTopToBottom())
            {
                CreateObject(area, y, _spawnThreshold.FromNormal(difficulty));
            }
            return area;
        }

        private void CreateObject (RectInt area, int y, float spawnThreshold)
        {
            var t = Mathf.Abs((y - area.yMax) / (float)(area.yMin - area.yMax));
            t = _path.Evaluate(t);
            if (CanSpawn(t, spawnThreshold))
            {
                var x = Mathf.Lerp(area.xMin, area.xMax, 1 - Mathf.Round(t));
                _objectFactory.Create(new Vector2(x, y));
            }
        }

        private bool CanSpawn(float placement, float spawnThreshold)
        {
            return placement < spawnThreshold || placement > 1 - spawnThreshold;
        }
    }
}
