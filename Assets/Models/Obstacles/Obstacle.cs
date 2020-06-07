using UnityEngine;

namespace Obstacles
{
    /// <summary>
    /// An Obstacle presents the player with a problem to overcome as 
    /// they try to pass through an area.
    /// </summary>
    public abstract class Obstacle
    {
        /// <summary>
        /// Adds the obstacle to a given area.
        /// </summary>
        /// <param name="area">The area where the obstacle may be placed, it might not neccessarily take up the whole area.</param>
        /// <param name="difficulty">Normal dictating how hard the obstacle should be to overcome.</param>
        /// <returns>The area used by the obstacle.</returns>
        public abstract RectInt Fill(RectInt area, float difficulty);
    }
}
