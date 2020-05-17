using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private AnimationCurveChunk _chunk;
    [SerializeField]
    private ObjectFactory _factory;

    void Start()
    {
        StartCoroutine(_chunk.Load(new RectInt(-6, -10, 12, 10), _factory));
    }
}
