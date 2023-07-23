using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities;

public class AsyncConnectionInfo : AsyncBaseObject, IConnectionInfo, IAsyncConvertible<IConnectionInfo>
{
    protected readonly IConnectionInfo ConnectionInfo;
    public IntPtr ConnectionInfoNativePointer => ConnectionInfo.ConnectionInfoNativePointer;
    public AsyncConnectionInfo(IConnectionInfo connectionInfo, IAsyncContext asyncContext) : base(connectionInfo, asyncContext)
    {
        ConnectionInfo = connectionInfo;
    }

    public AsyncConnectionInfo(ICore core, IntPtr nativePointer, uint id) : this(new ConnectionInfo(core, nativePointer, id),
        null)
    {
    }

    public string Name
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.Name;
            }
        }
    }
    public ulong SocialClubId
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.SocialClubId;
            }
        }
    }
    public ulong HardwareIdHash
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.HardwareIdHash;
            }
        }
    }
    public ulong HardwareIdExHash
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.HardwareIdExHash;
            }
        }
    }
    public string AuthToken
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.AuthToken;
            }
        }
    }
    public bool IsDebug
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.IsDebug;
            }
        }
    }
    public string Branch
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.Branch;
            }
        }
    }
    public uint Build
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.Build;
            }
        }
    }
    public string CdnUrl
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.CdnUrl;
            }
        }
    }
    public ulong PasswordHash
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.PasswordHash;
            }
        }
    }
    public string Ip
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.Ip;
            }
        }
    }
    public long DiscordUserId
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.DiscordUserId;
            }
        }
    }
    public string SocialName
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.SocialName;
            }
        }
    }
    public string CloudAuthHash
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.CloudAuthHash;
            }
        }
    }

    public bool IsAccepted
    {
        get
        {
            lock (ConnectionInfo)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(ConnectionInfo)) return default;
                return ConnectionInfo.IsAccepted;
            }
        }
    }

    public void Accept(bool sendNames = true)
    {
        lock (ConnectionInfo)
        {
            if (!AsyncContext.CheckIfExistsNullable(ConnectionInfo)) return;
            ConnectionInfo.Accept(sendNames);
        }
    }

    public void Decline(string reason)
    {
        lock (ConnectionInfo)
        {
            if (!AsyncContext.CheckIfExistsNullable(ConnectionInfo)) return;
            ConnectionInfo.Decline(reason);
        }
    }


    [Obsolete("Use new async API instead")]
    public IConnectionInfo ToAsync(IAsyncContext asyncContext)
    {
        return this;
    }
}