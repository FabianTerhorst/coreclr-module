using AltV.Net.NetworkingEntity.Elements.Providers;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Factories
{
    public class AuthenticationProviderFactory : IAuthenticationProviderFactory
    {
        public IAuthenticationProvider Create(WebSocket webSocket)
        {
            return new AuthenticationProvider(webSocket);
        }
    }
}