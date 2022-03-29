using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public interface IEntityPool<TEntity> where TEntity : IEntity
    {
        TEntity? Create(ICore server, IntPtr entityPointer, ushort id);
        
        TEntity? Create(ICore server, IntPtr entityPointer);

        void Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Remove(IntPtr entityPointer);

        TEntity? Get(IntPtr entityPointer);

        TEntity GetOrCreate(ICore server, IntPtr entityPointer, ushort entityId);
        TEntity GetOrCreate(ICore server, IntPtr entityPointer);

        ICollection<TEntity> GetAllEntities();

        KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray();

        void OnAdd(TEntity entity);

        void OnRemove(TEntity entity);
        
        void Dispose();
    }
}