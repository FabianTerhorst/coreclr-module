using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncColShapePool : AsyncBaseObjectPool<IColShape>
    {
        public AsyncColShapePool(IBaseObjectFactory<IColShape> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IColShape> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                await asyncBaseObjectCallback.OnBaseObject(baseObject);
            }
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => ColShape.GetId(entityPointer)).Result;
        }

        public override void ForEach(IBaseObjectCallback<IColShape> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                baseObjectCallback.OnBaseObject(baseObject);
            }
        }
    }
}