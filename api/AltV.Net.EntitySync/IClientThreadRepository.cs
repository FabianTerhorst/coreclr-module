using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public interface IClientThreadRepository
    {
        void Add(IClient client);

        IClient Remove(IClient client);
        
        IClient Remove(string token);

        void Replace(IClient client);
        
        void Replace(IClient client, IClient oldClient);

        bool TryGet(string token, out IClient client);

        IEnumerable<IClient> GetAll();
    }
}