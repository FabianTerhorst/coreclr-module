using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class LocalVehiclePool : BaseObjectPool<ILocalVehicle>
    {
        public LocalVehiclePool(IBaseObjectFactory<ILocalVehicle> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Client.LocalVehicle_GetID(entityPointer);
            }
        }
    }
}