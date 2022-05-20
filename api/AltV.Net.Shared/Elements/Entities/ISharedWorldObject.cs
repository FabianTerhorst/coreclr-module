using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedWorldObject : ISharedBaseObject
    {
        IntPtr WorldObjectNativePointer { get; }
        
        /// <summary>
        /// Get or set position of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was deleted before</exception>
        Position Position { get; }
    }
}