using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVehicleFactory<TEntity> : IEntityFactory<IVehicle> where TEntity : IVehicle
    {
        private readonly IEntityFactory<IVehicle> vehicleFactory;

        public MockVehicleFactory(IEntityFactory<IVehicle> vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
        }

        public IVehicle Create(IServer server, IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, IVehicle>.Create((TEntity) vehicleFactory.Create(server, entityPointer, id),
                new MockVehicle(server, entityPointer, id));
        }
    }
}