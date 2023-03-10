using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVoiceChannel : MockWorldObject, IVoiceChannel
    {
        public MockVoiceChannel(ICore core, IntPtr nativePointer): base(core, nativePointer, BaseObjectType.VoiceChannel)
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
    }
}