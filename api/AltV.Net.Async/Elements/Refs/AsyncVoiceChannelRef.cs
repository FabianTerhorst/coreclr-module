using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncVoiceChannelRef : IDisposable
    {
        private readonly IVoiceChannel voiceChannel;

        public bool Exists => voiceChannel != null;

        public AsyncVoiceChannelRef(IVoiceChannel voiceChannel)
        {
            if (voiceChannel == null)
            {
                this.voiceChannel = null;
            }
            else
            {
                lock (voiceChannel)
                {
                    this.voiceChannel = voiceChannel.AddRef() ? voiceChannel : null;
                }
            }
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.Module.CountUpRefForCurrentThread(voiceChannel);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.Module.CountDownRefForCurrentThread(voiceChannel);
        }

        public void Dispose()
        {
            voiceChannel?.RemoveRef();
        }
    }
}