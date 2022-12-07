using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncBlipPool : AsyncBaseObjectPool<IBlip>
    {
        public AsyncBlipPool(IBaseObjectFactory<IBlip> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IBlip> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (baseObject.Exists)
                {
                    await asyncBaseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
        
        public override void ForEach(IBaseObjectCallback<IBlip> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (baseObject.Exists)
                {
                    baseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
    }
}