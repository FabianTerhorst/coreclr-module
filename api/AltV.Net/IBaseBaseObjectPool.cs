using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    /// <summary>
    /// This pool decides which entity pool to use depending on the entity type 
    /// </summary>
    public interface IBaseBaseObjectPool
    {
        bool GetOrCreate(IServer server, IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId, out IBaseObject baseObject);
        bool GetOrCreate(IServer server, IntPtr entityPointer, BaseObjectType baseObjectType, out IBaseObject baseObject);
        bool Get(IntPtr entityPointer, BaseObjectType baseObjectType, out IBaseObject baseObject);
        bool Remove(IBaseObject baseObject);
        bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}