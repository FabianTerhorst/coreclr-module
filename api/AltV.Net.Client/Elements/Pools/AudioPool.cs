using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class AudioPool : BaseObjectPool<IAudio>
    {
        public AudioPool(IBaseObjectFactory<IAudio> audioFactory) : base(audioFactory)
        {
        }
    }
}