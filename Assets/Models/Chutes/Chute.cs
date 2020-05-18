using System.Collections.Generic;
using UnityEngine;

namespace Chutes
{
    /// <summary>
    /// A Chute is the divison of space into a stack of rectangles.
    /// </summary>
    public abstract class Chute
    {
        public abstract IEnumerable<RectInt> From(RectInt origin);
    }
}