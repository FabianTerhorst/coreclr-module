using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class VehiclePool : EntityPool<IVehicle>
    {
        public VehiclePool(IEntityFactory<IVehicle> vehicleFactory) : base(vehicleFactory)
        {
        }
    }
}