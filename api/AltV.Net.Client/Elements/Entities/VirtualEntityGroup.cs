using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class VirtualEntityGroup : BaseObject, IVirtualEntityGroup
{

    public IntPtr VirtualEntityGroupNativePointer { get; }
    public override IntPtr NativePointer => VirtualEntityGroupNativePointer;

    public static IntPtr GetBaseObjectNativePointer(ICore core, IntPtr virtualEntityGroupNativePointer)
    {
        unsafe
        {
            return core.Library.Client.VirtualEntity_GetBaseObject(virtualEntityGroupNativePointer);
        }
    }

    public VirtualEntityGroup(ICore core, IntPtr virtualEntityGroupNativePointer) : base(core, GetBaseObjectNativePointer(core, virtualEntityGroupNativePointer), BaseObjectType.VirtualEntityGroup)
    {
        VirtualEntityGroupNativePointer = virtualEntityGroupNativePointer;
    }

    public uint Id
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.VirtualEntityGroup_GetID(VirtualEntityGroupNativePointer);
            }
        }
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