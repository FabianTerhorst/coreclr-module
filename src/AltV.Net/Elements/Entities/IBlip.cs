namespace AltV.Net.Elements.Entities
{
    public interface IBlip : IEntity
    {
        /// <summary>
        /// Get or set color of the blip.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint Color { /*get;*/ set; }
    }
}