using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public interface IEntityPool<TEntity> : IReadOnlyEntityPool<TEntity> where TEntity : IEntity
    {
        TEntity? Create(ICore core, IntPtr entityPointer, uint id);

        TEntity? Create(ICore core, IntPtr entityPointer);

        void Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Remove(IntPtr entityPointer);

        TEntity GetOrCreate(ICore core, IntPtr entityPointer, uint entityId);
        TEntity GetOrCreate(ICore core, IntPtr entityPointer);

        KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray();

        void OnAdd(TEntity entity);

        void OnRemove(TEntity entity);

        void Dispose();
    }
}