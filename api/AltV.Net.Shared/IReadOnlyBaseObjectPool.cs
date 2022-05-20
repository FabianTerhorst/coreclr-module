using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net
{
    public interface IReadOnlyBaseObjectPool<out TBaseObject> where TBaseObject : ISharedBaseObject
    {
        TBaseObject Get(IntPtr entityPointer);

        IReadOnlyCollection<TBaseObject> GetAllObjects();
    }
}