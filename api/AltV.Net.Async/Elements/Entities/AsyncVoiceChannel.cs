using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    //TODO: later test unrestricting the methods to main thread since they are thread safe in core
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVoiceChannel<TVoiceChannel> : AsyncBaseObject<TVoiceChannel>, IVoiceChannel where TVoiceChannel: class, IVoiceChannel
    {
        public IntPtr VoiceChannelNativePointer => BaseObject.VoiceChannelNativePointer;
        
        public bool IsSpatial
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsSpatial;
                }
            }
        }

        public float MaxDistance
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.MaxDistance;
                }
            }
        }

        public AsyncVoiceChannel(TVoiceChannel voiceChannel, IAsyncContext asyncContext) : base(voiceChannel,
            asyncContext)
        {
        }

        public void AddPlayer(IPlayer player)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.AddPlayer(player);
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.RemovePlayer(player);
            }
        }

        public void MutePlayer(IPlayer player)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.MutePlayer(player);
            }
        }

        public void UnmutePlayer(IPlayer player)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.UnmutePlayer(player);
            }
        }

        public bool HasPlayer(IPlayer player)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.HasPlayer(player);
            }
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.IsPlayerMuted(player);
            }
        }

        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlockingNullable(() => BaseObject.Remove());
        }
    }
}