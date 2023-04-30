using System;

namespace AltV.Net.Elements.Entities;

public class VirtualEntityGroup : BaseObject, IVirtualEntityGroup
{
    public IntPtr VirtualEntityGroupNativePointer { get; }
    public override IntPtr NativePointer => VirtualEntityGroupNativePointer;

    private static IntPtr GetEntityPointer(ICore core, IntPtr virtualEntityGroupNativePointer)
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

    public VirtualEntityGroup(ICore core, uint streamingDistance) : this(
        core, core.CreateVirtualEntityGroupEntity(out var id, streamingDistance), id)
    {
        core.PoolManager.VirtualEntityGroup.Add(this);
    }

    public VirtualEntityGroup(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, BaseObjectType.VirtualEntityGroup, id)
    {
        VirtualEntityGroupNativePointer = nativePointer;
    }

    public uint StreamingRangeLimit
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.VirtualEntityGroup_GetStreamingRangeLimit(VirtualEntityGroupNativePointer);
            }
        }

    }
}