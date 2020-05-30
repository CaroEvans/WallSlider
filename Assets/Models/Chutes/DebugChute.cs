using System.Collections.Generic;
using UnityEngine;

namespace Chutes
{
    /// <summary>
    /// Debug Chute acts as a wrapper that provides debug info for a given chute.
    /// </summary>
    public class DebugChute : Chute
    {
        private readonly Chute _chute;

        public DebugChute(Chute chute)
        {
            _chute = chute;
        }

        public override IEnumerable<RectInt> From(RectInt origin)
        {
            foreach (var rect in _chute.From(origin))
            {
                Debug.DrawLine(new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMax), Color.cyan, float.MaxValue);
                yield return rect;
            }
        }
    }
}