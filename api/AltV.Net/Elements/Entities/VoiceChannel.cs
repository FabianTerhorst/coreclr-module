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
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.VoiceChannel_AddPlayer(NativePointer, player.NativePointer);
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.VoiceChannel_RemovePlayer(NativePointer, player.NativePointer);
            }
        }

        public void MutePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.VoiceChannel_MutePlayer(NativePointer, player.NativePointer);
            }
        }

        public void UnmutePlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.VoiceChannel_UnmutePlayer(NativePointer, player.NativePointer);
            }
        }

        public bool HasPlayer(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.VoiceChannel_HasPlayer(NativePointer, player.NativePointer) == 1;
            }
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.VoiceChannel_IsPlayerMuted(NativePointer, player.NativePointer) == 1;
            }
        }

        public bool IsSpatial
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.VoiceChannel_IsSpatial(NativePointer) == 1;
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
                    return Server.Library.VoiceChannel_GetMaxDistance(NativePointer);
                }
            }
        }

        public VoiceChannel(IServer server, IntPtr nativePointer) : base(server, nativePointer, BaseObjectType.VoiceChannel)
        {
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.VoiceChannel_GetMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.VoiceChannel_SetMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public override bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.VoiceChannel_HasMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.VoiceChannel_DeleteMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void Remove()
        {
            Alt.RemoveVoiceChannel(this);
        }
        
        protected override void InternalAddRef()
        {
            unsafe
            {
                Server.Library.VoiceChannel_AddRef(NativePointer);
            }
        }

        protected override void InternalRemoveRef()
        {
            unsafe
            {
                Server.Library.VoiceChannel_RemoveRef(NativePointer);
            }
        }
    }
}