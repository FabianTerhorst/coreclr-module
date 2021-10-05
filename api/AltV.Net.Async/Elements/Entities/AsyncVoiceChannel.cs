using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVoiceChannel : AsyncBaseObject<IVoiceChannel>, IVoiceChannel
    {
        public bool IsSpatial { get; }
        public float MaxDistance { get; }
        
        public AsyncVoiceChannel(IVoiceChannel voiceChannel, IAsyncContext asyncContext):base(voiceChannel, asyncContext)
        {
        }

        public void AddPlayer(IPlayer player)
        {
            throw new System.NotImplementedException();
        }

        public void RemovePlayer(IPlayer player)
        {
            throw new System.NotImplementedException();
        }

        public void MutePlayer(IPlayer player)
        {
            throw new System.NotImplementedException();
        }

        public void UnmutePlayer(IPlayer player)
        {
            throw new System.NotImplementedException();
        }

        public bool HasPlayer(IPlayer player)
        {
            throw new System.NotImplementedException();
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
        
        public void Remove()
        {
            throw new System.NotImplementedException();
        }
    }
}