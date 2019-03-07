using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface IWorldObject : IBaseObject
    {
        /// <summary>
        /// Get or set position of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Position Position { get; set; }

        /// <summary>
        /// Get or set dimension of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        short Dimension { get; set; }
    }
}