using AltV.Net.Data;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedCheckpoint : ISharedColShape
    {
        IntPtr CheckpointNativePointer { get; }

        /// <summary>
        /// Gets or sets the checkpoint type
        /// </summary>
        byte CheckpointType { get; set; }

        /// <summary>
        /// Gets or sets the height
        /// </summary>
        float Height { get; set; }

        /// <summary>
        /// Gets or sets the radius
        /// </summary>
        float Radius { get; set; }

        /// <summary>
        /// Gets or sets the color in Rgba format
        /// </summary>
        Rgba Color { get; set; }

        /// <summary>
        /// Sets or gets the next checkpoint position
        /// </summary>
        Position NextPosition { get; set; }

        uint StreamingDistance { get; }

        bool Visible { get; set; }
    }
}