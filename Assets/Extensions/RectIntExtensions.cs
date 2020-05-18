using UnityEngine;

namespace ExtensionMethods
{
    public static class RectIntExtensions
    {
        public static RectInt BuildBelow (this RectInt rect, int height)
        {
            return new RectInt(rect.position + (Vector2Int.down * height), new Vector2Int(rect.width, height));
        }

        public static RectInt Draw(this RectInt rect)
        {
            for (var y = rect.yMin; y <= rect.yMax; y++)
            {
                Debug.DrawLine(new Vector3(rect.xMin, y), new Vector3(rect.xMax, y), Color.red, 9999);
            }
            return rect;
        }
    }
}