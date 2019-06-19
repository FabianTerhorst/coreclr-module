using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncColShapePool : AsyncBaseObjectPool<IColShape>
    {
        public AsyncColShapePool(IBaseObjectFactory<IColShape> entityFactory) : base(entityFactory)
        {
        }
    }
}