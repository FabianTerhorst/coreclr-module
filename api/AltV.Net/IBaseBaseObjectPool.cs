using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;

namespace AltV.Net
{
    /// <summary>
    /// This pool decides which entity pool to use depending on the entity type 
    /// </summary>
    public interface IBaseBaseObjectPool : IReadOnlyBaseBaseObjectPool
    {
        IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId);
        IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType);
        new IBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType);
        bool Remove(IBaseObject baseObject);
        bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}