using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public interface IBaseObjectFactory<out TBaseObject> where TBaseObject : IBaseObject
    {
        TBaseObject Create(ICore core, IntPtr baseObjectPointer);
    }
}