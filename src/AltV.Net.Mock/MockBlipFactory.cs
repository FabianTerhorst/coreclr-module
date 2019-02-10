using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockBlipFactory<TEntity> : IEntityFactory<IBlip> where TEntity : IBlip
    {
        private readonly IEntityFactory<IBlip> blipFactory;

        public MockBlipFactory(IEntityFactory<IBlip> blipFactory)
        {
            this.blipFactory = blipFactory;
        }

        public IBlip Create(IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, IBlip>.Create((TEntity) blipFactory.Create(entityPointer, id),
                new MockBlip(entityPointer, id));
        }
    }
}