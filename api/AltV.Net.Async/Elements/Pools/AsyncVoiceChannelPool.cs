using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncVoiceChannelPool : AsyncBaseObjectPool<IVoiceChannel>
    {
        public AsyncVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IVoiceChannel> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                await asyncBaseObjectCallback.OnBaseObject(baseObject);
            }
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => VoiceChannel.GetId(entityPointer)).Result;
        }

        public override void ForEach(IBaseObjectCallback<IVoiceChannel> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                baseObjectCallback.OnBaseObject(baseObject);
            }
        }
    }
}