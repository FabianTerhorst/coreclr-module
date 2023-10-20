using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVirtualEntityGroupFactory<TEntity> : IBaseObjectFactory<IVirtualEntityGroup> where TEntity : IVirtualEntityGroup
    {
        private readonly IBaseObjectFactory<IVirtualEntityGroup> virtualEntityGroupFactory;

        public MockVirtualEntityGroupFactory(IBaseObjectFactory<IVirtualEntityGroup> virtualEntityGroupFactory)
        {
            this.virtualEntityGroupFactory = virtualEntityGroupFactory;
        }

        public IVirtualEntityGroup Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, IVirtualEntityGroup>.Create((TEntity) virtualEntityGroupFactory.Create(core, entityPointer, id),
                new MockVirtualEntityGroup(core, entityPointer, id));
        }
    }
}