using System;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PlayerConnectionInfo
    {
        [MarshalAs(UnmanagedType.LPStr)] public readonly string Name;
        public readonly ulong SocialId;
        public readonly ulong HwidHash;
        public readonly ulong HwidExHash;
        [MarshalAs(UnmanagedType.LPStr)] public readonly string AuthToken;
        public readonly bool IsDebug;
        [MarshalAs(UnmanagedType.LPStr)] public readonly string Branch;
        public readonly uint Build;
        [MarshalAs(UnmanagedType.LPStr)] public readonly string CdnUrl;
        public readonly ulong PasswordHash;
    }
}