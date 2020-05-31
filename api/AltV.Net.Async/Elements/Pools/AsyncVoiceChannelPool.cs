using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncVoiceChannelPool : AsyncBaseObjectPool<IVoiceChannel>
    {
        public AsyncVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> entityFactory) : base(entityFactory)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IVoiceChannel> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRefRef = new VoiceChannelRef(baseObject);
                if (baseObjectRefRef.Exists)
                {
                    await asyncBaseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
        
        public override void ForEach(IBaseObjectCallback<IVoiceChannel> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                using var baseObjectRef = new VoiceChannelRef(baseObject);
                if (baseObjectRef.Exists)
                {
                    baseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
    }
}