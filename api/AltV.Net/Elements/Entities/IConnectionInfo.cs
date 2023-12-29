using System;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Entities;

public interface IConnectionInfo : IBaseObject
{
    IntPtr ConnectionInfoNativePointer { get; }
    string Name { get; }
    ulong SocialId { get; }
    ulong HardwareIdHash { get; }
    ulong HardwareIdExHash { get; }
    string AuthToken { get; }
    bool IsDebug { get; }
    string Branch { get; }
    ushort VersionMajor { get; }
    ushort VersionMinor { get; }
    string CdnUrl { get; }
    ulong PasswordHash { get; }
    string Ip { get; }
    long DiscordUserId { get; }
    string SocialName { get; }

    string Text { get; set; }

    bool IsAccepted { get; }

    void Accept(bool sendNames = true);
    void Decline(string reason);
    string CloudId { get; }

    CloudAuthResult CloudAuthResult { get; }
}