using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class TextLabelPool : BaseObjectPool<ITextLabel>
    {
        public TextLabelPool(IBaseObjectFactory<ITextLabel> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.TextLabel_GetID(entityPointer);
            }
        }
    }
}