using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncVehiclePool : AsyncEntityPool<IVehicle>
    {
        public AsyncVehiclePool(IEntityFactory<IVehicle> entityFactory) : base(entityFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Vehicle.GetId(entityPointer)).Result;
        }
    }
}