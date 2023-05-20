using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories;

public class NetworkObjectFactory : IEntityFactory<INetworkObject>
{
    public INetworkObject Create(ICore core, IntPtr pointer, uint id)
    {
        return new NetworkObject(core, pointer, id);
    }
}