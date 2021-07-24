using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class ClientThreadRepository : IClientThreadRepository
    {
        public readonly object Mutex = new object();
        
        internal readonly IDictionary<string, IClient> Clients = new Dictionary<string, IClient>();
        
        internal readonly Queue<IClient> ClientsToRemove = new Queue<IClient>();

        public void Add(IClient client)
        {
            lock (Mutex)
            {
                Clients[client.Token] = client;
            }
        }

        public IClient Remove(IClient client)
        {
            return Remove(client.Token);
        }

        public IClient Remove(string token)
        {
            lock (Mutex)
            {
                if (Clients.Remove(token, out var client))
                {
                    ClientsToRemove.Enqueue(client);
                    return client;
                }
            }

            return null;
        }

        public void Replace(IClient client, IClient oldClient)
        {
            lock (Mutex)
            {
                ClientsToRemove.Enqueue(oldClient);
                Clients[client.Token] = client;
            }
        }
        
        public void Replace(IClient client)
        {
            lock (Mutex)
            {
                if (Clients.Remove(client.Token, out var oldClient))
                {
                    ClientsToRemove.Enqueue(oldClient);
                }

                Clients[client.Token] = client;
            }
        }

        public bool TryGet(string token, out IClient client)
        {
            lock (Mutex)
            {
                return Clients.TryGetValue(token, out client);
            }
        }

        public IEnumerable<IClient> GetAll()
        {
            lock (Mutex)
            {
                if (Clients.Count == 0) yield break;
                foreach (var (_, client) in Clients)
                {
                    yield return client;
                }
            }
        }
    }
}