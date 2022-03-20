using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Shared
{
    public interface IReadOnlyBaseBaseObjectPool
    {
        ISharedBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}