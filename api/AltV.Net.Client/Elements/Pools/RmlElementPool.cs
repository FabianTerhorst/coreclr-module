using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class RmlElementPool : BaseObjectPool<IRmlElement>
    {
        public RmlElementPool(IBaseObjectFactory<IRmlElement> rmlElementFactory) : base(rmlElementFactory)
        {
        }
    }
}