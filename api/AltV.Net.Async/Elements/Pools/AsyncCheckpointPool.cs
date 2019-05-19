using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncCheckpointPool : AsyncBaseObjectPool<ICheckpoint>
    {
        public AsyncCheckpointPool(IBaseObjectFactory<ICheckpoint> entityFactory) : base(entityFactory)
        {
        }
    }
}