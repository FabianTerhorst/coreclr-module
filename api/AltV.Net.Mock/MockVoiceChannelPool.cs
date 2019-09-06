using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockVoiceChannelPool : VoiceChannelPool
    {
        public MockVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory) : base(voiceChannelFactory)
        {
        }

        public override void OnRemove(IVoiceChannel entity)
        {
            MockEntities.FreeNoId(entity.NativePointer);
        }
    }
}