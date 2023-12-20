using System;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities;

public class Object : Entity, IObject
{
    public IntPtr ObjectNativePointer { get; private set; }

    private static IntPtr GetEntityPointer(ICore core, IntPtr pointer)
    {
        unsafe
        {
            return core.Library.Shared.Object_GetEntity(pointer);
        }
    }

    public static uint GetId(IntPtr pointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Object_GetID(pointer);
        }
    }

    public Object(ICore core, IntPtr nativePointer, uint id) : base(core, GetEntityPointer(core, nativePointer), BaseObjectType.Object, id)
    {
        this.ObjectNativePointer = nativePointer;
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
                return Core.Library.Shared.Object_GetAlpha(ObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Object_SetAlpha(ObjectNativePointer, value);
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
                return Core.Library.Shared.Object_GetLodDistance(ObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Object_SetLodDistance(ObjectNativePointer, value);
            }
        }
    }

    public void PlaceOnGroundProperly()
    {
        unsafe
        {
            CheckIfEntityExists();
            Core.Library.Server.Object_PlaceOnGroundProperly(ObjectNativePointer);
        }
    }

    public void ActivatePhysics()
    {
        unsafe
        {
            CheckIfEntityExists();
            Core.Library.Server.Object_ActivatePhysics(ObjectNativePointer);
        }
    }

    public byte TextureVariation
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Object_GetTextureVariation(ObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Object_SetTextureVariation(ObjectNativePointer, value);
            }
        }
    }

    public override void SetCached(IntPtr cachedNetworkObject)
    {
        this.ObjectNativePointer = cachedNetworkObject;
        base.SetCached(GetEntityPointer(Core, cachedNetworkObject));
    }
}