using System;

namespace AltV.Net.Elements.Entities
{
    public class VoiceChannel : BaseObject, IVoiceChannel
    {
        public IntPtr VoiceChannelNativePointer { get; }
        public override IntPtr NativePointer => VoiceChannelNativePointer;
        
        private static IntPtr GetBaseObjectPointer(IServer server, IntPtr nativePointer)
        {
            unsafe
            {
                return server.Library.Server.VoiceChannel_GetBaseObject(nativePointer);
            }
        }
        
        public void AddPlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Server.VoiceChannel_AddPlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Server.VoiceChannel_RemovePlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public void MutePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Server.VoiceChannel_MutePlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public void UnmutePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Server.VoiceChannel_UnmutePlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public bool HasPlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Server.VoiceChannel_HasPlayer(VoiceChannelNativePointer, player.PlayerNativePointer) == 1;
            }
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Server.VoiceChannel_IsPlayerMuted(VoiceChannelNativePointer, player.PlayerNativePointer) == 1;
            }
        }

        public bool IsSpatial
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.VoiceChannel_IsSpatial(VoiceChannelNativePointer) == 1;
                }
            }
        }

        public float MaxDistance
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.VoiceChannel_GetMaxDistance(VoiceChannelNativePointer);
                }
            }
        }

        public VoiceChannel(IServer server, IntPtr nativePointer) : base(server, GetBaseObjectPointer(server, nativePointer), BaseObjectType.VoiceChannel)
        {
            VoiceChannelNativePointer = nativePointer;
        }

        public void Remove()
        {
            Alt.RemoveVoiceChannel(this);
        }
    }
}