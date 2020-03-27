using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncVoiceChannelRef : IDisposable
    {
        private readonly IVoiceChannel voiceChannel;

        public bool Exists => voiceChannel != null;

        public AsyncVoiceChannelRef(IVoiceChannel voiceChannel)
        {
            lock (voiceChannel)
            {
                if (voiceChannel.Exists)
                {
                    this.voiceChannel = voiceChannel.AddRef() ? voiceChannel : null;
                    Alt.Module.CountUpRefForCurrentThread(voiceChannel);
                }
                else
                {
                    this.voiceChannel = null;
                }
            }
        }

        public void Dispose()
        {
            if (voiceChannel == null) return;
            lock (voiceChannel)
            {
                if (voiceChannel.Exists)
                {
                    voiceChannel.RemoveRef();
                }
            }

            Alt.Module.CountDownRefForCurrentThread(voiceChannel);
        }
    }
}