using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Factories
{
    public interface IEntityFactory<TEntity> where TEntity : IEntity
    {
        TEntity Create(IClient client, IntPtr entityPointer, ushort id);
    }
}