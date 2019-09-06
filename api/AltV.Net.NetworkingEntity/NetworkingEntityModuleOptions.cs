using AltV.Net.NetworkingEntity.Elements.Factories;
using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity
{
    public class NetworkingEntityModuleOptions
    {
        public string Ip { get; set; }

        public int Port { get; set; } = 46429;

        public IIdProvider<ulong> IdProvider { get; set; }

        public INetworkingEntityFactory NetworkingEntityFactory { get; set; }

        public IIdProvider<string> TokenProvider { get; set; }

        public INetworkingClientFactory NetworkingClientFactory { get; set; }

        public IAuthenticationProviderFactory AuthenticationProviderFactory { get; set; }

        public IStreamingHandlerFactory StreamingHandlerFactory { get; set; }

        public NetworkingModule Build()
        {
            if (IdProvider == null)
            {
                IdProvider = new IdProvider();
            }

            if (NetworkingEntityFactory == null)
            {
                NetworkingEntityFactory = new NetworkingEntityFactory();
            }

            if (TokenProvider == null)
            {
                TokenProvider = new ClientTokenProvider();
            }

            if (NetworkingClientFactory == null)
            {
                NetworkingClientFactory = new NetworkingClientFactory();
            }

            if (AuthenticationProviderFactory == null)
            {
                AuthenticationProviderFactory = new AuthenticationProviderFactory();
            }

            if (StreamingHandlerFactory == null)
            {
                StreamingHandlerFactory = new ClientEntityStreamingHandlerFactory();
            }

            return new NetworkingModule(Ip, Port, IdProvider, NetworkingEntityFactory, TokenProvider,
                NetworkingClientFactory, AuthenticationProviderFactory, StreamingHandlerFactory);
        }
    }
}