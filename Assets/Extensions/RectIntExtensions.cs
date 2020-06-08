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
        /// <returns>The new rectangle directly below the origin rectangle.</returns>
        public static RectInt BuildBelow (this RectInt rect, int height)
        {
            return new RectInt(rect.position + (Vector2Int.down * height), new Vector2Int(rect.width, height));
        }

        /// <summary>
        /// Builds a new rectangle starting from above the given rectangle and extending upwards.
        /// </summary>
        /// <param name="rect">The rectangle that will act as the point of origin.</param>
        /// <param name="height">The desired height of the new rectangle.</param>
        /// <returns>The new rectangle directly abpve the origin rectangle.</returns>
        public static RectInt BuildAbove(this RectInt rect, int height)
        {
            return new RectInt(rect.position + Vector2Int.up * (rect.height), new Vector2Int(rect.width, height));
        }

        /// <summary>
        /// Draws a horizontal line spanning the width of the rect at each y position it covers.
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

        /// <summary>
        /// Extend the rect to contain a given point if it is not already included.
        /// </summary>
        /// <param name="rect">The rect to be extended.</param>
        /// <param name="point">The point that should be covered by the rect.</param>
        /// <returns>The rect that covers the given point.</returns>
        public static RectInt ExtendToCover(this RectInt rect, Vector2 point)
        {
            var minAnchor = new Vector2Int(
                Mathf.FloorToInt(Mathf.Min(rect.xMin, point.x)),
                Mathf.FloorToInt(Mathf.Min(rect.yMin, point.y))
            );
            var dimensions = new Vector2Int(
                rect.xMax == int.MaxValue ? 0 : Mathf.Max(rect.width, Mathf.CeilToInt(Mathf.Max(rect.xMax, point.x) - minAnchor.x)),
                rect.yMax == int.MaxValue ? 0 : Mathf.Max(rect.height, Mathf.CeilToInt(Mathf.Max(rect.yMax, point.y) - minAnchor.y))
            );
            return new RectInt(minAnchor, dimensions);
        }

        /// <summary>
        /// Draw the boundaries of the rect for debugging purposes.
        /// </summary>
        /// <param name="rect">The rectangle to be drawn.</param>
        /// <param name="color">The color of the lines.</param>
        /// <returns>The rectangle that was drawn.</returns>
        public static RectInt DrawBounds(this RectInt rect, Color color, Vector2 offset)
        {
            var original = rect;
            var offsetRect = new Rect(rect.x - offset.x, rect.y - offset.y, rect.width + offset.x * 2, rect.height + offset.y * 2);
            Debug.DrawLine(new Vector2(offsetRect.xMin, offsetRect.yMax), new Vector2(offsetRect.xMax, offsetRect.yMax), color, float.MaxValue);
            Debug.DrawLine(new Vector2(offsetRect.xMin, offsetRect.yMin), new Vector2(offsetRect.xMax, offsetRect.yMin), color, float.MaxValue);
            Debug.DrawLine(new Vector2(offsetRect.xMin, offsetRect.yMin), new Vector2(offsetRect.xMin, offsetRect.yMax), color, float.MaxValue);
            Debug.DrawLine(new Vector2(offsetRect.xMax, offsetRect.yMin), new Vector2(offsetRect.xMax, offsetRect.yMax), color, float.MaxValue);
            return rect;
        }
    }
}