using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Entities;

public interface IConnectionInfo : IBaseObject
{
    IntPtr ConnectionInfoNativePointer { get; }
    string Name { get; }
    ulong SocialClubId { get; }
    ulong HardwareIdHash { get; }
    ulong HardwareIdExHash { get; }
    string AuthToken { get; }
    bool IsDebug { get; }
    string Branch { get; }
    uint Build { get; }
    string CdnUrl { get; }
    ulong PasswordHash { get; }
    string Ip { get; }
    long DiscordUserId { get; }
    string SocialName { get; }

    string CloudAuthHash { get; }

    bool IsAccepted { get; }

    void Accept(bool sendNames = true);
    void Decline(string reason);
}