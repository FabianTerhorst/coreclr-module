using System;
using System.Collections.Generic;
using System.Linq;

namespace AltV.Net.EntitySync
{
    public class ClientThreadRepository : IClientThreadRepository
    {
        private readonly IDictionary<string, IClient> clients = new Dictionary<string, IClient>();
        
        private readonly HashSet<IClient> clientsToRemove = new HashSet<IClient>();

        public void Add(IClient client)
        {
            lock (clients)
            {
                clientsToRemove.Remove(client);
                clients[client.Token] = client;
            }
        }

        public IClient Remove(IClient client)
        {
            return Remove(client.Token);
        }

        public IClient Remove(string token)
        {
            lock (clients)
            {
                if (clients.Remove(token, out var client))
                {
                    clientsToRemove.Add(client);
                    return client;
                }
            }

            return null;
        }

        public bool TryGet(string token, out IClient client)
        {
            lock (clients)
            {
                return clients.TryGetValue(token, out client);
            }
        }

        public ValueTuple<IClient[], IClient[]> GetAll()
        {
            lock (clients)
            {
                IClient[] currClientsToRemove;
                if (clientsToRemove.Count == 0)
                {
                    currClientsToRemove = null;
                }
                else
                {
                    currClientsToRemove = clientsToRemove.ToArray();
                    clientsToRemove.Clear();
                }
                return ValueTuple.Create(clients.Values.ToArray(), currClientsToRemove);
            }
        }
    }
}