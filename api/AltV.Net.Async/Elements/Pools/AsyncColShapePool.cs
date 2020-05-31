using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncColShapePool : AsyncBaseObjectPool<IColShape>
    {
        public AsyncColShapePool(IBaseObjectFactory<IColShape> entityFactory) : base(entityFactory)
        {
        }
        
        public override async Task Foreach(IAsyncBaseObjectCallback<IColShape> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRefRef = new ColShapeRef(baseObject);
                if (baseObjectRefRef.Exists)
                {
                    await asyncBaseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
        
        public override void Foreach(IBaseObjectCallback<IColShape> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRef = new ColShapeRef(baseObject);
                if (baseObjectRef.Exists)
                {
                    baseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
    }
}