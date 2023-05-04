using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities;

public class AsyncVirtualEntity : AsyncWorldObject, IVirtualEntity, IAsyncConvertible<IVirtualEntity>
{
    protected readonly IVirtualEntity VirtualEntity;
    public IntPtr VirtualEntityNativePointer => VirtualEntity.VirtualEntityNativePointer;
    public uint Id => VirtualEntity.Id;
    public ISharedVirtualEntityGroup Group
    {
        get
        {
            lock (VirtualEntity)
            {
                if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return default;
                return VirtualEntity.Group;
            }
        }
    }

    public bool HasStreamSyncedMetaData(string key)
    {
        lock (VirtualEntity)
        {
            if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return default;
            return VirtualEntity.HasStreamSyncedMetaData(key);
        }
    }

    public bool GetStreamSyncedMetaData<T>(string key, out T result)
    {
        lock (VirtualEntity)
        {
            if (!AsyncContext.CheckIfExistsNullable(VirtualEntity))
            {
                result = default;
                return false;
            }

            return VirtualEntity.GetStreamSyncedMetaData(key, out result);
        }
    }

    public void GetStreamSyncedMetaData(string key, out MValueConst value)
    {
        lock (VirtualEntity)
        {
            if (!AsyncContext.CheckIfExistsNullable(VirtualEntity))
            {
                value = MValueConst.Nil;
                return;
            }

            VirtualEntity.GetStreamSyncedMetaData(key, out value);
        }
    }


    public AsyncVirtualEntity(IVirtualEntity virtualEntity, IAsyncContext asyncContext) : base(virtualEntity,
        asyncContext)
    {
        VirtualEntity = virtualEntity;
    }

    public AsyncVirtualEntity(ICore core, IntPtr nativePointer, uint id) : this(new VirtualEntity(core, nativePointer, id), null)
    {
    }

    public AsyncVirtualEntity(ICore core, IVirtualEntityGroup group, Position position, uint streamingDistance, Dictionary<string, object> data) : this(
        core, core.CreateVirtualEntityEntity(out var id, group, position, streamingDistance, data), id)
    {
        core.PoolManager.VirtualEntity.Add(this);
    }

    public uint StreamingDistance
    {
        get
        {
            lock (VirtualEntity)
            {
                if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return default;
                return VirtualEntity.StreamingDistance;
            }
        }
    }
    public void SetStreamSyncedMetaData(string key, object value)
    {
        lock (VirtualEntity)
        {
            if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return;
            VirtualEntity.SetStreamSyncedMetaData(key, value);
        }
    }

    public void SetStreamSyncedMetaData(string key, in MValueConst value)
    {
        lock (VirtualEntity)
        {
            if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return;
            VirtualEntity.SetStreamSyncedMetaData(key, value);
        }
    }

    public void DeleteStreamSyncedMetaData(string key)
    {
        lock (VirtualEntity)
        {
            if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return;
            VirtualEntity.DeleteStreamSyncedMetaData(key);
        }
    }

    public bool Visible
    {
        get
        {
            lock (VirtualEntity)
            {
                if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return default;
                return VirtualEntity.Visible;
            }
        }
        set
        {
            lock (VirtualEntity)
            {
                if (!AsyncContext.CheckIfExistsNullable(VirtualEntity)) return;
                VirtualEntity.Visible = value;
            }
        }
    }

    [Obsolete("Use new async API instead")]
    public IVirtualEntity ToAsync(IAsyncContext asyncContext)
    {
        return this;
    }
}