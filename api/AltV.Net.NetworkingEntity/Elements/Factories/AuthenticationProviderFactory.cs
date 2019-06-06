using AltV.Net.NetworkingEntity.Elements.Providers;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Factories
{
    public class AuthenticationProviderFactory : IAuthenticationProviderFactory
    {
        public IAuthenticationProvider Create(int port, WebSocket webSocket)
        {
            return new AuthenticationProvider(port, webSocket);
        }
    }
}