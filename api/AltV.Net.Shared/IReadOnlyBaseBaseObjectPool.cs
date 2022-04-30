using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Shared
{
    public interface IReadOnlyBaseBaseObjectPool
    {
        ISharedBaseObject GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId);
        ISharedBaseObject GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType);
        ISharedBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}