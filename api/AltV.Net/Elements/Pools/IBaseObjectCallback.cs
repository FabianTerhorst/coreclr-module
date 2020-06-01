using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public interface IBaseObjectCallback<in TBaseObject> where TBaseObject: IBaseObject
    {
        void OnBaseObject(TBaseObject baseObject);
    }
}