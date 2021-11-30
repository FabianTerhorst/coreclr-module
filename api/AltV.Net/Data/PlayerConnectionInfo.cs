using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    // TODO: try use only one struct, and [MarshalAs] if strings won't be marshalled automatically
    [StructLayout(LayoutKind.Sequential)]
    internal struct PlayerConnectionInfoInternal
    {
        public readonly IntPtr Name;
        public readonly ulong SocialId;
        public readonly ulong HwidHash;
        public readonly ulong HwidExHash;
        public readonly IntPtr AuthToken;
        public readonly bool IsDebug;
        public readonly IntPtr Branch;
        public readonly uint Build;
        public readonly IntPtr CdnUrl;
        public readonly ulong PasswordHash;
    }
    
    public class PlayerConnectionInfo
    {
        public readonly string Name;
        public readonly ulong SocialId;
        public readonly ulong HwidHash;
        public readonly ulong HwidExHash;
        public readonly string AuthToken;
        public readonly bool IsDebug;
        public readonly string Branch;
        public readonly uint Build;
        public readonly string CdnUrl;
        public readonly ulong PasswordHash;

        internal PlayerConnectionInfo(PlayerConnectionInfoInternal info)
        {
            this.Name = info.Name == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(info.Name);
            this.SocialId = info.SocialId;
            this.HwidHash = info.HwidHash;
            this.HwidExHash = info.HwidExHash;
            this.AuthToken = info.AuthToken == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(info.AuthToken);
            this.IsDebug = info.IsDebug;
            this.Branch = info.Branch == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(info.Branch);
            this.Build = info.Build;
            this.CdnUrl = info.CdnUrl == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(info.CdnUrl);
            this.PasswordHash = info.PasswordHash;
        }
    }
}