namespace AltV.Net.EntitySync
{
    public interface IClientRepository
    {
        void Add(IClient client);

        IClient Remove(IClient client);
        
        IClient Remove(string token);

        void Replace(IClient client);

        bool TryGet(string token, out IClient client);
    }
}