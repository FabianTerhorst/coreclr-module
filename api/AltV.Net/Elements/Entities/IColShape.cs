namespace AltV.Net.Elements.Entities
{
    public interface IColShape : IWorldObject
    {
        /// <summary>
        /// Obtains the enumerated value of collision shape of the entity
        /// </summary>
        ColShapeType ColShapeType { get; }
		
        /// <summary>
        /// Checks whether the entity exists
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsEntityIn(IEntity entity);
		
        /// <summary>
        /// Removes the collision shape
        /// </summary>
        void Remove();
    }
}