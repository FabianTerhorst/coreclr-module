using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class VehiclePool : EntityPool<IVehicle>
    {
        public VehiclePool(IEntityFactory<IVehicle> entityFactory) : base(entityFactory)
        {
        }
        
        protected override ushort GetId(IntPtr vehiclePointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Vehicle_GetID(vehiclePointer);
            }
        }
    }
}