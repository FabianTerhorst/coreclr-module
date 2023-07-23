using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockPedFactory<TEntity> : IEntityFactory<IPed> where TEntity : IPed
    {
        private readonly IEntityFactory<IPed> pedFactory;

        public MockPedFactory(IEntityFactory<IPed> pedFactory)
        {
            this.pedFactory = pedFactory;
        }

        public IPed Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, IPed>.Create((TEntity) pedFactory.Create(core, entityPointer, id),
                new MockPed(core, entityPointer, id));
        }
    }
}