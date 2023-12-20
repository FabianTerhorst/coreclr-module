using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class LocalObject : Object, ILocalObject
{
    private static IntPtr GetObjectPointer(ICore core, IntPtr LocalObjectNativePointer)
    {
        unsafe
        {
            return core.Library.Client.LocalObject_GetObject(LocalObjectNativePointer);
        }
    }

    public IntPtr LocalObjectNativePointer { get; }

    public LocalObject(ICore core, IntPtr objectPointer, uint id) : base(core, GetObjectPointer(core, objectPointer), BaseObjectType.LocalObject, id)
    {
        LocalObjectNativePointer = objectPointer;
    }

    public static uint GetId(IntPtr objectPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Client.LocalObject_GetID(objectPointer);
        }
    }

    public new uint Model
    {
        get => base.Model;
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalObject_SetModel(LocalObjectNativePointer, value);
            }
        }
    }

    public byte Alpha
    {
        get => base.Alpha;
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalObject_SetAlpha(LocalObjectNativePointer, value);
            }
        }
    }

    public void ResetAlpha()
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_ResetAlpha(LocalObjectNativePointer);
        }
    }

    public bool IsDynamic
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Client.LocalObject_IsDynamic(LocalObjectNativePointer) == 1;
            }
        }
    }

    public ushort LodDistance
    {
        get => base.LodDistance;
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Alt.Core.Library.Client.LocalObject_SetLodDistance(LocalObjectNativePointer, value);
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
                return Alt.Core.Library.Client.LocalObject_HasGravity(LocalObjectNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Alt.Core.Library.Client.LocalObject_ToggleGravity(LocalObjectNativePointer, value ? (byte)1 : (byte)0);
            }
        }
    }

    public void AttachToEntity(ISharedEntity entity, short bone, Position position, Rotation rotation, bool useSoftPinning,
        bool collision, bool fixedRotation)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_AttachToEntity(LocalObjectNativePointer, entity.EntityNativePointer, bone, position, rotation,
                useSoftPinning? (byte)1 : (byte)0, collision? (byte)1 : (byte)0, fixedRotation? (byte)1 : (byte)0);
        }
    }

    public void AttachToEntity(uint scriptId, short bone, Position position, Rotation rotation, bool useSoftPinning,
        bool collision, bool fixedRotation)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_AttachToEntity_ScriptId(LocalObjectNativePointer, scriptId, bone, position, rotation,
                useSoftPinning? (byte)1 : (byte)0, collision? (byte)1 : (byte)0, fixedRotation? (byte)1 : (byte)0);
        }
    }

    public void Detach(bool dynamic)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_Detach(LocalObjectNativePointer, dynamic ? (byte)1 : (byte)0);
        }
    }

    public bool Collision
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Client.LocalObject_IsCollisionEnabled(LocalObjectNativePointer) == 1;
            }
        }
    }

    public void ToggleCollision(bool toggle, bool keepPhysics)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_ToggleCollision(LocalObjectNativePointer, toggle ? (byte) 1 : (byte) 0,
                keepPhysics ? (byte) 1 : (byte) 0);
        }
    }

    public void PlaceOnGroundProperly()
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_PlaceOnGroundProperly(LocalObjectNativePointer);
        }
    }

    public void SetPositionFrozen(bool state)
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_SetPositionFrozen(LocalObjectNativePointer, state ? (byte)1:(byte)0);
        }
    }

    public void ActivatePhysics()
    {
        unsafe
        {
            CheckIfEntityExists();
            Alt.Core.Library.Client.LocalObject_ActivatePhysics(LocalObjectNativePointer);
        }
    }

    public byte TextureVariation
    {
        get => base.TextureVariation;
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Alt.Core.Library.Client.LocalObject_SetTextureVariation(LocalObjectNativePointer, value);
            }
        }
    }

    public bool IsWorldObject
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Client.LocalObject_IsWorldObject(LocalObjectNativePointer) == 1;
            }
        }
    }

    public uint StreamingDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Client.LocalObject_GetStreamingDistance(LocalObjectNativePointer);
            }
        }
    }

    public bool IsStreamedIn
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Client.LocalObject_IsStreamedIn(LocalObjectNativePointer) == 1;
            }
        }
    }

    public bool UsesStreaming
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Alt.Core.Library.Client.LocalObject_UsesStreaming(LocalObjectNativePointer) == 1;
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
                return Core.Library.Client.LocalObject_IsVisible(LocalObjectNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalObject_SetVisible(LocalObjectNativePointer, value ? (byte)1:(byte)0);
            }
        }
    }
}