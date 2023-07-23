using System.Numerics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedColShape : ISharedWorldObject
    {
        IntPtr ColShapeNativePointer { get; }

        /// <summary>
        /// Returns if the entity is inside the ColShape
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsEntityIn(ISharedEntity entity);

        bool IsEntityIdIn(uint id);

        /// <summary>
        /// Returns if the point is inside the ColShape
        /// </summary>
        /// <param name="point">The point</param>
        bool IsPointIn(Vector3 point);
    }
}