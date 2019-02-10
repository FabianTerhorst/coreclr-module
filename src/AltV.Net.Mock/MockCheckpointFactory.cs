using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpointFactory<TEntity> : IEntityFactory<ICheckpoint> where TEntity : ICheckpoint
    {
        private readonly IEntityFactory<ICheckpoint> checkpointFactory;

        public MockCheckpointFactory(IEntityFactory<ICheckpoint> checkpointFactory)
        {
            this.checkpointFactory = checkpointFactory;
        }

        public ICheckpoint Create(IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, ICheckpoint>.Create((TEntity) checkpointFactory.Create(entityPointer, id),
                new MockCheckpoint(entityPointer, id));
        }
    }
}