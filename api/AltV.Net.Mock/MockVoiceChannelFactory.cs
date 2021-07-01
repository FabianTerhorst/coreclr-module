using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVoiceChannelFactory<TEntity> : IBaseObjectFactory<IVoiceChannel> where TEntity : IVoiceChannel
    {
        private readonly IBaseObjectFactory<IVoiceChannel> voiceChannelFactory;

        public MockVoiceChannelFactory(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory)
        {
            this.voiceChannelFactory = voiceChannelFactory;
        }

        public IVoiceChannel Create(IServer server, IntPtr entityPointer)
        {
            return MockDecorator<TEntity, IVoiceChannel>.Create((TEntity) voiceChannelFactory.Create(server, entityPointer),
                new MockVoiceChannel(server, entityPointer));
        }
    }
}