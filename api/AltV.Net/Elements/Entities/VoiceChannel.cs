using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class VoiceChannel : BaseObject, IVoiceChannel
    {
        public void AddPlayer(IPlayer player)
        {
            CheckIfEntityExists();
            AltNative.VoiceChannel.VoiceChannel_AddPlayer(NativePointer, player.NativePointer);
        }

        public void RemovePlayer(IPlayer player)
        {
            CheckIfEntityExists();
            AltNative.VoiceChannel.VoiceChannel_RemovePlayer(NativePointer, player.NativePointer);
        }

        public void MutePlayer(IPlayer player)
        {
            CheckIfEntityExists();
            AltNative.VoiceChannel.VoiceChannel_MutePlayer(NativePointer, player.NativePointer);
        }

        public void UnmutePlayer(IPlayer player)
        {
            CheckIfEntityExists();
            AltNative.VoiceChannel.VoiceChannel_UnmutePlayer(NativePointer, player.NativePointer);
        }

        public bool IsPlayerConnected(IPlayer player)
        {
            CheckIfEntityExists();
            return AltNative.VoiceChannel.VoiceChannel_IsPlayerConnected(NativePointer, player.NativePointer);
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            CheckIfEntityExists();
            return AltNative.VoiceChannel.VoiceChannel_IsPlayerMuted(NativePointer, player.NativePointer);
        }

        public bool IsSpatial
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.VoiceChannel.VoiceChannel_IsSpatial(NativePointer);
            }
        }

        public float MaxDistance
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.VoiceChannel.VoiceChannel_GetMaxDistance(NativePointer);
            }
        }

        public VoiceChannel(IntPtr nativePointer) : base(nativePointer, BaseObjectType.VoiceChannel)
        {
        }

        public override void GetMetaData(string key, ref MValue value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.VoiceChannel.VoiceChannel_GetMetaData(NativePointer, stringPtr, ref value);
            Marshal.FreeHGlobal(stringPtr);
        }

        public override void SetMetaData(string key, ref MValue value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.VoiceChannel.VoiceChannel_SetMetaData(NativePointer, stringPtr, ref value);
            Marshal.FreeHGlobal(stringPtr);
        }

        public void Remove()
        {
            Alt.RemoveVoiceChannel(this);
        }
    }
}