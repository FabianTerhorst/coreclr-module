using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity.Elements.Factories
{
    public class NetworkingEntityFactory : INetworkingEntityFactory
    {
        public INetworkingEntity Create(IEntityStreamer entityStreamer, Entity.Entity streamedEntity, StreamingType streamingType)
        {
            return new Elements.Entities.NetworkingEntity(entityStreamer, streamedEntity, streamingType);
        }
    }
}