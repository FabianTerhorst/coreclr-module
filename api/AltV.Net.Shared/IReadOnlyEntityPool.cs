using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net
{
    public interface IReadOnlyEntityPool<out TEntity> where TEntity : ISharedEntity
    {
        TEntity Get(IntPtr entityPointer);

        IReadOnlyCollection<TEntity> GetAllEntities();
    }
}