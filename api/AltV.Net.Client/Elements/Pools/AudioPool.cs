using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioPool : BaseObjectPool<IAudio>
    {
        public AudioPool(IBaseObjectFactory<IAudio> audioFactory) : base(audioFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Audio_GetID(entityPointer);
            }
        }
    }
}