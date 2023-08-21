using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockObjectFactory<TEntity> : IEntityFactory<IObject> where TEntity : IObject
    {
        private readonly IEntityFactory<IObject> factory;

        public MockObjectFactory(IEntityFactory<IObject> factory)
        {
            this.factory = factory;
        }

        public IObject Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, IObject>.Create((TEntity)factory.Create(core, entityPointer, id),
                new MockObject(core, entityPointer, id));
        }
    }
}