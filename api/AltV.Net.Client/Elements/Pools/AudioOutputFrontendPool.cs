using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioOutputFrontendPool : BaseObjectPool<IAudioOutputFrontend>
    {
        public AudioOutputFrontendPool(IBaseObjectFactory<IAudioOutputFrontend> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.AudioFrontendOutput_GetID(entityPointer);
            }
        }
    }
}