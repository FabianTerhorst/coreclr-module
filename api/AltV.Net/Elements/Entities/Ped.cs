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

    public static uint GetId(IntPtr pedPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Ped_GetID(pedPointer);
        }
    }

    public Ped(ICore core, IntPtr nativePointer, uint id) : base(core, GetEntityPointer(core, nativePointer), BaseObjectType.Ped, id)
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

    public ushort Armour
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetArmour(PedNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Ped_SetArmour(PedNativePointer, value);
            }
        }
    }

    public ushort Health
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetHealth(PedNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Ped_SetHealth(PedNativePointer, value);
            }
        }
    }

    public ushort MaxHealth
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetMaxHealth(PedNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Ped_SetMaxHealth(PedNativePointer, value);
            }
        }
    }

    public uint CurrentWeapon
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetCurrentWeapon(PedNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Ped_SetCurrentWeapon(PedNativePointer, value);
            }
        }
    }

    public override void SetCached(IntPtr cachedPed)
    {
        this.PedNativePointer = cachedPed;
        base.SetCached(GetEntityPointer(Core, cachedPed));
    }
}