using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockNetworkObjectFactory<TEntity> : IEntityFactory<INetworkObject> where TEntity : INetworkObject
    {
        private readonly IEntityFactory<INetworkObject> factory;

        public MockNetworkObjectFactory(IEntityFactory<INetworkObject> factory)
        {
            this.factory = factory;
        }

        public INetworkObject Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, INetworkObject>.Create((TEntity) factory.Create(core, entityPointer, id),
                new MockNetworkObject (core, entityPointer, id));
        }
    }
}