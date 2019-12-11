using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface IWorldObject : IBaseObject
    {
        /// <summary>
        /// Get or set position of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was deleted before</exception>
        Position Position { get; set; }

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

        public static (float X, float Y, float Z) GetPosition(this IWorldObject worldObject) =>
            (worldObject.Position.X, worldObject.Position.Y, worldObject.Position.Z);
    }
}