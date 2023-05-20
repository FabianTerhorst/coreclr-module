using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class NetworkObjectPool : EntityPool<INetworkObject>
    {
        public NetworkObjectPool(IEntityFactory<INetworkObject> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.NetworkObject_GetID(entityPointer);
            }
        }
    }
}