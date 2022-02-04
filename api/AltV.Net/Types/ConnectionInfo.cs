using System;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net.Types;

public class ConnectionInfo: IConnectionInfo, IInternalNative
{
    private bool exists;
    
    public bool Exists
    {
        get => exists;
        set => exists = value;
    }

    public string Name {
        get
        {
            lock (this)
            {
                if (!exists) return null;
                unsafe
                {
                    var size = 0;
                    return server.PtrToStringUtf8AndFree(
                        server.Library.ConnectionInfo_GetName(NativePointer, &size), size);
                }
            }
        }
    }
    public ulong SocialClubId {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    return server.Library.ConnectionInfo_GetSocialId(NativePointer);
                }
            }
        }
    }
    public ulong HardwareIdHash {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    return server.Library.ConnectionInfo_GetHwIdHash(NativePointer);
                }
            }
        }
    }
    public ulong HardwareIdExHash {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    return server.Library.ConnectionInfo_GetHwIdExHash(NativePointer);
                }
            }
        }
    }
    public string AuthToken {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    var size = 0;
                    return server.PtrToStringUtf8AndFree(
                        server.Library.ConnectionInfo_GetAuthToken(NativePointer, &size), size);
                }
            }
        }
    }
    public bool IsDebug {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    return server.Library.ConnectionInfo_GetIsDebug(NativePointer) == 1;
                }
            }
        }
    }
    public string Branch {
        get
        {
            lock (this)
            {
                if (!exists) return null;
                unsafe
                {
                    var size = 0;
                    return server.PtrToStringUtf8AndFree(
                        server.Library.ConnectionInfo_GetBranch(NativePointer, &size), size);
                }
            }
        }
    }
    public uint Build {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    return server.Library.ConnectionInfo_GetBuild(NativePointer);
                }
            }
        }
    }
    public string CdnUrl {
        get
        {
            lock (this)
            {
                if (!exists) return null;
                unsafe
                {
                    var size = 0;
                    return server.PtrToStringUtf8AndFree(
                        server.Library.ConnectionInfo_GetCdnUrl(NativePointer, &size), size);
                }
            }
        }
    }
    public ulong PasswordHash {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    return server.Library.ConnectionInfo_GetPasswordHash(NativePointer);
                }
            }
        }
    }
    public string Ip {
        get
        {
            lock (this)
            {
                if (!exists) return null;
                unsafe
                {
                    var size = 0;
                    return server.PtrToStringUtf8AndFree(
                        server.Library.ConnectionInfo_GetIp(NativePointer, &size), size);
                }
            }
        }
    }
    public string DiscordUserId {
        get
        {
            lock (this)
            {
                if (!exists) return null;
                unsafe
                {
                    var size = 0;
                    return server.PtrToStringUtf8AndFree(
                        server.Library.ConnectionInfo_GetDiscordUserID(NativePointer, &size), size);
                }
            }
        }
    }
    public IntPtr NativePointer { get; }

    private readonly IServer server;

    public ConnectionInfo(IServer server, IntPtr nativePointer)
    {
        NativePointer = nativePointer;
        this.server = server;
        exists = true;
    }
    
    public bool AddRef()
    {
        lock (this)
        {
            if (!exists) return false;
            unsafe
            {
                server.Library.ConnectionInfo_AddRef(NativePointer);
            }
        }

        return true;
    }

    public bool RemoveRef()
    {
        lock (this)
        {
            if (!exists) return false;
            unsafe
            {
                server.Library.ConnectionInfo_RemoveRef(NativePointer);
            }
        }
        
        return true;
    }

    public void Accept()
    {
        lock (this)
        {
            if (!exists) return;
            unsafe
            {
                server.Library.ConnectionInfo_Accept(NativePointer);
            }
        }
    }

    public void Decline(string reason)
    {
        lock (this)
        {
            if (!exists) return;
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
                server.Library.ConnectionInfo_Decline(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
    }
}