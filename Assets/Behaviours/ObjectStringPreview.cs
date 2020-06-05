using UnityEngine;
using Chutes;
using System.Linq;
using Obstacles;
using Values;
using ExtensionMethods;
using System.Collections;

[ExecuteInEditMode]
public class ObjectStringPreview : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _stringCurve;
    [SerializeField, Range(3, 20)]
    private int _chunkHeight;
    [SerializeField]
    private ObjectFactory _factory;
    [SerializeField, Range(0, 1f)]
    private float _difficulty;

    private int _chuteWidth = 6;
    private int _xOffset = 1;
    private IEnumerator _routine = null;

    public void Update()
    {
        if(_stringCurve != null && _routine == null)
        {
            _routine = RenderPreview(_difficulty);
            StartCoroutine(_routine);
        }
    }

    private IEnumerator RenderPreview (float difficulty)
    {
        GameObject trash = new GameObject("Trash");
        while (transform.childCount > 0)
            transform.GetChild(0).SetParent(trash.transform);
        DestroyImmediate(trash);
        var origin = new RectInt(Vector2Int.right * _xOffset, Vector2Int.right * _chuteWidth);
        var rect = new DebugChute(new EvenChute(_chunkHeight)).From(origin).First();
        var obstacle = new ObjectStringObstacle(_stringCurve, _factory, new FloatRange(0.1f, 0.4f));
        obstacle.Fill(rect, difficulty);
        int id = _stringCurve.Identity();
        yield return new WaitUntil(() => _stringCurve.Identity() != id || _difficulty != difficulty);
        _routine = null;
    }
}
