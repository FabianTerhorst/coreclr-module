using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class RmlElementPool : BaseObjectPool<IRmlElement>
    {
        public RmlElementPool(IBaseObjectFactory<IRmlElement> rmlElementFactory) : base(rmlElementFactory)
        {
        }
    }
}