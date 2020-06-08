using ExtensionMethods;
using System.Collections.Generic;
using System.Linq;
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
            return _chute.From(origin).Select(Draw);
        }

        private RectInt Draw(RectInt rect)
        {
            return rect.DrawBounds(Color.cyan, Vector2.zero);
        }
    }
}