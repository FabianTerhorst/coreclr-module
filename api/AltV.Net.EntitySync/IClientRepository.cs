namespace AltV.Net.EntitySync
{
    public interface IClientRepository
    {
        void Add(IClient client);

        void Remove(IClient client);

        IClient[] GetAll();
    }
}