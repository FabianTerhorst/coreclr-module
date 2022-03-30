using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client
{
    /// <summary>
    /// This pool decides which entity pool to use depending on the entity type 
    /// </summary>
    public interface IBaseEntityPool
    {
        bool GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId, out IEntity baseObject);
        bool GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, out IEntity baseObject);
        bool Get(IntPtr entityPointer, BaseObjectType baseObjectType, out IEntity baseObject);
        bool Remove(IEntity baseObject);
        bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}