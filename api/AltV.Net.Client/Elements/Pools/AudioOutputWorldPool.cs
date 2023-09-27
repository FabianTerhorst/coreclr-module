using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioOutputWorldPool : BaseObjectPool<IAudioOutputWorld>
    {
        public AudioOutputWorldPool(IBaseObjectFactory<IAudioOutputWorld> factory) : base(factory)
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