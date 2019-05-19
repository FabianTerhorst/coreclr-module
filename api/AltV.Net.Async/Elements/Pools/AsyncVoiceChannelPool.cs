using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncVoiceChannelPool : AsyncBaseObjectPool<IVoiceChannel>
    {
        public AsyncVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> entityFactory) : base(entityFactory)
        {
        }
    }
}