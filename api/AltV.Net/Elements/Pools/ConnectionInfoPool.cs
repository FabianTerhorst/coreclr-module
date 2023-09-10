using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools;

public class ConnectionInfoPool : BaseObjectPool<IConnectionInfo>
{
    public ConnectionInfoPool(IBaseObjectFactory<IConnectionInfo> factory) : base(factory)
    {
    }

    public override uint GetId(IntPtr entityPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Server.ConnectionInfo_GetID(entityPointer);
        }
    }
}