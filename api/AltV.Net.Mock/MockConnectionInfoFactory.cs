using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockConnectionInfoFactory<TEntity> : IBaseObjectFactory<IConnectionInfo> where TEntity : IConnectionInfo
    {
        private readonly IBaseObjectFactory<IConnectionInfo> factory;

        public MockConnectionInfoFactory(IBaseObjectFactory<IConnectionInfo> factory)
        {
            this.factory = factory;
        }

        public IConnectionInfo Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, IConnectionInfo>.Create((TEntity) factory.Create(core, entityPointer, id),
                new MockConnectionInfo(core, entityPointer, id));
        }
    }
}