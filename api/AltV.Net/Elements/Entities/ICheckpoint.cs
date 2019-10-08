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
        /// Returns the enumeration of the checkpoint type
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
        /// Returns the target
        /// </summary>
        IPlayer Target { get; }
        
        /// <summary>
        /// Returns if the player exists
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsPlayerIn(IPlayer player);
        
        /// <summary>
        /// Returns if the vehicle exists
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