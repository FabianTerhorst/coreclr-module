using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity.Elements.Pools
{
    public interface INetworkingEntityPool
    {
        IDictionary<ulong, INetworkingEntity> Entities { get; }

        INetworkingEntity Create(ulong id, IEntityStreamer entityStreamer, Entity.Entity streamedEntity, StreamingType streamingType);

        INetworkingEntity Create(IEntityStreamer entityStreamer, Entity.Entity streamedEntity);

        bool Add(INetworkingEntity entity);

        Task Remove(INetworkingEntity entity);
        
        Task Remove(ulong id);

        bool TryGet(ulong id, out INetworkingEntity entity);
    }
}