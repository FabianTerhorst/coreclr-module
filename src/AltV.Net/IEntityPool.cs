using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IEntityPool<TEntity> where TEntity : IEntity
    {
        void Create(IntPtr entityPointer, out TEntity entity);

        void Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Remove(IntPtr entityPointer);

        bool Get(IntPtr entityPointer, out TEntity entity);

        bool GetOrCreate(IntPtr entityPointer, out TEntity entity);

        Dictionary<IntPtr, TEntity>.ValueCollection GetAllEntities();
    }
}