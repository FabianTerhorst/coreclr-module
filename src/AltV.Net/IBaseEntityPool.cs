using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    /// <summary>
    /// This pool decides which entity pool to use depending on the entity type 
    /// </summary>
    public interface IBaseEntityPool
    {
        bool GetOrCreate(IntPtr entityPointer, EntityType entityType, out IEntity entity);
        bool GetOrCreate(IntPtr entityPointer, out IEntity entity);
        bool Remove(IEntity entity);
        bool Remove(IntPtr entityPointer);
    }
}