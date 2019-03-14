using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class VoiceChannelPool : BaseObjectPool<IVoiceChannel>
    {
        public VoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory) : base(voiceChannelFactory)
        {
        }
    }
}