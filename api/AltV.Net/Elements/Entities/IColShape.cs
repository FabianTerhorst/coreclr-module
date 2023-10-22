using System;
using System.Numerics;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface IColShape : ISharedColShape, IWorldObject
    {
        /// <summary>
        /// Returns the ColShape type
        /// </summary>
        ColShapeType ColShapeType { get; }

        /// <summary>
        /// Sets / Gets if the ColShape only triggers for players
        /// </summary>
        bool IsPlayersOnly { get; set; }

        bool IsEntityIn(IEntity entity);

        /// <summary>
        /// Returns if the entity is inside the ColShape
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        [Obsolete("Use IsEntityIn instead")]
        bool IsPlayerIn(IPlayer entity);

        /// <summary>
        /// Returns if the entity is inside the ColShape
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        [Obsolete("Use IsEntityIn instead")]
        bool IsVehicleIn(IVehicle entity);
    }
}