using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public interface IAsyncBaseObjectCallback<in TBaseObject> where TBaseObject: IBaseObject
    {
        Task OnBaseObject(TBaseObject baseObject);
    }
}