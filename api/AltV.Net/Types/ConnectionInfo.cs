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
                    return core.PtrToStringUtf8AndFree(
                        core.Library.Server.ConnectionInfo_GetName(NativePointer, &size), size);
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
                    return core.Library.Server.ConnectionInfo_GetSocialId(NativePointer);
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
                    return core.Library.Server.ConnectionInfo_GetHwIdHash(NativePointer);
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
                    return core.Library.Server.ConnectionInfo_GetHwIdExHash(NativePointer);
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
                    return core.PtrToStringUtf8AndFree(
                        core.Library.Server.ConnectionInfo_GetAuthToken(NativePointer, &size), size);
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
                    return core.Library.Server.ConnectionInfo_GetIsDebug(NativePointer) == 1;
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
                    return core.PtrToStringUtf8AndFree(
                        core.Library.Server.ConnectionInfo_GetBranch(NativePointer, &size), size);
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
                    return core.Library.Server.ConnectionInfo_GetBuild(NativePointer);
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
                    return core.PtrToStringUtf8AndFree(
                        core.Library.Server.ConnectionInfo_GetCdnUrl(NativePointer, &size), size);
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
                    return core.Library.Server.ConnectionInfo_GetPasswordHash(NativePointer);
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
                    return core.PtrToStringUtf8AndFree(
                        core.Library.Server.ConnectionInfo_GetIp(NativePointer, &size), size);
                }
            }
        }
    }
    public long DiscordUserId {
        get
        {
            lock (this)
            {
                if (!exists) return default;
                unsafe
                {
                    return core.Library.Server.ConnectionInfo_GetDiscordUserID(NativePointer);
                }
            }
        }
    }
    public IntPtr NativePointer { get; }

    private readonly ICore core;

    public ConnectionInfo(ICore core, IntPtr nativePointer)
    {
        NativePointer = nativePointer;
        this.core = core;
        exists = true;
    }
    
    public bool AddRef()
    {
        lock (this)
        {
            if (!exists) return false;
        }

        return true;
    }

    public bool RemoveRef()
    {
        lock (this)
        {
            if (!exists) return false;
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
                core.Library.Server.ConnectionInfo_Accept(NativePointer);
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
                core.Library.Server.ConnectionInfo_Decline(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
    }
    
    public override int GetHashCode()
    {
        return NativePointer.GetHashCode();
    }
}