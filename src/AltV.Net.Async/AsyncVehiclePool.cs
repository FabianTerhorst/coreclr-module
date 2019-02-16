using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public class AsyncVehiclePool : AsyncEntityPool<IVehicle>
    {
        public AsyncVehiclePool(IEntityFactory<IVehicle> entityFactory) : base(entityFactory)
        {
        }
    }
}