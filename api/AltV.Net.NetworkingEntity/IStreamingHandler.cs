using System;
using System.Net.WebSockets;
using AltV.Net.NetworkingEntity.Elements.Entities;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity
{
    public interface IStreamingHandler
    {
        event Action<INetworkingEntity, INetworkingClient> EntityStreamInHandler;

        event Action<INetworkingEntity, INetworkingClient> EntityStreamOutHandler;
        
        void OnMessage(ManagedWebSocket managedWebSocket, WebSocketReceiveResult result, byte[] data);
    }
}