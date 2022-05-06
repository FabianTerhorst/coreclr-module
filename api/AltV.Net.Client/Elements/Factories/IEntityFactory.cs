using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public interface IEntityFactory<TEntity> where TEntity : IEntity
    {
        TEntity Create(ICore core, IntPtr entityPointer, ushort id);
    }
}