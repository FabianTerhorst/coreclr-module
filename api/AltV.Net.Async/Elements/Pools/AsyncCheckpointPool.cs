using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncCheckpointPool : AsyncBaseObjectPool<ICheckpoint>
    {
        public AsyncCheckpointPool(IBaseObjectFactory<ICheckpoint> entityFactory) : base(entityFactory)
        {
        }
        
        public override async Task ForEach(IAsyncBaseObjectCallback<ICheckpoint> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRefRef = new CheckpointRef(baseObject);
                if (baseObjectRefRef.Exists)
                {
                    await asyncBaseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
        
        public override void ForEach(IBaseObjectCallback<ICheckpoint> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRef = new CheckpointRef(baseObject);
                if (baseObjectRef.Exists)
                {
                    baseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
    }
}