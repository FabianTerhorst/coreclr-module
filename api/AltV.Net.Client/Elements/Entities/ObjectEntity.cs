﻿using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class ObjectEntity : Entity, IObject
{
    private static IntPtr GetEntityPointer(ICore core, IntPtr objectNativePointer)
    {
        unsafe
        {
            return core.Library.Shared.Object_GetEntity(objectNativePointer);
        }
    }
    public IntPtr ObjectNativePointer { get; }
    public override IntPtr NativePointer => ObjectNativePointer;
    
    public ObjectEntity(ICore core, IntPtr objectPointer, ushort id) : base(core, GetEntityPointer(core, objectPointer), id, BaseObjectType.Object)
    {
        ObjectNativePointer = objectPointer;
    }

    public static ushort GetId(IntPtr objectPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Object_GetID(objectPointer);
        }
    }

    public byte Alpha
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Shared.Object_GetAlpha(ObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Shared.Object_SetAlpha(ObjectNativePointer, value);
            }
        }
    }

    public void ResetAlpha()
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Shared.Object_ResetAlpha(ObjectNativePointer);
        }
    }

    public bool IsDynamic
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Shared.Object_IsDynamic(ObjectNativePointer) == 1;
            }
        }
    }

    public ushort LodDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Shared.Object_GetLodDistance(ObjectNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Alt.Core.Library.Shared.Object_SetLodDistance(ObjectNativePointer, value);
            }
        }
    }

    public bool Gravity
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Shared.Object_HasGravity(ObjectNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Alt.Core.Library.Shared.Object_ToggleGravity(ObjectNativePointer, value ? (byte)1 : (byte)0);
            }
        }
    }

    public void AttachToEntity(ISharedEntity entity, short bone, Position position, Rotation rotation, bool useSoftPinning,
        bool collision, bool fixedRotation)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Shared.Object_AttachToEntity(ObjectNativePointer, entity.EntityNativePointer, bone, position, rotation,
                useSoftPinning? (byte)1 : (byte)0, collision? (byte)1 : (byte)0, fixedRotation? (byte)1 : (byte)0);
        }
    }

    public void Detach(bool dynamic)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Shared.Object_Detach(ObjectNativePointer, dynamic ? (byte)1 : (byte)0);
        }
    }

    public bool Collision
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Shared.Object_IsCollisionEnabled(ObjectNativePointer) == 1;
            }
        }
    }

    public void ToggleCollision(bool toggle, bool keepPhysics)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Shared.Object_ToggleCollision(ObjectNativePointer, toggle ? (byte) 1 : (byte) 0,
                keepPhysics ? (byte) 1 : (byte) 0);
        }
    }

    public void PlaceOnGroundProperly()
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Shared.Object_PlaceOnGroundProperly(ObjectNativePointer);
        }
    }

    public void ActivatePhysics()
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Shared.Object_ActivatePhysics(ObjectNativePointer);
        }
    }

    public bool IsRemote
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Client.Object_IsRemote(ObjectNativePointer) == 1;
            }
        }
    }
}