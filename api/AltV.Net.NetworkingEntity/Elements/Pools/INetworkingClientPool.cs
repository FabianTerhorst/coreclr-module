using System.Collections.Generic;
using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity.Elements.Pools
{
    public interface INetworkingClientPool
    {
        IDictionary<string, INetworkingClient> Clients { get; }

        INetworkingClient Create(string token, IEntityStreamer entityStreamer);
        
        INetworkingClient Create(IEntityStreamer entityStreamer);

        bool Add(INetworkingClient client);

        void Remove(INetworkingClient client);

        void Remove(string token);

        bool Remove(string token, out INetworkingClient client);

        bool TryGet(string token, out INetworkingClient client);

        void SendToAll(byte[] bytes);
    }
}