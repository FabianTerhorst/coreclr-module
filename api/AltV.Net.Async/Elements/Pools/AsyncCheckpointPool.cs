using System.Threading.Tasks;
using AltV.Net.Async.Elements.Refs;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;

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
                using var baseObjectRefRef = new AsyncCheckpointRef(baseObject);
                if (!baseObjectRefRef.Exists) continue;
                baseObjectRefRef.DebugCountUp();
                await asyncBaseObjectCallback.OnBaseObject(baseObject);
                baseObjectRefRef.DebugCountDown();
            }
        }

        public override void ForEach(IBaseObjectCallback<ICheckpoint> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRef = new CheckpointRef(baseObject);
                if (!baseObjectRef.Exists) continue;
                baseObjectRef.DebugCountUp();
                baseObjectCallback.OnBaseObject(baseObject);
                baseObjectRef.DebugCountDown();
            }
        }
    }
}