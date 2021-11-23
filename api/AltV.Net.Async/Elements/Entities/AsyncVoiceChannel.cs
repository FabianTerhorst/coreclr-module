using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    //TODO: later test unrestricting the methods to main thread since they are thread safe in core
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVoiceChannel<TVoiceChannel> : AsyncBaseObject<TVoiceChannel>, IVoiceChannel where TVoiceChannel: class, IVoiceChannel
    {
        public bool IsSpatial
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsSpatial;
                }
            }
        }

        public float MaxDistance
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
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
            AsyncContext.Enqueue(() => BaseObject.AddPlayer(player));
        }

        public void RemovePlayer(IPlayer player)
        {
            AsyncContext.Enqueue(() => BaseObject.RemovePlayer(player));
        }

        public void MutePlayer(IPlayer player)
        {
            AsyncContext.Enqueue(() => BaseObject.MutePlayer(player));
        }

        public void UnmutePlayer(IPlayer player)
        {
            AsyncContext.Enqueue(() => BaseObject.UnmutePlayer(player));
        }

        public bool HasPlayer(IPlayer player)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.HasPlayer(player);
            }
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.IsPlayerMuted(player);
            }
        }

        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlocking(() => BaseObject.Remove());
        }
    }
}