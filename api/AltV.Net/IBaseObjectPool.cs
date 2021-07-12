using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net
{
    public interface IBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        void Create(IServer server, IntPtr entityPointer);
        void Create(IServer server, IntPtr entityPointer, out TBaseObject entity);
        void Add(TBaseObject entity);
        bool Remove(TBaseObject entity);
        bool Remove(IntPtr entityPointer);
        bool Get(IntPtr entityPointer, out TBaseObject entity);
        bool GetOrCreate(IServer server, IntPtr entityPointer, out TBaseObject entity);
        ICollection<TBaseObject> GetAllObjects();
        KeyValuePair<IntPtr, TBaseObject>[] GetObjectsArray();
        void ForEach(IBaseObjectCallback<TBaseObject> baseObjectCallback);
        Task ForEach(IAsyncBaseObjectCallback<TBaseObject> asyncBaseObjectCallback);
        void Dispose();
    }
}