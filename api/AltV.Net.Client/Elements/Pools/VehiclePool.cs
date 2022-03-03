using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;

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
                Console.WriteLine("Getting ID");
                var entityPointer = Alt.Core.Library.Vehicle_GetEntity(vehiclePointer);
                var id = Alt.Core.Library.Entity_GetID(entityPointer);
                Console.WriteLine("ID was " + id);
                return id;
            }
        }
    }
}