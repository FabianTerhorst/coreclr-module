using System;
using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface IWorldObject : ISharedWorldObject, IBaseObject
    {
        /// <summary>
        /// Get or set position of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was deleted before</exception>
        new Position Position { get; set; }

        /// <summary>
        /// Get or set dimension of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was deleted before</exception>
        int Dimension { get; set; }
    }

    public static class WorldObjectExtensions
    {
        public static void SetPosition(this IWorldObject worldObject, (float X, float Y, float Z) position) =>
            worldObject.Position = new Position(position.X, position.Y, position.Z);

        public static void SetPosition(this IWorldObject worldObject, float x, float y, float z) =>
            worldObject.Position = new Position(x, y, z);

        public static (float X, float Y, float Z) GetPosition(this IWorldObject worldObject)
        {
            var position = worldObject.Position;
            return (position.X, position.Y, position.Z);
        }
    }
}