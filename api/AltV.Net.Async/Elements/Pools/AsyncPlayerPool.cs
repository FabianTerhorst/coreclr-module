using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncPlayerPool : AsyncEntityPool<IPlayer>
    {
        public AsyncPlayerPool(IEntityFactory<IPlayer> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Player.GetId(entityPointer)).Result;
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IPlayer> asyncBaseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                if (!entity.Exists) continue;
                await asyncBaseObjectCallback.OnBaseObject(entity);
            }
        }

        public override void ForEach(IBaseObjectCallback<IPlayer> baseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                if (!entity.Exists) continue;
                baseObjectCallback.OnBaseObject(entity);
            }
        }
    }
}