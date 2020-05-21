using UnityEngine;
using Chutes;
using System.Linq;
using Obstacles;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _path;
    [SerializeField, Range(0, 0.5f)]
    private float _spawnThreshold;
    [SerializeField]
    private ObjectFactory _factory;
    [SerializeField]
    private Hashtable _hashTable;
    [SerializeField]
    private Transform _player;

    IEnumerator Start()
    {
        Chute chute = new EvenChute(10);
        var obstacle = new ObjectStringObstacle(_path, _spawnThreshold, _factory);
        var origin = new RectInt(Vector2Int.zero, Vector2Int.right * 12);
        foreach (var rect in chute.From(origin).Select(obstacle.Fill).Skip(3))
        {
            yield return new WaitUntil(() => _player.position.y < rect.yMax);
        }
    }
}
