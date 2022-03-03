using System.Diagnostics.Tracing;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class VehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(ICore core, IntPtr vehiclePointer, ushort id)
        {
            return new Vehicle(core, vehiclePointer, id);
        }
    }
}