using AltV.Net.NetworkingEntity.Elements.Pools;
using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity
{
    public class ClientEntityStreamingHandlerFactory : IStreamingHandlerFactory
    {
        public IStreamingHandler Create(INetworkingClientPool networkingClientPool, IAuthenticationProvider authenticationProvider)
        {
            return new ClientEntityStreamingHandler(networkingClientPool, authenticationProvider);
        }
    }
}