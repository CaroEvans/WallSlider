using UnityEngine;

namespace Obstacles
{
    /// <summary>
    /// An Obstacle presents the player with a problem to overcome as 
    /// they try to pass through an area.
    /// </summary>
    public abstract class Obstacle
    {
        public abstract RectInt Fill(RectInt area);
    }
}
