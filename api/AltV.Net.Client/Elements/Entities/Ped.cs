using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class Ped : Entity, IPed
{
    private static IntPtr GetEntityPointer(ICore core, IntPtr pedNativePointer)
    {
        unsafe
        {
            return core.Library.Shared.Ped_GetEntity(pedNativePointer);
        }
    }

    public IntPtr PedNativePointer { get; private set; }
    public override IntPtr NativePointer => PedNativePointer;

    public Ped(ICore core, IntPtr vehiclePointer, ushort id) : base(core, GetEntityPointer(core, vehiclePointer), id, BaseObjectType.Ped)
    {
        PedNativePointer = vehiclePointer;
    }
}