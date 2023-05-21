using System;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockConnectionInfo : MockWorldObject, IConnectionInfo
    {
        public MockConnectionInfo(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, BaseObjectType.ConnectionInfo, id)
        {
        }

        public IntPtr ConnectionInfoNativePointer { get; }
        public string Name { get; }
        public ulong SocialClubId { get; }
        public ulong HardwareIdHash { get; }
        public ulong HardwareIdExHash { get; }
        public string AuthToken { get; }
        public bool IsDebug { get; }
        public string Branch { get; }
        public uint Build { get; }
        public string CdnUrl { get; }
        public ulong PasswordHash { get; }
        public string Ip { get; }
        public long DiscordUserId { get; }
        public string SocialName { get; }
        public string CloudAuthHash { get; }
        public bool IsAccepted { get; }
        public void Accept(bool sendNames = true)
        {
            throw new NotImplementedException();
        }

        public void Decline(string reason)
        {
            throw new NotImplementedException();
        }
    }
}