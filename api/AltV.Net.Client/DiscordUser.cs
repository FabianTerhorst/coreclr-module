using System.Runtime.InteropServices;

namespace AltV.Net.Client
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DiscordUser
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Id;
        
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Username;
        
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Discriminator;
        
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Avatar;
    }
}