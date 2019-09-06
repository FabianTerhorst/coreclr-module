using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockPlayerFactory<TEntity> : IEntityFactory<IPlayer> where TEntity : IPlayer
    {
        private readonly IEntityFactory<IPlayer> playerFactory;

        public MockPlayerFactory(IEntityFactory<IPlayer> playerFactory)
        {
            this.playerFactory = playerFactory;
        }

        public IPlayer Create(IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, IPlayer>.Create((TEntity) playerFactory.Create(entityPointer, id),
                new MockPlayer(entityPointer, id));
        }
    }
}