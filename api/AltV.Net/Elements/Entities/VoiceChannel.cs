using System;

namespace AltV.Net.Elements.Entities
{
    public class VoiceChannel : BaseObject, IVoiceChannel
    {
        public IntPtr VoiceChannelNativePointer { get; }
        public override IntPtr NativePointer => VoiceChannelNativePointer;
        
        private static IntPtr GetBaseObjectPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Server.VoiceChannel_GetBaseObject(nativePointer);
            }
        }
        
        public void AddPlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.VoiceChannel_AddPlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.VoiceChannel_RemovePlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public void MutePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.VoiceChannel_MutePlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public void UnmutePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.VoiceChannel_UnmutePlayer(VoiceChannelNativePointer, player.PlayerNativePointer);
            }
        }

        public bool HasPlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.VoiceChannel_HasPlayer(VoiceChannelNativePointer, player.PlayerNativePointer) == 1;
            }
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.VoiceChannel_IsPlayerMuted(VoiceChannelNativePointer, player.PlayerNativePointer) == 1;
            }
        }

        public bool IsSpatial
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.VoiceChannel_IsSpatial(VoiceChannelNativePointer) == 1;
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
                    return Core.Library.Server.VoiceChannel_GetMaxDistance(VoiceChannelNativePointer);
                }
            }
        }

        public VoiceChannel(ICore core, IntPtr nativePointer) : base(core, GetBaseObjectPointer(core, nativePointer), BaseObjectType.VoiceChannel)
        {
            VoiceChannelNativePointer = nativePointer;
        }

        public void Remove()
        {
            Alt.RemoveVoiceChannel(this);
        }
    }
}