using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class VehiclePool : EntityPool<IVehicle>
    {
        public VehiclePool(IEntityFactory<IVehicle> vehicleFactory) : base(vehicleFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Vehicle_GetID(entityPointer);
            }
        }
    }
}