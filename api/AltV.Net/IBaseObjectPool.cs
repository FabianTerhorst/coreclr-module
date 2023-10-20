using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net
{
    public interface IBaseObjectPool<TBaseObject> : IReadOnlyBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        TBaseObject Create(ICore core, IntPtr entityPointer, uint id);
        void Add(TBaseObject entity);
        bool Remove(TBaseObject entity);
        bool Remove(IntPtr entityPointer);
        TBaseObject GetOrCreate(ICore core, IntPtr entityPointer, uint entityId);
        TBaseObject GetOrCreate(ICore core, IntPtr entityPointer);
        KeyValuePair<IntPtr, TBaseObject>[] GetObjectsArray();
        void ForEach(IBaseObjectCallback<TBaseObject> baseObjectCallback);
        Task ForEach(IAsyncBaseObjectCallback<TBaseObject> asyncBaseObjectCallback);
        void Dispose();
    }
}