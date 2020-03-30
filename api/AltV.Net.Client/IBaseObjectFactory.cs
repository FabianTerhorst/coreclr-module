using AltV.Net.Client.Elements.Entities;
using WebAssembly;

namespace AltV.Net.Client
{
    public interface IBaseObjectFactory<out TBaseObject> where TBaseObject : IBaseObject
    {
        TBaseObject Create(JSObject jsObject);
    }
}