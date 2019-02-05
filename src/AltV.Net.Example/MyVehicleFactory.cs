using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;

namespace AltV.Net.Example
{
    public class MyVehicleFactory : VehicleFactory
    {
        public override IVehicle Create(IntPtr vehiclePointer)
        {
            return new MyVehicle(vehiclePointer);
        }
    }
}