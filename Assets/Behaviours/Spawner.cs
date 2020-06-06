using UnityEngine;
using Chutes;
using System.Linq;
using Obstacles;
using System.Collections;
using Levels;
using Values;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private ObjectFactory _factory;
    [SerializeField]
    private Transform _player;
    [SerializeField, Range(1, 15)]
    private int _chuteWidth = 12;
    [SerializeField, Range(-10, 10)]
    private int _xOffset;
    [SerializeField, Range(3, 25)]
    private int _chunkHeight;
    [SerializeField]
    private ChainedCurves _difficulty;

    IEnumerator Start()
    {
        var origin = new RectInt(Vector2Int.right * _xOffset, Vector2Int.right * _chuteWidth);
        var level = new Level(Chute(), Obstacle(), Difficulty());
        yield return level.Play(origin, _player);
    }

    private Chute Chute()
    {
        return new EvenChute(_chunkHeight);
    }

    private Obstacle Obstacle()
    {
        return new ObjectWaveObstacle(_factory, Random.Range(0, Mathf.PI * 10), new FloatRange(0.2f, 0.5f), new FloatRange(0.4f, 0.2f));
    }

    private Curve Difficulty()
    {
        return new FuzzyCurve(_difficulty, new System.Random(), new FloatRange(-0.1f, 0.1f));
    }
}
