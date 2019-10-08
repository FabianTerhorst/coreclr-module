namespace AltV.Net.Elements.Entities
{
    public interface IBlip : IWorldObject
    {
        /// <summary>
        /// If the blip is global.
        /// </summary>
        bool IsGlobal { get; }
        
        /// <summary>
        /// If the blip is attached.
        /// </summary>
        bool IsAttached { get; }
        
        /// <summary>
        /// Get the current entity the blip is attached to.
        /// </summary>
        IEntity AttachedTo { get; }
        
        /// <summary>
        /// Get the type of blip.
        /// </summary>
        byte BlipType { get; }
        
        /// <summary>
        /// Set the blip sprite.
        /// </summary>
        ushort Sprite { set; }
        
        /// <summary>
        /// Set the blip color.
        /// </summary>
        byte Color { set; }
        
        /// <summary>
        /// Set if a route to the blip should be shown.
        /// </summary>
        bool Route { set; }
        
        /// <summary>
        /// Set the route color to the blip
        /// </summary>
        byte RouteColor { set; }
        
        /// <summary>
        /// Remove the blip.
        /// </summary>
        void Remove();
    }
}
