using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net
{
    public interface IEntityPool<TEntity> where TEntity : IEntity
    {
        void Create(IntPtr entityPointer, ushort id);
        
        void Create(IntPtr entityPointer, ushort id, out TEntity entity);
        
        void Create(IntPtr entityPointer, out TEntity entity);

        void Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Remove(IntPtr entityPointer);

        bool Get(IntPtr entityPointer, out TEntity entity);

        bool GetOrCreate(IntPtr entityPointer, ushort entityId, out TEntity entity);
        
        bool GetOrCreate(IntPtr entityPointer, out TEntity entity);

        ICollection<TEntity> GetAllEntities();

        KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray();

        void ForEach(IBaseObjectCallback<TEntity> baseObjectCallback);
        
        Task ForEach(IAsyncBaseObjectCallback<TEntity> asyncBaseObjectCallback);

        void OnAdd(TEntity entity);

        void OnRemove(TEntity entity);
        
        void Dispose();
    }
}