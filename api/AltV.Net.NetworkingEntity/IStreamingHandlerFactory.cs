using AltV.Net.NetworkingEntity.Elements.Pools;
using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity
{
    public interface IStreamingHandlerFactory
    {
        IStreamingHandler Create(INetworkingClientPool networkingClientPool, IAuthenticationProvider authenticationProvider);
    }
}