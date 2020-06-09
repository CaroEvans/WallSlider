using ExtensionMethods;
using ObjectFactories;
using UnityEngine;
using Values;

namespace Obstacles
{
    /// <summary>
    /// An ObjectWaveObstacle places objects in a wave pattern.
    /// </summary>
    public class ObjectWaveObstacle : Obstacle
    {
        private readonly IObjectFactory _objectFactory;
        private readonly float _offset;
        private readonly Range<float> _amplitude, _spawnThreshold;

        public ObjectWaveObstacle(IObjectFactory objectFactory, float offset, Range<float> amplitude, Range<float> spawnThreshold)
        {
            _objectFactory = objectFactory;
            _offset = offset;
            _amplitude = amplitude;
            _spawnThreshold = spawnThreshold;
        }

        public override RectInt Fill(RectInt area, float difficulty)
        {
            RectInt areaUsed = new RectInt(Vector2Int.one * int.MaxValue, Vector2Int.zero);
            foreach (var y in area.FromTopToBottom())
            {
                var t = Mathf.InverseLerp(-1, 1, Mathf.Sin((y + _offset) * _amplitude.FromNormal(difficulty)));
                if(Mathf.Abs(t - 0.5f) > _spawnThreshold.FromNormal(difficulty))
                {
                    var position = new Vector2(Mathf.Lerp(area.xMin, area.xMax, 1 - Mathf.Round(t)), y);
                    areaUsed = areaUsed.ExtendToCover(position);
                    _objectFactory.Create(position);
                }
            }

            return areaUsed;
        }
    }
}
