using UnityEngine;
using Chutes;
using System.Linq;
using ExtensionMethods;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private AnimationCurveChunk _chunk;
    [SerializeField]
    private ObjectFactory _factory;

    void Start()
    {
        StartCoroutine(_chunk.Load(new RectInt(-6, -10, 12, 10), _factory));

        var chute = new EvenChute(5);
        var origin = new RectInt(Vector2Int.zero, Vector2Int.right * 12);
        chute.From(origin).Where(rect => (rect.yMax % 10) == 0).Take(5).Select(RectIntExtensions.Draw).ToArray();
    }
}
