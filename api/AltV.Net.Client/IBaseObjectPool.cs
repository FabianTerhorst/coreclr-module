using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public interface IBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        TBaseObject Create(ICore core, IntPtr entityPointer);
        void Add(TBaseObject entity);
        bool Remove(TBaseObject entity);
        bool Remove(IntPtr entityPointer);
        TBaseObject Get(IntPtr entityPointer);
        TBaseObject GetOrCreate(ICore core, IntPtr entityPointer);
        ICollection<TBaseObject> GetAllObjects();
        KeyValuePair<IntPtr, TBaseObject>[] GetObjectsArray();
        void Dispose();
    }
}