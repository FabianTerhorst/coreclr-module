using AltV.Net.NetworkingEntity.Elements.Factories;
using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity
{
    public class NetworkingModuleBuilder
    {
        private string ip;

        private int port;

        private IIdProvider<ulong> idProvider;

        private INetworkingEntityFactory networkingEntityFactory;

        private IIdProvider<string> tokenProvider;

        private INetworkingClientFactory networkingClientFactory;

        private IAuthenticationProviderFactory authenticationProviderFactory;

        private IStreamingHandlerFactory streamingHandlerFactory;

        public NetworkingModuleBuilder()
        {
            this.port = 46429;
        }

        public NetworkingModuleBuilder SetIp(string value)
        {
            this.ip = value;
            return this;
        }

        public NetworkingModuleBuilder SetPort(int value)
        {
            this.port = value;
            return this;
        }

        public NetworkingModuleBuilder SetEntityIdProvider(IIdProvider<ulong> value)
        {
            this.idProvider = value;
            return this;
        }

        public NetworkingModuleBuilder SetNetworkingEntityFactory(INetworkingEntityFactory value)
        {
            this.networkingEntityFactory = value;
            return this;
        }

        public NetworkingModuleBuilder SetTokenProvider(IIdProvider<string> value)
        {
            this.tokenProvider = value;
            return this;
        }

        public NetworkingModuleBuilder SetNetworkingClientFactory(INetworkingClientFactory value)
        {
            this.networkingClientFactory = value;
            return this;
        }

        public NetworkingModuleBuilder SetAuthenticationProviderFactory(IAuthenticationProviderFactory value)
        {
            this.authenticationProviderFactory = value;
            return this;
        }

        public NetworkingModuleBuilder SetStreamingHandlerFactory(IStreamingHandlerFactory value)
        {
            this.streamingHandlerFactory = value;
            return this;
        }

        public NetworkingModule Build()
        {
            if (idProvider == null)
            {
                idProvider = new IdProvider();
            }

            if (networkingEntityFactory == null)
            {
                networkingEntityFactory = new NetworkingEntityFactory();
            }

            if (tokenProvider == null)
            {
                tokenProvider = new ClientTokenProvider();
            }

            if (networkingClientFactory == null)
            {
                networkingClientFactory = new NetworkingClientFactory();
            }

            if (authenticationProviderFactory == null)
            {
                authenticationProviderFactory = new AuthenticationProviderFactory();
            }

            if (streamingHandlerFactory == null)
            {
                streamingHandlerFactory = new ClientEntityStreamingHandlerFactory();
            }

            return new NetworkingModule(ip, port, idProvider, networkingEntityFactory, tokenProvider,
                networkingClientFactory, authenticationProviderFactory, streamingHandlerFactory);
        }
    }
}