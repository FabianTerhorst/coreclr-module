using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        void Create(IntPtr entityPointer, out TBaseObject entity);
        void Add(TBaseObject entity);
        bool Remove(TBaseObject entity);
        bool Remove(IntPtr entityPointer);
        bool Get(IntPtr entityPointer, out TBaseObject entity);
        bool GetOrCreate(IntPtr entityPointer, out TBaseObject entity);
        ICollection<TBaseObject> GetAllObjects();
    }
}