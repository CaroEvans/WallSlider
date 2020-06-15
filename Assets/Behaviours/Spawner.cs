using UnityEngine;
using Chutes;
using System.Linq;
using Obstacles;
using System.Collections;
using Levels;
using Values;
using ObjectFactories;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private PrefabFactory _factory;
    [SerializeField]
    private PrefabFactory[] _fruitFactories;
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

    private NearbyObstacles _nearbyRewards;

    IEnumerator Start()
    {
        var origin = new RectInt(Vector2Int.right * _xOffset, Vector2Int.right * _chuteWidth);
        var level = new Level(Chute(), Obstacle(), Difficulty());
        yield return level.Play(origin, _player);
    }

    // Why is this here; What do the numbers mean; God help ye...
    public IEnumerator BounceItems (Vector3 origin)
    {
        var objs = origin.x < 4 ? _nearbyRewards.LeftSide() : _nearbyRewards.RightSide();
        var startingPositions = new List<float>();
        float timeElapsed = 0;
        while(true)
        {
            bool completed = true;
            for (int i = 0; i < objs.Length; i++)
            {
                var obj = objs[i];
                var objPos = obj.transform.position;
                if (startingPositions.Count < objs.Length)
                    startingPositions.Add(objPos.x);
                var dist = Mathf.Abs(origin.y - objPos.y) * 0.35f;
                var t = Mathf.Clamp(timeElapsed - dist, 0, Mathf.PI);
                var offset = Mathf.Sign(objPos.x - 4) * Mathf.Abs(Mathf.Sin(t)) * Mathf.Lerp(0.6f, 0f, Mathf.InverseLerp(0, 3.5f, dist));
                objPos.x = startingPositions[i] - offset;
                obj.transform.position = objPos;
                completed = completed && Mathf.Approximately(t, Mathf.PI);
            }
            if (completed) break;
            timeElapsed += Time.deltaTime * 10f;
            yield return null;
        }
    }

    private Chute Chute()
    {
        var evenChute = new EvenChute(_chunkHeight);
        return new DebugChute(evenChute);
    }

    private Obstacle Obstacle()
    {
        var obstacle = new ObjectWaveObstacle(_factory, Random.Range(0, Mathf.PI * 10), new FloatRange(0.2f, 0.5f), new FloatRange(0.4f, 0.2f));
        var rewardFactories = new RandomizedFactory(_fruitFactories, new System.Random());
        _nearbyRewards = new NearbyObstacles(rewardFactories, 20);
        return new PaddedEndsDecorator(obstacle, _nearbyRewards);
    }

    private Curve Difficulty()
    {
        return new FuzzyCurve(_difficulty, new System.Random(), new FloatRange(-0.1f, 0.1f));
    }
}
