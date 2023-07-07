using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioAttachedOutputPool : BaseObjectPool<IAudioAttachedOutput>
    {
        public AudioAttachedOutputPool(IBaseObjectFactory<IAudioAttachedOutput> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.AudioAttachedOutput_GetID(entityPointer);
            }
        }
    }
}