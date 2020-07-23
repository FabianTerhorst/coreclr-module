namespace AltV.Net.Elements.Entities
{
    public interface IColShape : IWorldObject
    {
        /// <summary>
        /// Returns the ColShape type
        /// </summary>
        ColShapeType ColShapeType { get; }
        
        /// <summary>
        /// Sets / Gets if the ColShape only triggers for players
        /// </summary>
        bool IsPlayersOnly { get; set; }
		
        /// <summary>
        /// Returns if the entity is inside the ColShape
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsEntityIn(IEntity entity);
        
        /// <summary>
        /// Returns if the entity is inside the ColShape
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsPlayerIn(IPlayer entity);
        
        /// <summary>
        /// Returns if the entity is inside the ColShape
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsVehicleIn(IVehicle entity);
		
        /// <summary>
        /// Removes the collision shape
        /// </summary>
        void Remove();
    }
}