using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities;

public class VirtualEntity : WorldObject, IVirtualEntity
{
    public IntPtr VirtualEntityNativePointer { get; }
    public override IntPtr NativePointer => VirtualEntityNativePointer;

    public static IntPtr GetBaseObjectNativePointer(ICore core, IntPtr virtualEntityNativePointer)
    {
        unsafe
        {
            return core.Library.Client.VirtualEntity_GetBaseObject(virtualEntityNativePointer);
        }
    }

    public VirtualEntity(ICore core, IntPtr virtualEntityNativePointer) : base(core, GetBaseObjectNativePointer(core, virtualEntityNativePointer), BaseObjectType.VirtualEntity)
    {
        VirtualEntityNativePointer = virtualEntityNativePointer;
    }

    public uint Id
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.VirtualEntity_GetID(VirtualEntityNativePointer);
            }
        }
    }

    public ISharedVirtualEntityGroup Group
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var groupPointer = Core.Library.Shared.VirtualEntity_GetGroup(VirtualEntityNativePointer);
                if (groupPointer == IntPtr.Zero) return null;
                return (ISharedVirtualEntityGroup)Core.BaseBaseObjectPool.Get(groupPointer, BaseObjectType.VirtualEntity);
            }
        }
    }

    public bool HasStreamSyncedMetaData(string key)
    {
        unsafe
        {
            CheckIfEntityExists();
            var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
            var result = Core.Library.Shared.VirtualEntity_HasStreamSyncedMetaData(VirtualEntityNativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result == 1;
        }
    }

    public bool GetStreamSyncedMetaData<T>(string key, out T result)
    {
        CheckIfEntityExists();
        GetStreamSyncedMetaData(key, out MValueConst mValue);
        var obj = mValue.ToObject();
        mValue.Dispose();
        if (!(obj is T cast))
        {
            result = default;
            return false;
        }

        result = cast;
        return true;
    }

    public void GetStreamSyncedMetaData(string key, out MValueConst value)
    {
        CheckIfEntityExists();
        unsafe
        {
            var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(Core, Core.Library.Shared.VirtualEntity_GetStreamSyncedMetaData(VirtualEntityNativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }
    }

    public ulong RemoteId
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.VirtualEntity_GetRemoteID(VirtualEntityNativePointer);
            }
        }
    }
}