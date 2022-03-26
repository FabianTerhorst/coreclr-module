using AltV.Net.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedBaseObject : IRefCountable
    {
        IntPtr BaseObjectNativePointer { get; }
        
        BaseObjectType Type { get; }
    }
}