using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity.Elements.Factories
{
    public interface INetworkingClientFactory
    {
        INetworkingClient Create(string token, IEntityStreamer entityStreamer);
    }
}