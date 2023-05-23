using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class LocalPedPool : BaseObjectPool<ILocalPed>
    {
        public LocalPedPool(IBaseObjectFactory<ILocalPed> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Client.LocalPed_GetID(entityPointer);
            }
        }
    }
}