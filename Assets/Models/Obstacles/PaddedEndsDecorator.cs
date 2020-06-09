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
                Fill(obstacleBounds.BuildAbove(area.yMax - obstacleBounds.yMax));
                Fill(obstacleBounds.BuildBelow(obstacleBounds.yMin - area.yMin));
            }
            return obstacleBounds;
        }

        private void Fill(RectInt rect)
        {
            if(rect.height > 1)
            {
                foreach (var y in rect.FromTopToBottom())
                {
                    _objectFactory.Create(new Vector2(rect.x, y));
                }
            }
        }
    }
}