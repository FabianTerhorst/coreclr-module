using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class RmlElementPool : BaseObjectPool<IRmlElement>
    {
        public RmlElementPool(IBaseObjectFactory<IRmlElement> rmlElementFactory) : base(rmlElementFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.RmlElement_GetID(entityPointer);
            }
        }
    }
}