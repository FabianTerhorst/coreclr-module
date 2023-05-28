using System;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities;

public class NetworkObject : Entity, INetworkObject
{
    public IntPtr NetworkObjectNativePointer { get; private set; }
    public override IntPtr NativePointer => NetworkObjectNativePointer;

    private static IntPtr GetEntityPointer(ICore core, IntPtr pointer)
    {
        unsafe
        {
            return core.Library.Shared.NetworkObject_GetEntity(pointer);
        }
    }

    public static uint GetId(IntPtr pointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.NetworkObject_GetID(pointer);
        }
    }

    public NetworkObject(ICore core, IntPtr nativePointer, uint id) : base(core, GetEntityPointer(core, nativePointer), BaseObjectType.NetworkObject, id)
    {
        this.NetworkObjectNativePointer = nativePointer;
    }

    public override uint Model
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Entity_GetModel(EntityNativePointer);
            }
        }
        set => throw new NotImplementedException("network object doesn't support set model");
    }

    public byte Alpha
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.NetworkObject_GetAlpha(NetworkObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.NetworkObject_SetAlpha(NetworkObjectNativePointer, value);
            }
        }
    }

    public ushort LodDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.NetworkObject_GetLodDistance(NetworkObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.NetworkObject_SetLodDistance(NetworkObjectNativePointer, value);
            }
        }
    }

    public void PlaceOnGroundProperly()
    {
        unsafe
        {
            CheckIfEntityExists();
            Core.Library.Server.NetworkObject_PlaceOnGroundProperly(NetworkObjectNativePointer);
        }
    }

    public void ActivatePhysics()
    {
        unsafe
        {
            CheckIfEntityExists();
            Core.Library.Server.NetworkObject_ActivatePhysics(NetworkObjectNativePointer);
        }
    }

    public byte TextureVariation
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.NetworkObject_GetTextureVariation(NetworkObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.NetworkObject_SetTextureVariation(NetworkObjectNativePointer, value);
            }
        }
    }

    public override void SetCached(IntPtr cachedNetworkObject)
    {
        this.NetworkObjectNativePointer = cachedNetworkObject;
        base.SetCached(GetEntityPointer(Core, cachedNetworkObject));
    }
}