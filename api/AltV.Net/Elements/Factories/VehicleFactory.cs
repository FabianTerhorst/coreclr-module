using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class VehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(ICore core, IntPtr vehiclePointer, uint id)
        {
            return new Vehicle(core, vehiclePointer, id);
        }
    }
}