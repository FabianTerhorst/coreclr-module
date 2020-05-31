using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;

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

        public override async Task Foreach(IAsyncBaseObjectCallback<IVehicle> asyncBaseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                using var entityRef = new VehicleRef(entity);
                if (entityRef.Exists)
                {
                    await asyncBaseObjectCallback.OnBaseObject(entity);
                }
            }
        }

        public override void Foreach(IBaseObjectCallback<IVehicle> baseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                using var entityRef = new VehicleRef(entity);
                if (entityRef.Exists)
                {
                    baseObjectCallback.OnBaseObject(entity);
                }
            }
        }
    }
}