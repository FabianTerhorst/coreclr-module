using System;
using System.Threading.Tasks;
using AltV.Net.Async.Elements.Refs;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncPlayerPool : AsyncEntityPool<IPlayer>
    {
        public AsyncPlayerPool(IEntityFactory<IPlayer> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Player.GetId(entityPointer)).Result;
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IPlayer> asyncBaseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                using var entityRef = new AsyncPlayerRef(entity);
                if (!entityRef.Exists) continue;
                entityRef.DebugCountUp();
                await asyncBaseObjectCallback.OnBaseObject(entity);
                entityRef.DebugCountDown();
            }
        }

        public override void ForEach(IBaseObjectCallback<IPlayer> baseObjectCallback)
        {
            foreach (var entity in GetAllEntities())
            {
                using var entityRef = new PlayerRef(entity);
                if (!entityRef.Exists) continue;
                entityRef.DebugCountUp();
                baseObjectCallback.OnBaseObject(entity);
                entityRef.DebugCountDown();
            }
        }
    }
}