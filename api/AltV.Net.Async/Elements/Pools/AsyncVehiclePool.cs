using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncVehiclePool : AsyncEntityPool<IVehicle>
    {
        public AsyncVehiclePool(IEntityFactory<IVehicle> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Vehicle.GetId(entityPointer)).Result;
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IVehicle> asyncBaseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                if (!entity.Exists) continue;
                await asyncBaseObjectCallback.OnBaseObject(entity);
            }
        }

        public override void ForEach(IBaseObjectCallback<IVehicle> baseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                if (!entity.Exists) continue;
                baseObjectCallback.OnBaseObject(entity);
            }
        }
    }
}