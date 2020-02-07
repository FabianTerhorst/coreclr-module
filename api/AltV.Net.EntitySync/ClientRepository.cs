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

        public void Remove(IClient client)
        {
            lock (clients)
            {
                clients.Remove(client.Token);
            }
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