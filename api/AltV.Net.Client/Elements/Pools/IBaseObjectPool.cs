using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public interface IBaseObjectPool<TBaseObject> : IReadOnlyBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        TBaseObject Create(ICore core, IntPtr entityPointer, uint id);
        void Add(TBaseObject entity);
        bool Remove(TBaseObject entity);
        bool Remove(IntPtr entityPointer);
        TBaseObject GetOrCreate(ICore core, IntPtr entityPointer);
        KeyValuePair<IntPtr, TBaseObject>[] GetObjectsArray();
        void Dispose();
    }
}