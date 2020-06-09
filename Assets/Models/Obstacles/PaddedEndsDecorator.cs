using ExtensionMethods;
using ObjectFactories;
using UnityEngine;

namespace Obstacles
{
    public class PaddedEndsDecorator : Obstacle
    {
        private readonly Obstacle _obstacle;
        private readonly IObjectFactory _objectFactory;

        public PaddedEndsDecorator(Obstacle obstacle, IObjectFactory objectFactory)
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
            foreach(var y in rect.FromTopToBottom())
            {
                new RectInt(rect.x, y, 0, 0).DrawBounds(Color.green, Vector2.one * 0.2f);
            }
        }
    }
}