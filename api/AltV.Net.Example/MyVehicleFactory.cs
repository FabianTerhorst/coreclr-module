using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IServer server, IntPtr vehiclePointer, ushort id)
        {
            return new MyVehicle(server, vehiclePointer, id);
        }
    }
}