using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        internal static class VoiceChannel
        {
            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_GetMetaData(IntPtr channelPointer, string key, ref MValue value);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_SetMetaData(IntPtr channelPointer, string key, ref MValue value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_AddPlayer(IntPtr channelPointer, IntPtr playerPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_RemovePlayer(IntPtr channelPointer, IntPtr playerPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_MutePlayer(IntPtr channelPointer, IntPtr playerPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_UnmutePlayer(IntPtr channelPointer, IntPtr playerPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool VoiceChannel_IsPlayerConnected(IntPtr channelPointer, IntPtr playerPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool VoiceChannel_IsPlayerMuted(IntPtr channelPointer, IntPtr playerPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool VoiceChannel_IsSpatial(IntPtr channelPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float VoiceChannel_GetMaxDistance(IntPtr channelPointer);
        }
    }
}