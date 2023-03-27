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

        public IPlayer Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, IPlayer>.Create((TEntity) playerFactory.Create(core, entityPointer, id),
                new MockPlayer(core, entityPointer, id));
        }
    }
}