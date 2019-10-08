using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class VoiceChannel
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_GetMetaData(IntPtr channel, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_SetMetaData(IntPtr channel, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_AddPlayer(IntPtr channel, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_RemovePlayer(IntPtr channel, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_MutePlayer(IntPtr channel, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void VoiceChannel_UnmutePlayer(IntPtr channel, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool VoiceChannel_IsPlayerConnected(IntPtr channel, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool VoiceChannel_IsPlayerMuted(IntPtr channel, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool VoiceChannel_IsSpatial(IntPtr channel);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float VoiceChannel_GetMaxDistance(IntPtr channel);
        }
    }
}