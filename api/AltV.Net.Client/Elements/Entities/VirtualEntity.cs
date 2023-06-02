using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities;

public class VirtualEntity : WorldObject, IVirtualEntity
{
    public IntPtr VirtualEntityNativePointer { get; }
    public override IntPtr NativePointer => VirtualEntityNativePointer;

    public static IntPtr GetWorldObjectPointer(ICore core, IntPtr virtualEntityNativePointer)
    {
        unsafe
        {
            return core.Library.Shared.VirtualEntity_GetWorldObject(virtualEntityNativePointer);
        }
    }

    public VirtualEntity(ICore core, IntPtr virtualEntityNativePointer, uint id) : base(core, GetWorldObjectPointer(core, virtualEntityNativePointer), BaseObjectType.VirtualEntity, id)
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
                return (ISharedVirtualEntityGroup)Core.PoolManager.Get(groupPointer, BaseObjectType.VirtualEntity);
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

    public bool GetStreamSyncedMetaData(string key, out int result)
    {
        CheckIfEntityExists();
        GetStreamSyncedMetaData(key, out MValueConst mValue);
        using (mValue)
        {
            if (mValue.type != MValueConst.Type.Int)
            {
                result = default;
                return false;
            }

            result = (int) mValue.GetInt();
        }

        return true;
    }

    public bool GetStreamSyncedMetaData(string key, out uint result)
    {
        CheckIfEntityExists();
        GetStreamSyncedMetaData(key, out MValueConst mValue);
        using (mValue)
        {
            if (mValue.type != MValueConst.Type.Uint)
            {
                result = default;
                return false;
            }

            result = (uint) mValue.GetUint();
        }

        return true;
    }

    public bool GetStreamSyncedMetaData(string key, out float result)
    {
        CheckIfEntityExists();
        GetStreamSyncedMetaData(key, out MValueConst mValue);
        using (mValue)
        {
            if (mValue.type != MValueConst.Type.Double)
            {
                result = default;
                return false;
            }

            result = (float) mValue.GetDouble();
        }

        return true;
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

    public uint StreamingDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.VirtualEntity_GetStreamingDistance(VirtualEntityNativePointer);
            }
        }
    }

    public bool Visible
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.VirtualEntity_IsVisible(VirtualEntityNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.VirtualEntity_SetVisible(VirtualEntityNativePointer, value ? (byte)1:(byte)0);
            }
        }
    }
}