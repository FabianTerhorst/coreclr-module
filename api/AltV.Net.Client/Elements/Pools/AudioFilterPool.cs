using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioFilterPool : BaseObjectPool<IAudioFilter>
    {
        public AudioFilterPool(IBaseObjectFactory<IAudioFilter> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.AudioFilter_GetID(entityPointer);
            }
        }
    }
}