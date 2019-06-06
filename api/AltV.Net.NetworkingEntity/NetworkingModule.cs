using AltV.Net.NetworkingEntity.Elements.Factories;
using AltV.Net.NetworkingEntity.Elements.Pools;
using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity
{
    public class NetworkingModule
    {
        public readonly INetworkingEntityPool EntityPool;

        public readonly INetworkingClientPool ClientPool;

        public readonly Server Server;

        public readonly IEntityStreamer Streamer;

        public NetworkingModule(int port = 46429) : this(port, new IdProvider(), new NetworkingEntityFactory(),
            new ClientTokenProvider(), new NetworkingClientFactory(), new AuthenticationProviderFactory(),
            new ClientEntityStreamingHandlerFactory())
        {
        }

        public NetworkingModule(int port, IIdProvider<ulong> idProvider, INetworkingEntityFactory entityFactory,
            IIdProvider<string> tokenProvider, INetworkingClientFactory clientFactory,
            IAuthenticationProviderFactory authenticationProviderFactory,
            IStreamingHandlerFactory streamingHandlerFactory)
        {
            EntityPool = new NetworkingEntityPool(idProvider, entityFactory);
            ClientPool = new NetworkingClientPool(tokenProvider, clientFactory);
            Streamer = new EntityStreamer();
            Server = new Server(port, authenticationProviderFactory, Streamer, streamingHandlerFactory);
        }
    }
}