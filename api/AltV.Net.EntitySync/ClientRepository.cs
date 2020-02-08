using System.Collections.Generic;
using System.Linq;

namespace AltV.Net.EntitySync
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDictionary<string, IClient> clients = new Dictionary<string, IClient>();

        public void Add(IClient client)
        {
            lock (clients)
            {
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
                if (clients.Remove(token, out var client)) return client;
            }

            return null;
        }

        public IClient[] GetAll()
        {
            lock (clients)
            {
                return clients.Values.ToArray();
            }
        }
    }
}