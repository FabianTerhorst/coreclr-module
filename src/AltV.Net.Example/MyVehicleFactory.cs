using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IntPtr vehiclePointer)
        {
            return new MyVehicle(vehiclePointer);
        }
    }
}