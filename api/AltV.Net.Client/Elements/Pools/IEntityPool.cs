using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public interface IEntityPool<TEntity> where TEntity : IEntity
    {
        void Create(IClient server, IntPtr entityPointer, ushort id);
        
        void Create(IClient server, IntPtr entityPointer, ushort id, out TEntity entity);
        
        void Create(IClient server, IntPtr entityPointer, out TEntity entity);

        void Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Remove(IntPtr entityPointer);

        bool Get(IntPtr entityPointer, out TEntity entity);

        bool GetOrCreate(IClient server, IntPtr entityPointer, ushort entityId, out TEntity entity);
        
        bool GetOrCreate(IClient server, IntPtr entityPointer, out TEntity entity);

        ICollection<TEntity> GetAllEntities();

        KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray();

        // void ForEach(IBaseObjectCallback<TEntity> baseObjectCallback);
        //
        // Task ForEach(IAsyncBaseObjectCallback<TEntity> asyncBaseObjectCallback);

        void OnAdd(TEntity entity);

        void OnRemove(TEntity entity);
        
        void Dispose();
    }
}