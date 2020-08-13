using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Refs
{
    public readonly struct VoiceChannelRef : IDisposable
    {
        private readonly IVoiceChannel voiceChannel;

        public bool Exists => voiceChannel != null;

        public VoiceChannelRef(IVoiceChannel voiceChannel)
        {
            this.voiceChannel = voiceChannel.AddRef() ? voiceChannel : null;
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