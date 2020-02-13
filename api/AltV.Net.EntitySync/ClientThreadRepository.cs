using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class ClientThreadRepository : IClientThreadRepository
    {
        public readonly object Mutex = new object();
        
        internal readonly IDictionary<string, IClient> Clients = new Dictionary<string, IClient>();
        
        internal readonly LinkedList<IClient> ClientsToRemove = new LinkedList<IClient>();

        public void Add(IClient client)
        {
            lock (Mutex)
            {
                ClientsToRemove.Remove(client);
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
                    ClientsToRemove.AddLast(client);
                    return client;
                }
            }

            return null;
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
        
        public IEnumerable<IClient> GetAllDeleted()
        {
            lock (Mutex)
            {
                if (ClientsToRemove.Count == 0) yield break;
                var clientToRemove = ClientsToRemove.First;
                while (clientToRemove != null)
                {
                    yield return clientToRemove.Value;
                    clientToRemove = clientToRemove.Next;
                }
                ClientsToRemove.Clear();
            }
        }
    }
}