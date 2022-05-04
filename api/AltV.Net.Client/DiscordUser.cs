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

        public string AvatarUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Avatar)) return Avatar.StartsWith("a") ? $"https://cdn.discordapp.com/avatars/{Id}/{Avatar}.gif?size=4096" : $"https://cdn.discordapp.com/avatars/{Id}/{Avatar}.png?size=4096";
                if (!int.TryParse(Discriminator, out var discriminator)) discriminator = 0;
                return $"https://cdn.discordapp.com/embed/avatars/{discriminator % 5}.png";
            }
        }
    }
}