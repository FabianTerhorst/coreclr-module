using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities;

public class AsyncNetworkObject : AsyncEntity, INetworkObject, IAsyncConvertible<INetworkObject>
{
    protected readonly INetworkObject NetworkObject;
    public IntPtr NetworkObjectNativePointer => NetworkObject.NetworkObjectNativePointer;

    public AsyncNetworkObject(IEntity entity, IAsyncContext asyncContext) : base(entity, asyncContext)
    {
    }

    public AsyncNetworkObject(ICore core, IntPtr nativePointer, uint id) : this(new NetworkObject(core, nativePointer, id),
        null)
    {
    }

    public AsyncNetworkObject(ICore core, uint model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100) : this(
        core, core.CreateNetworkObjectEntity(out var id, model, position, rotation, alpha, textureVariation, lodDistance), id)
    {
        core.PoolManager.NetworkObject.Add(this);
    }

    public byte Alpha
    {
        get
        {
            lock (NetworkObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(NetworkObject)) return default;
                return NetworkObject.Alpha;
            }
        }
        set
        {
            lock (NetworkObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(NetworkObject)) return;
                NetworkObject.Alpha = value;
            }
        }
    }

    public ushort LodDistance
    {
        get
        {
            lock (NetworkObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(NetworkObject)) return default;
                return NetworkObject.LodDistance;
            }
        }
        set
        {
            lock (NetworkObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(NetworkObject)) return;
                NetworkObject.LodDistance = value;
            }
        }
    }

    public void PlaceOnGroundProperly()
    {
        lock (NetworkObject)
        {
            if (!AsyncContext.CheckIfExistsNullable(NetworkObject)) return;
            NetworkObject.PlaceOnGroundProperly();
        }
    }

    public void ActivatePhysics()
    {
        lock (NetworkObject)
        {
            if (!AsyncContext.CheckIfExistsNullable(NetworkObject)) return;
            NetworkObject.ActivatePhysics();
        }
    }

    public byte TextureVariation
    {
        get
        {
            lock (NetworkObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(NetworkObject)) return default;
                return NetworkObject.TextureVariation;
            }
        }
        set
        {
            lock (NetworkObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(NetworkObject)) return;
                NetworkObject.TextureVariation = value;
            }
        }
    }

    [Obsolete("Use new async API instead")]
    public INetworkObject ToAsync(IAsyncContext asyncContext)
    {
        return this;
    }
}