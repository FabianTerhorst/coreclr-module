using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncBlipPool : AsyncBaseObjectPool<IBlip>
    {
        public AsyncBlipPool(IBaseObjectFactory<IBlip> entityFactory) : base(entityFactory)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IBlip> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRefRef = new BlipRef(baseObject);
                if (baseObjectRefRef.Exists)
                {
                    await asyncBaseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
        
        public override void ForEach(IBaseObjectCallback<IBlip> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRef = new BlipRef(baseObject);
                if (baseObjectRef.Exists)
                {
                    baseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
    }
}