using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVoiceChannel : MockWorldObject, IVoiceChannel
    {
        public MockVoiceChannel(ICore core, IntPtr nativePointer, uint id): base(core, nativePointer, BaseObjectType.VoiceChannel, id)
        {
        }

        public IntPtr VoiceChannelNativePointer { get; }
        public void AddPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void RemovePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void MutePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void UnmutePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool HasPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool IsSpatial { set; get; }
        public float MaxDistance { set; get; }

        public void Destroy()
        {
            Alt.Core.RemoveVoiceChannel(this);
        }

        public uint Filter { get; set; }
        public int Priority { get; set; }
        public IReadOnlyCollection<IPlayer> Players { get; }
        public ulong PlayerCount { get; }
    }
}