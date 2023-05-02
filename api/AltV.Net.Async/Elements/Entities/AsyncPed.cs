using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities;

[SuppressMessage("ReSharper",
    "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
public class AsyncPed : AsyncEntity, IPed, IAsyncConvertible<IPed>
{
    protected readonly IPed Ped;
    public IntPtr PedNativePointer => Ped.PedNativePointer;

    public AsyncPed(IPed ped, IAsyncContext asyncContext) : base(ped, asyncContext)
    {
        Ped = ped;
    }

    public AsyncPed(ICore core, IntPtr nativePointer, uint id) : this(new Ped(core, nativePointer, id),
        null)
    {
    }

    public AsyncPed(ICore core, uint model, Position position, Rotation rotation) : this(new Ped(core, model, position, rotation), null)
    {
    }

    [Obsolete("Use new async API instead")]
    public IPed ToAsync(IAsyncContext asyncContext)
    {
        return this;
    }

    public ushort Armour
    {
        get
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Ped)) return default;
                return Ped.Armour;
            }
        }
        set
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsNullable(Ped)) return;
                Ped.Armour = value;
            }
        }
    }

    public ushort Health
    {
        get
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Ped)) return default;
                return Ped.Health;
            }
        }
        set
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsNullable(Ped)) return;
                Ped.Health = value;
            }
        }
    }

    public ushort MaxHealth
    {
        get
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Ped)) return default;
                return Ped.MaxHealth;
            }
        }
        set
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsNullable(Ped)) return;
                Ped.MaxHealth = value;
            }
        }
    }

    public uint CurrentWeapon
    {
        get
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Ped)) return default;
                return Ped.CurrentWeapon;
            }
        }
        set
        {
            lock (Ped)
            {
                if (!AsyncContext.CheckIfExistsNullable(Ped)) return;
                Ped.CurrentWeapon = value;
            }
        }
    }

}