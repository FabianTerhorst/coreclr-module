using System.Numerics;
using AltV.Net.Data;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedVirtualEntityGroup : ISharedBaseObject
    {
        IntPtr VirtualEntityGroupNativePointer { get; }

        uint Id { get; }

        uint MaxEntitiesInStream { get; }
    }
}