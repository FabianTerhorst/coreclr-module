namespace AltV.Net.EntitySync
{
    public interface IEntityRepository
    {
        void Add(IEntity entity);

        void Remove(IEntity entity);
    }
}