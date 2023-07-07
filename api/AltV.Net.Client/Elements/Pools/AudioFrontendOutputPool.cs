using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioFrontendOutputPool : BaseObjectPool<IAudioFrontendOutput>
    {
        public AudioFrontendOutputPool(IBaseObjectFactory<IAudioFrontendOutput> factory) : base(factory)
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