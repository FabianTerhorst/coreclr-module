using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVirtualEntityFactory<TEntity> : IBaseObjectFactory<IVirtualEntity> where TEntity : IVirtualEntity
    {
        private readonly IBaseObjectFactory<IVirtualEntity> virtualEntityFactory;

        public MockVirtualEntityFactory(IBaseObjectFactory<IVirtualEntity> virtualEntityFactory)
        {
            this.virtualEntityFactory = virtualEntityFactory;
        }

        public IVirtualEntity Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, IVirtualEntity>.Create(
                (TEntity)virtualEntityFactory.Create(core, entityPointer, id),
                new MockVirtualEntity(core, entityPointer, id));
        }
    }
}