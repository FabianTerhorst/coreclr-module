using System.Numerics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Interactions
{
    public interface IInteraction
    {
        ulong Type { get;  }
        
        ulong Id { get; }
        
        Vector3 Position { get; }
        
        int Dimension { get; }
        
        uint Range { get; }
        
        uint RangeSquared { get; }
        
        /// <summary>
        /// On interaction.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="interactionPosition"></param>
        /// <param name="interactionDimension"></param>
        /// <returns>True if you don't want that other interactions are triggered as well</returns>
        bool OnInteraction(IPlayer player, Vector3 interactionPosition, int interactionDimension, object argument);
    }
}