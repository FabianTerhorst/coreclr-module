using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpointFactory<TEntity> : IBaseObjectFactory<ICheckpoint> where TEntity : ICheckpoint
    {
        private readonly IBaseObjectFactory<ICheckpoint> checkpointFactory;

        public MockCheckpointFactory(IBaseObjectFactory<ICheckpoint> checkpointFactory)
        {
            this.checkpointFactory = checkpointFactory;
        }

        public ICheckpoint Create(IntPtr entityPointer)
        {
            return MockDecorator<TEntity, ICheckpoint>.Create((TEntity) checkpointFactory.Create(entityPointer),
                new MockCheckpoint(entityPointer));
        }
    }
}