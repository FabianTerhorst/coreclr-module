namespace AltV.Net.EntitySync
{
    public interface IClientRepository
    {
        void Add(IClient client);

        IClient Remove(IClient client);
        
        IClient Remove(string token);

        IClient[] GetAll();
    }
}