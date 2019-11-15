using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface ICheckpoint : IColShape
    {
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
    }
}