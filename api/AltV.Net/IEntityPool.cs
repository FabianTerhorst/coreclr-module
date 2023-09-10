using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net
{
    public interface IEntityPool<TEntity> : IReadOnlyEntityPool<TEntity> where TEntity : IEntity
    {
        TEntity Create(ICore core, IntPtr entityPointer, uint id);

        TEntity Create(ICore core, IntPtr entityPointer);

        void Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Remove(IntPtr entityPointer);

        TEntity GetOrCreate(ICore core, IntPtr entityPointer, uint entityId);

        TEntity GetOrCreate(ICore core, IntPtr entityPointer);

        KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray();

        void ForEach(IBaseObjectCallback<TEntity> baseObjectCallback);

        Task ForEach(IAsyncBaseObjectCallback<TEntity> asyncBaseObjectCallback);

        void OnAdd(TEntity entity);

        void OnRemove(TEntity entity);

        void Dispose();
    }
}