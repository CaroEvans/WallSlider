using ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Chutes
{
    /// <summary>
    /// An EvenChute is a Chute made up of evenly sized segments.
    /// </summary>
    public class EvenChute : Chute
    {
        private readonly int _rectangleHeight;

        public EvenChute(int rectangleHeight)
        {
            _rectangleHeight = rectangleHeight;
        }

        public override IEnumerable<RectInt> From(RectInt origin)
        {
            while (true)
            {
                origin = origin.BuildBelow(_rectangleHeight);
                yield return origin;
            }
        }
    }
}
