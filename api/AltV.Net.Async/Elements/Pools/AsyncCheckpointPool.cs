using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncCheckpointPool : AsyncBaseObjectPool<ICheckpoint>
    {
        public AsyncCheckpointPool(IBaseObjectFactory<ICheckpoint> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<ICheckpoint> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                await asyncBaseObjectCallback.OnBaseObject(baseObject);
            }
        }

        public override void ForEach(IBaseObjectCallback<ICheckpoint> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                baseObjectCallback.OnBaseObject(baseObject);
            }
        }
    }
}