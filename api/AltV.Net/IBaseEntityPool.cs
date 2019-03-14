using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    /// <summary>
    /// This pool decides which entity pool to use depending on the entity type 
    /// </summary>
    public interface IBaseEntityPool
    {
        bool GetOrCreate(IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId, out IEntity baseObject);
        bool GetOrCreate(IntPtr entityPointer, BaseObjectType baseObjectType, out IEntity baseObject);
        bool Remove(IEntity baseObject);
        bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}