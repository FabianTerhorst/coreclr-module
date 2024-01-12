using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;
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

    public bool GetStreamSyncedMetaData<T>(string key, out T result)
    {
        CheckIfEntityExists();
        GetStreamSyncedMetaData(key, out MValueConst mValue);
        using (mValue)
        {

            try
            {
                result = (T)Convert.ChangeType(mValue.ToObject(), typeof(T));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
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

    public void SetStreamSyncedMetaData(Dictionary<string, object> metaData)
    {
        unsafe
        {
            var dataTemp = new Dictionary<IntPtr, MValueConst>();

            var keys = new IntPtr[metaData.Count];
            var values = new IntPtr[metaData.Count];

            for (var i = 0; i < metaData.Count; i++)
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(metaData.ElementAt(i).Key);
                Core.CreateMValue(out var mValue, metaData.ElementAt(i).Value);
                keys[i] = stringPtr;
                values[i] = mValue.nativePointer;
                dataTemp.Add(stringPtr, mValue);
            }

            Core.Library.Server.VirtualEntity_SetMultipleStreamSyncedMetaData(VirtualEntityNativePointer, keys, values, (uint)dataTemp.Count);

            foreach (var dataValue in dataTemp)
            {
                dataValue.Value.Dispose();
                Marshal.FreeHGlobal(dataValue.Key);
            }
        }
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