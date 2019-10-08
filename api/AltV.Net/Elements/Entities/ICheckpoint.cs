using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface ICheckpoint : IWorldObject
    {
        /// <summary>
        /// Gets whether the checkpoint is global
        /// </summary>
        bool IsGlobal { get; }
        
        /// <summary>
        /// Returns the checkpoint type
        /// </summary>
        byte CheckpointType { get; }
        
        /// <summary>
        /// Gets the height
        /// </summary>
        float Height { get; }
        
        /// <summary>
        /// Gets the radius
        /// </summary>
        float Radius { get; }
        
        /// <summary>
        /// Obtains the color in Rgba format
        /// </summary>
        Rgba Color { get; }
        
        /// <summary>
        /// Returns the player for whom the checkpoint is visible
        /// </summary>
        IPlayer Target { get; }
        
        /// <summary>
        /// Returns if the player is inside the checkpoint
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsPlayerIn(IPlayer player);
        
        /// <summary>
        /// Returns if the vehicle is inside the checkpoint
        /// </summary>
        /// <param name="vehicle">The vehicle</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsVehicleIn(IVehicle vehicle);
        
        /// <summary>
        /// Removes the checkpoint
        /// </summary>
        void Remove();
    }
}