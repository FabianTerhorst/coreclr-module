using AltV.Net.NetworkingEntity.Elements.Providers;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Factories
{
    public interface IAuthenticationProviderFactory
    {
        IAuthenticationProvider Create(int port, WebSocket webSocket);
    }
}