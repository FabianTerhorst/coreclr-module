using System;
using System.Collections.Generic;
using AltV.Net.NetworkingEntity.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Factories;
using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity.Elements.Pools
{
    public class NetworkingClientPool : INetworkingClientPool
    {
        private readonly IDictionary<string, INetworkingClient> entities = new Dictionary<string, INetworkingClient>();

        public IDictionary<string, INetworkingClient> Clients => entities;

        private readonly IIdProvider<string> idProvider;

        private readonly INetworkingClientFactory factory;

        public NetworkingClientPool(IIdProvider<string> idProvider, INetworkingClientFactory factory)
        {
            this.idProvider = idProvider;
            this.factory = factory;
        }

        public INetworkingClient Create(string token)
        {
            var entity = factory.Create(token);
            Add(entity);
            return entity;
        }

        public INetworkingClient Create()
        {
            var entity = factory.Create(idProvider.GetNext());
            Add(entity);
            return entity;
        }

        public bool Add(INetworkingClient client)
        {
            lock (entities)
            {
                return entities.TryAdd(client.Token, client);
            }
        }

        public void Remove(string token)
        {
            INetworkingClient removedClient;
            idProvider.Free(token);
            lock (entities)
            {
                if (!entities.Remove(token, out removedClient))
                {
                    return;
                }
            }

            if (removedClient is IInternalNetworkingClient internalNetworkingClient)
            {
                lock (internalNetworkingClient)
                {
                    internalNetworkingClient.Exists = false;
                }
            }
        }

        public bool Remove(string token, out INetworkingClient client)
        {
            idProvider.Free(token);
            lock (entities)
            {
                if (!entities.Remove(token, out client))
                {
                    return false;
                }
            }

            if (client is IInternalNetworkingClient internalNetworkingClient)
            {
                lock (internalNetworkingClient)
                {
                    internalNetworkingClient.Exists = false;
                }
            }

            return true;
        }

        public void Remove(INetworkingClient client) => Remove(client.Token);

        public bool TryGet(string token, out INetworkingClient client)
        {
            lock (entities)
            {
                return entities.TryGetValue(token, out client);
            }
        }

        public void SendToAll(byte[] bytes)
        {
            lock (entities)
            {
                foreach (var (_, value) in entities)
                {
                    if (value.Exists)
                    {
                        value.WebSocket?.SendAsync(bytes, true);
                    }
                }
            }
        }
    }
}