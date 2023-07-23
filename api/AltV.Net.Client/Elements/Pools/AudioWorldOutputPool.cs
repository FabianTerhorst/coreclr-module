using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioWorldOutputPool : BaseObjectPool<IAudioWorldOutput>
    {
        public AudioWorldOutputPool(IBaseObjectFactory<IAudioWorldOutput> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.AudioWorldOutput_GetID(entityPointer);
            }
        }
    }
}