using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockVehiclePool : VehiclePool
    {
        public MockVehiclePool(IEntityFactory<IVehicle> vehicleFactory) : base(vehicleFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return 0;
        }
    }
}