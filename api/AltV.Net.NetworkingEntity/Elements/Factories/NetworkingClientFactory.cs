using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity.Elements.Factories
{
    public class NetworkingClientFactory : INetworkingClientFactory
    {
        public INetworkingClient Create(string token)
        {
            return new NetworkingClient(token);
        }
    }
}