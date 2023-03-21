using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities;

public class AsyncPed : AsyncEntity, IPed, IAsyncConvertible<IPed>
{
    protected readonly IPed Ped;
    public IntPtr PedNativePointer => Ped.PedNativePointer;

    public AsyncPed(IPed ped, IAsyncContext asyncContext) : base(ped, asyncContext)
    {
        Ped = ped;
    }

    public AsyncPed(ICore core, IntPtr nativePointer, ushort id) : this(new Ped(core, nativePointer, id),
        null)
    {
    }

    public AsyncPed(ICore core, uint model, Position position, Rotation rotation) : this(
        core, core.CreateVehicleEntity(out var id, model, position, rotation), id)
    {
        Alt.Core.PedPool.Add(this);
    }

    [Obsolete("Use new async API instead")]
    public IPed ToAsync(IAsyncContext asyncContext)
    {
        return this;
    }
}