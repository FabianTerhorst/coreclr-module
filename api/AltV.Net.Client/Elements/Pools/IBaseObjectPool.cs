using System.Collections.Generic;
using AltV.Net.Client.Elements.Entities;
using WebAssembly;

namespace AltV.Net.Client.Elements.Pools
{
    public interface IBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        void Create(JSObject entityPointer);
        void Create(JSObject entityPointer, out TBaseObject entity);
        void Add(TBaseObject entity);
        bool Remove(TBaseObject entity);
        bool Remove(JSObject entityPointer);
        bool Get(JSObject entityPointer, out TBaseObject entity);
        bool GetOrCreate(JSObject entityPointer, out TBaseObject entity);
        ICollection<TBaseObject> GetAllObjects();
        KeyValuePair<int, TBaseObject>[] GetObjectsArray();
    }
}