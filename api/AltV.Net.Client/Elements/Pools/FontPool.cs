using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class FontPool : BaseObjectPool<IFont>
    {
        public FontPool(IBaseObjectFactory<IFont> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Client.Font_GetID(entityPointer);
            }
        }
    }
}