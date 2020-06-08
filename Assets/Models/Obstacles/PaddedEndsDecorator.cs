using ExtensionMethods;
using UnityEngine;

namespace Obstacles
{
    public class PaddedEndsDecorator : Obstacle
    {
        private readonly Obstacle _obstacle;
        private readonly ObjectFactory _objectFactory;

        public PaddedEndsDecorator(Obstacle obstacle, ObjectFactory objectFactory)
        {
            _obstacle = obstacle;
            _objectFactory = objectFactory;
        }

        public override RectInt Fill(RectInt area, float difficulty)
        {
            var obstacleBounds = _obstacle.Fill(area, difficulty);
            if(obstacleBounds.width == 0)
            {
                FillWithRewards(obstacleBounds.BuildAbove(area.yMax - obstacleBounds.yMax));
                FillWithRewards(obstacleBounds.BuildBelow(obstacleBounds.yMin - area.yMin));
            }
            return obstacleBounds;
        }

        private void FillWithRewards(RectInt rect)
        {
            if(rect.height > 0)
            {
                rect.DrawBounds(Color.green, new Vector2(0.4f, 0f));
            }
        }
    }
}

