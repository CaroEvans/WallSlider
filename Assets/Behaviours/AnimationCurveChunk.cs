using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class AnimationCurveChunk
{
    [SerializeField]
    private AnimationCurve _curve;
    [SerializeField]
    private float _loadDelay;
    [SerializeField, Range(0, 0.5f)]
    private float _spawnThreshold;

    public IEnumerator Load(RectInt bounds, ObjectFactory objectFactory)
    {
        var loadDelay = new WaitForSeconds(_loadDelay);
        for(int y = bounds.yMax; y >= bounds.yMin; y--)
        {
            var t = Mathf.Abs((y - bounds.yMax) / (float)(bounds.yMin - bounds.yMax));
            t = _curve.Evaluate(t);
            yield return loadDelay;
            if(t < _spawnThreshold || t > 1 - _spawnThreshold)
            {
                var x = Mathf.Lerp(bounds.xMin, bounds.xMax, 1 - Mathf.Round(t));
                objectFactory.Create(new Vector2(x, y));
            }
        }
    }
}
