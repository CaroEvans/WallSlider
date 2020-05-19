using UnityEngine;
using Chutes;
using System.Linq;
using ExtensionMethods;
using Obstacles;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _path;
    [SerializeField, Range(0, 0.5f)]
    private float _spawnThreshold;
    [SerializeField]
    private ObjectFactory _factory;

    void Start()
    {
        Chute chute = new EvenChute(5);
        var obstacle = new ObjectStringObstacle(_path, _spawnThreshold, _factory);
        var origin = new RectInt(Vector2Int.zero, Vector2Int.right * 12);
        chute.From(origin)
             .Where(rect => (rect.yMax % 10) == 0)
             .Take(5)
             .Select(obstacle.Fill)
             .Select(RectIntExtensions.Draw)
             .ToArray();
    }
}
