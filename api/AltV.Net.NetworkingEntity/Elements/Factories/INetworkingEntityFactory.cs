using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity.Elements.Factories
{
    public interface INetworkingEntityFactory
    {
        INetworkingEntity Create(IEntityStreamer entityStreamer, Entity.Entity streamedEntity, StreamingType streamingType);
    }
}