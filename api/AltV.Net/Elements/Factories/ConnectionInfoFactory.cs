using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class ConnectionInfoFactory : IBaseObjectFactory<IConnectionInfo>
    {
        public IConnectionInfo Create(ICore core, IntPtr pointer, uint id)
        {
            return new ConnectionInfo(core, pointer, id);
        }
    }
}