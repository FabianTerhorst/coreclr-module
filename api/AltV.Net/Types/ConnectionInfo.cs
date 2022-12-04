using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net.Types;

public class ConnectionInfo: IConnectionInfo, IInternalNative
{
    private bool exists;
    
    private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();
    
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

    public void Accept(bool sendNames = true)
    {
        lock (this)
        {
            if (!exists) return;
            unsafe
            {
                core.Library.Server.ConnectionInfo_Accept(NativePointer, sendNames ? (byte)1 : (byte)0);
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
    
    public void SetData(string key, object value)
    {
        data[key] = value;
    }

    public bool GetData<T>(string key, out T result)
    {
        if (!data.TryGetValue(key, out var value))
        {
            result = default;
            return false;
        }

        if (!(value is T cast))
        {
            result = default;
            return false;
        }

        result = cast;
        return true;
    }

        
    public IEnumerable<string> GetAllDataKeys()
    {
        return data.Keys.ToList(); // make copy!
    }

    public bool HasData(string key)
    {
        return data.ContainsKey(key);
    }

    public void DeleteData(string key)
    {
        data.TryRemove(key, out _);
    }

    public void ClearData()
    {
        data.Clear();
    }
    
    public override int GetHashCode()
    {
        return NativePointer.GetHashCode();
    }
}
