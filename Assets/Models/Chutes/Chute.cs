using System.Collections.Generic;
using UnityEngine;

namespace Chutes
{
    /// <summary>
    /// A Chute is a long vertical area used for falling downwards.
    /// </summary>
    public abstract class Chute
    {
        /// <summary>
        /// Divides the chute into a contiguous series of rectangles.
        /// </summary>
        /// <param name="origin">The area that the chute starts from.</param>
        /// <returns>The collection of rectangles that form the chute.</returns>
        public abstract IEnumerable<RectInt> From(RectInt origin);
    }
}