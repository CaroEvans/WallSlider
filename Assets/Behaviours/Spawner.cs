using UnityEngine;
using Chutes;
using System.Linq;
using Obstacles;
using System.Collections;
using ExtensionMethods;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve[] _paths;
    [SerializeField, Range(0, 0.5f)]
    private float _spawnThreshold;
    [SerializeField]
    private ObjectFactory _factory;
    [SerializeField]
    private Hashtable _hashTable;
    [SerializeField]
    private Transform _player;
    [SerializeField, Range(1, 15)]
    private int _chuteWidth = 12;
    [SerializeField, Range(-10, 10)]
    private int _xOffset;
    [SerializeField, Range(3, 25)]
    private int _chunkHeight;

    IEnumerator Start()
    {
        Chute chute = new EvenChute(_chunkHeight);
        var obstacles = _paths.Select(p => new ObjectStringObstacle(p, _spawnThreshold, _factory)).ToArray();
        var randomizedObstacle = new RandomizedObstacle(new System.Random(), obstacles);
        var origin = new RectInt(Vector2Int.right * _xOffset, Vector2Int.right * _chuteWidth);
        foreach (var rect in chute.From(origin).Select(randomizedObstacle.Fill))
        {
            yield return new WaitUntil(() => _player.position.y < rect.yMax);
        }
    }
}
