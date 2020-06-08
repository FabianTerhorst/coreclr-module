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
        
        public override async Task ForEach(IAsyncBaseObjectCallback<IColShape> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRefRef = new ColShapeRef(baseObject);
                if (!baseObjectRefRef.Exists) continue;
                baseObjectRefRef.DebugCountUp();
                await asyncBaseObjectCallback.OnBaseObject(baseObject);
                baseObjectRefRef.DebugCountDown();
            }
        }
        
        public override void ForEach(IBaseObjectCallback<IColShape> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRef = new ColShapeRef(baseObject);
                if (!baseObjectRef.Exists) continue;
                baseObjectRef.DebugCountUp();
                baseObjectCallback.OnBaseObject(baseObject);
                baseObjectRef.DebugCountDown();
            }
        }
    }
}