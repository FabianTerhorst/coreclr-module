using System.Collections.Generic;
using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity.Elements.Pools
{
    public interface INetworkingEntityPool
    {
        IDictionary<ulong, INetworkingEntity> Entities { get; }

        INetworkingEntity Create(ulong id, IEntityStreamer entityStreamer, Entity.Entity streamedEntity);

        INetworkingEntity Create(IEntityStreamer entityStreamer, Entity.Entity streamedEntity);

        bool Add(INetworkingEntity entity);

        void Remove(INetworkingEntity entity);
        
        void Remove(ulong id);

        bool TryGet(ulong id, out INetworkingEntity entity);
    }
}