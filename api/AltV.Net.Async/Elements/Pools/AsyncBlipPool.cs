using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncBlipPool : AsyncBaseObjectPool<IBlip>
    {
        public AsyncBlipPool(IBaseObjectFactory<IBlip> entityFactory) : base(entityFactory)
        {
        }
    }
}