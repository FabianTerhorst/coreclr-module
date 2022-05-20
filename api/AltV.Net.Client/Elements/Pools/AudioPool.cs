using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioPool : BaseObjectPool<IAudio>
    {
        public AudioPool(IBaseObjectFactory<IAudio> audioFactory) : base(audioFactory)
        {
        }
    }
}