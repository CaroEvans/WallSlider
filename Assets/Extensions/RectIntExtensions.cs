using System.Collections.Generic;
using UnityEngine;

namespace ExtensionMethods
{
    public static class RectIntExtensions
    {
        /// <summary>
        /// Builds a new rectangle starting from below the given rectangle and extending downards.
        /// </summary>
        /// <param name="rect">The rectangle that will act as the point of origin.</param>
        /// <param name="height">The desired height of the new rectangle.</param>
        /// <returns>The new rectangle directly below the provided rectangle.</returns>
        public static RectInt BuildBelow (this RectInt rect, int height)
        {
            return new RectInt(rect.position + (Vector2Int.down * height), new Vector2Int(rect.width, height));
        }

        /// <summary>
        /// Draw a rectangle as a horizontal line for debugging purposes.
        /// </summary>
        /// <param name="rect">The rectangle to be drawn.</param>
        /// <returns>The rectangle that was drawn.</returns>
        public static RectInt Draw(this RectInt rect)
        {
            for (var y = rect.yMin; y <= rect.yMax; y++)
            {
                Debug.DrawLine(new Vector3(rect.xMin, y), new Vector3(rect.xMax, y), Color.red, 9999);
            }
            return rect;
        }

        /// <summary>
        /// Iterate over each y position starting from the max and ending with the min.
        /// </summary>
        /// <param name="rect">The rectangle used to provide the range of values..</param>
        /// <returns>An enumerable containing each y position within the rectangle in descending order.</returns>
        public static IEnumerable<int> FromTopToBottom (this RectInt rect)
        {
            for (int y = rect.yMax; y > rect.yMin; y--)
                yield return y;
        }
    }
}