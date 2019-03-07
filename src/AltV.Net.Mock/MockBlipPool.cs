using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockBlipPool : BlipPool
    {
        public MockBlipPool(IBaseObjectFactory<IBlip> blipFactory) : base(blipFactory)
        {
        }
    }
}