using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Elements.Entities;

public class VirtualEntity : WorldObject, IVirtualEntity
{
    public IntPtr VirtualEntityNativePointer { get; }
    public override IntPtr NativePointer => VirtualEntityNativePointer;

    private static IntPtr GetWorldObjectPointer(ICore core, IntPtr virtualEntityNativePointer)
    {
        unsafe
        {
            return core.Library.Shared.VirtualEntity_GetWorldObject(virtualEntityNativePointer);
        }
    }

    public static uint GetId(IntPtr pedPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.VirtualEntity_GetID(pedPointer);
        }
    }

    public VirtualEntity(ICore core, IntPtr nativePointer, uint id) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.VirtualEntity, id)
    {
        this.VirtualEntityNativePointer = nativePointer;
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
                return Core.PoolManager.VirtualEntityGroup.Get(groupPointer);
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

    public void SetStreamSyncedMetaData(string key, object value)
    {
        CheckIfEntityExists();
        Alt.Core.CreateMValue(out var mValue, value);
        SetStreamSyncedMetaData(key, in mValue);
        mValue.Dispose();
    }

    public void SetStreamSyncedMetaData(string key, in MValueConst value)
    {
        unsafe
        {
            var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
            Core.Library.Server.VirtualEntity_SetStreamSyncedMetaData(VirtualEntityNativePointer, stringPtr, value.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
        }
    }

    public void DeleteStreamSyncedMetaData(string key)
    {
        CheckIfEntityExists();
        unsafe
        {
            var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
            Core.Library.Server.VirtualEntity_DeleteStreamSyncedMetaData(VirtualEntityNativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }
    }
}