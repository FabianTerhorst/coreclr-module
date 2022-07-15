using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    //TODO: later test unrestricting the methods to main thread since they are thread safe in core
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVoiceChannel : AsyncBaseObject, IVoiceChannel, IAsyncConvertible<IVoiceChannel>
    {
        protected readonly IVoiceChannel VoiceChannel;
        public IntPtr VoiceChannelNativePointer => VoiceChannel.VoiceChannelNativePointer;
        
        public bool IsSpatial
        {
            get
            {
                lock (VoiceChannel)
                {
                    if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return default;
                    return VoiceChannel.IsSpatial;
                }
            }
        }

        public float MaxDistance
        {
            get
            {
                lock (VoiceChannel)
                {
                    if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return default;
                    return VoiceChannel.MaxDistance;
                }
            }
        }

        public AsyncVoiceChannel(IVoiceChannel voiceChannel, IAsyncContext asyncContext) : base(voiceChannel,
            asyncContext)
        {
            VoiceChannel = voiceChannel;
        }

        public AsyncVoiceChannel(ICore core, IntPtr nativePointer) : this(new VoiceChannel(core, nativePointer), null)
        {
        }

        public void AddPlayer(IPlayer player)
        {
            lock (VoiceChannel)
            {
                if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return;
                VoiceChannel.AddPlayer(player);
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            lock (VoiceChannel)
            {
                if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return;
                VoiceChannel.RemovePlayer(player);
            }
        }

        public void MutePlayer(IPlayer player)
        {
            lock (VoiceChannel)
            {
                if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return;
                VoiceChannel.MutePlayer(player);
            }
        }

        public void UnmutePlayer(IPlayer player)
        {
            lock (VoiceChannel)
            {
                if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return;
                VoiceChannel.UnmutePlayer(player);
            }
        }

        public bool HasPlayer(IPlayer player)
        {
            lock (VoiceChannel)
            {
                if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return default;
                return VoiceChannel.HasPlayer(player);
            }
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            lock (VoiceChannel)
            {
                if (!AsyncContext.CheckIfExistsNullable(VoiceChannel)) return default;
                return VoiceChannel.IsPlayerMuted(player);
            }
        }
        
        public IVoiceChannel ToAsync(IAsyncContext asyncContext)
        {
            return this;
        }
    }
}