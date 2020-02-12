using System.Collections.Generic;

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

        public IEnumerable<IClient> GetAll()
        {
            lock (clients)
            {
                if (clients.Count == 0) yield break;
                foreach (var (_, client) in clients)
                {
                    yield return client;
                }
            }
        }
        
        public IEnumerable<IClient> GetAllDeleted()
        {
            lock (clients)
            {
                if (clientsToRemove.Count == 0) yield break;
                foreach (var client in clientsToRemove)
                {
                    yield return client;
                }
                clientsToRemove.Clear();
            }
        }
    }
}