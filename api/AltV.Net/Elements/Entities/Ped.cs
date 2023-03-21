using System;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities;

public class Ped : Entity, IPed
{
    public IntPtr PedNativePointer { get; private set; }
    public override IntPtr NativePointer => PedNativePointer;

    private static IntPtr GetEntityPointer(ICore core, IntPtr pedPointer)
    {
        unsafe
        {
            return core.Library.Shared.Ped_GetEntity(pedPointer);
        }
    }

    public static ushort GetId(IntPtr pedPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Ped_GetID(pedPointer);
        }
    }

    public Ped(ICore core, uint model, Position position, Rotation rotation) : this(
        core, core.CreatePedEntity(out var id, model, position, rotation), id)
    {
        Alt.Core.PedPool.Add(this);
    }

    public Ped(ICore core, IntPtr nativePointer, ushort id) : base(core, GetEntityPointer(core, nativePointer), BaseObjectType.Ped, id)
    {
        this.PedNativePointer = nativePointer;
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
        set => throw new NotImplementedException("ped doesn't support set model");
    }

    public override void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation,
        bool collision, bool noFixedRotation)
    {
        unsafe
        {
            CheckIfEntityExists();
            if(entity == null) return;
            entity.CheckIfEntityExists();

            Core.Library.Server.Ped_AttachToEntity(PedNativePointer, entity.EntityNativePointer, otherBone, ownBone, position, rotation, collision ? (byte) 1 : (byte) 0, noFixedRotation ? (byte) 1 : (byte) 0);
        }
    }

    public override void AttachToEntity(IEntity entity, string otherBone, string ownBone, Position position, Rotation rotation,
        bool collision, bool noFixedRotation)
    {
        unsafe
        {
            CheckIfEntityExists();
            if(entity == null) return;
            entity.CheckIfEntityExists();

            var otherBonePtr = AltNative.StringUtils.StringToHGlobalUtf8(otherBone);
            var ownBonePtr = AltNative.StringUtils.StringToHGlobalUtf8(ownBone);
            Core.Library.Server.Ped_AttachToEntity_BoneString (PedNativePointer, entity.EntityNativePointer, otherBonePtr, ownBonePtr, position, rotation, collision ? (byte) 1 : (byte) 0, noFixedRotation ? (byte) 1 : (byte) 0);
        }
    }

    public override void Detach()
    {
        unsafe
        {
            CheckIfEntityExists();
            Core.Library.Server.Vehicle_Detach(PedNativePointer);
        }
    }
}