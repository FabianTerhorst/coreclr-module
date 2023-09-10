using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioOutputPool : BaseObjectPool<IAudioOutput>
    {
        public AudioOutputPool(IBaseObjectFactory<IAudioOutput> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.AudioOutput_GetID(entityPointer);
            }
        }
    }
}