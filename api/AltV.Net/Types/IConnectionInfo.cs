namespace AltV.Net.Types;

public interface IConnectionInfo : IRefCountable
{
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

    void Accept();
    void Decline(string reason);
}