using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class VoiceChannelPool : BaseObjectPool<IVoiceChannel>
    {
        public VoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory) : base(voiceChannelFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.VoiceChannel_GetID(entityPointer);
            }
        }
    }
}