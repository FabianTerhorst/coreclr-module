using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public virtual IVehicle Create(IntPtr vehiclePointer)
        {
            return new Vehicle(vehiclePointer);
        }
    }
}