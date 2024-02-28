using System.Numerics;
using AltV.Net.Data;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedBlip : ISharedWorldObject
    {
        IntPtr BlipNativePointer { get; }

        /// <summary>
        /// If the blip is global.
        /// </summary>
        bool IsGlobal { get; }

        /// <summary>
        /// Get the type of blip.
        /// </summary>
        byte BlipType { get; }

        /// <summary>
        /// Gets or sets the blip sprite.
        /// </summary>
        uint Sprite { set; get; }

        /// <summary>
        /// Gets or sets the blip color.
        /// </summary>
        uint Color { set; get; }

        /// <summary>
        /// Gets or sets if a route to the blip should be shown.
        /// </summary>
        bool Route { set; get; }

        /// <summary>
        /// Gets or sets the route color to the blip
        /// </summary>
        Rgba RouteColor { set; get; }

        /// <summary>
        /// Gets or sets the scale of the blip
        /// </summary>
        Vector2 ScaleXY { get; set; }

        /// <summary>
        /// Gets or sets the display mode of the blip
        /// </summary>
        uint Display { get; set; }

        /// <summary>
        /// Gets or sets the secondary color of the blip
        /// </summary>
        Rgba SecondaryColor { get; set; }

        /// <summary>
        /// Gets or sets the alpha of the blip
        /// </summary>
        uint Alpha { get; set; }

        /// <summary>
        /// Gets or sets the flash timer of the blip
        /// </summary>
        ushort FlashTimer { get; set; }

        /// <summary>
        /// Gets or sets the flash interval of the blip
        /// </summary>
        ushort FlashInterval { get; set; }

        /// <summary>
        /// Gets or sets if the blip is shown as friendly
        /// </summary>
        bool Friendly { get; set; }

        /// <summary>
        /// Gets or sets if the blip is shown as bright
        /// </summary>
        bool Bright { get; set; }

        /// <summary>
        /// Gets or sets the blips number
        /// </summary>
        ushort Number { get; set; }

        /// <summary>
        /// Gets or sets if the blip is shown with a cone
        /// </summary>
        bool ShowCone { get; set; }

        /// <summary>
        /// Gets or sets if the blip is flashing
        /// </summary>
        bool Flashes { get; set; }

        /// <summary>
        /// Gets or sets if the the blip uses alternate flashing mode
        /// </summary>
        bool FlashesAlternate { get; set; }

        /// <summary>
        /// Gets or sets if the blip is short range
        /// </summary>
        bool ShortRange { get; set; }

        /// <summary>
        /// Gets or sets the blips priority
        /// </summary>
        uint Priority { get; set; }

        /// <summary>
        /// Gets or sets the blips rotation
        /// </summary>
        float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the blips gxt name
        /// </summary>
        string GxtName { get; set; }

        /// <summary>
        /// Gets or sets the blips name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets if the blip is pulsing
        /// </summary>
        bool Pulse { get; set; }

        /// <summary>
        /// Gets or sets if the blip is marked as mission creator
        /// </summary>
        bool MissionCreator { get; set; }

        /// <summary>
        /// Gets or sets if the tick is visible
        /// </summary>
        bool TickVisible { get; set; }

        /// <summary>
        /// Gets or sets if the heading indicator is visible
        /// </summary>
        bool HeadingIndicatorVisible { get; set; }

        /// <summary>
        /// Gets or sets if the outline indicator is visible
        /// </summary>
        bool OutlineIndicatorVisible { get; set; }

        /// <summary>
        /// Gets or sets if the crew indicator is visible
        /// </summary>
        bool CrewIndicatorVisible { get; set; }

        /// <summary>
        /// Gets or sets the blips category
        /// </summary>
        uint Category { get; set; }

        /// <summary>
        /// Gets or sets if the blip is high detail
        /// </summary>
        bool HighDetail { get; set; }

        /// <summary>
        /// Gets or sets if the blip is shrinked
        /// </summary>
        bool Shrinked { get; set; }

        /// <summary>
        /// Fades the blip
        /// </summary>
        void Fade(uint opacity, uint duration);
        bool Visible { get; set; }

        bool IsHiddenOnLegend { get; set; }

        bool IsMinimalOnEdge { get; set; }

        bool IsUseHeightIndicatorOnEdge { get; set; }

        bool IsShortHeightThreshold { get; set; }
    }
}