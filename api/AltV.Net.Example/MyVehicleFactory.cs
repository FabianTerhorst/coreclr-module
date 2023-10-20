using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(ICore core, IntPtr vehiclePointer, uint id)
        {
            return new MyVehicle(core, vehiclePointer, id);
        }
    }
}