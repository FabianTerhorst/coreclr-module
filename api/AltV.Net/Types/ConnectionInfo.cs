using System;

namespace AltV.Net.Types;

public class ConnectionInfo: IConnectionInfo, IInternalNative
{
    private bool exists;
    
    public bool Exists
    {
        get => exists;
        set => exists = value;
    }

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
    public string DiscordUserId { get; }
    public IntPtr NativePointer { get; }

    public ConnectionInfo(IntPtr nativePointer)
    {
        NativePointer = nativePointer;
        exists = true;
    }
    
    public bool AddRef()
    {
        throw new NotImplementedException();
    }

    public bool RemoveRef()
    {
        throw new NotImplementedException();
    }

    public void Accept()
    {
        throw new NotImplementedException();
    }

    public void Decline(string reason)
    {
        throw new NotImplementedException();
    }
}