using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Elements.Entities
{
    public class VoiceChannel : BaseObject, IVoiceChannel
    {
        public IntPtr VoiceChannelNativePointer { get; }

        private static IntPtr GetBaseObjectPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Server.VoiceChannel_GetBaseObject(nativePointer);
            }
        }

        public static uint GetId(IntPtr pedPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.VoiceChannel_GetID(pedPointer);
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

        public uint Filter
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.VoiceChannel_GetFilter(VoiceChannelNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.VoiceChannel_SetFilter(VoiceChannelNativePointer, value);
                }
            }
        }

        public int Priority
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.VoiceChannel_GetPriority(VoiceChannelNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.VoiceChannel_SetPriority(VoiceChannelNativePointer, value);
                }
            }
        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get
            {
                unsafe
                {
                    CheckIfCallIsValid();
                    ulong size = 0;
                    var ptr = Core.Library.Server.VoiceChannel_GetPlayers(VoiceChannelNativePointer, &size);
                    var data = new IntPtr[size];
                    Marshal.Copy(ptr, data, 0, (int)size);
                    var arr = data.Select(e => (IPlayer)Core.PoolManager.GetOrCreate(Core, e, BaseObjectType.Player))
                        .ToArray();
                    Core.Library.Shared.FreePlayerArray(ptr);
                    return arr;
                }
            }
        }

        public ulong PlayerCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.VoiceChannel_GetPlayerCount(VoiceChannelNativePointer);
                }
            }
        }

        public VoiceChannel(ICore core, IntPtr nativePointer, uint id) : base(core, GetBaseObjectPointer(core, nativePointer), BaseObjectType.VoiceChannel, id)
        {
            VoiceChannelNativePointer = nativePointer;
        }
    }
}