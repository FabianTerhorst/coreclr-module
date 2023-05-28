using System;

namespace AltV.Net.Elements.Entities;

public class VirtualEntityGroup : BaseObject, IVirtualEntityGroup
{
    public IntPtr VirtualEntityGroupNativePointer { get; }
    public override IntPtr NativePointer => VirtualEntityGroupNativePointer;

    private static IntPtr GetBaseObjectPointer(ICore core, IntPtr virtualEntityGroupNativePointer)
    {
        unsafe
        {
            return core.Library.Shared.VirtualEntityGroup_GetBaseObject(virtualEntityGroupNativePointer);
        }
    }

    public static uint GetId(IntPtr pedPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.VirtualEntityGroup_GetID(pedPointer);
        }
    }

    public VirtualEntityGroup(ICore core, IntPtr nativePointer, uint id) : base(core, GetBaseObjectPointer(core, nativePointer), BaseObjectType.VirtualEntityGroup, id)
    {
        VirtualEntityGroupNativePointer = nativePointer;
    }

    public uint MaxEntitiesInStream
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.VirtualEntityGroup_GetMaxEntitiesInStream(VirtualEntityGroupNativePointer);
            }
        }

    }
}