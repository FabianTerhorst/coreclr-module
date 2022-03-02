using System.Diagnostics.Tracing;
using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Factories
{
    public class PlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IClient client, IntPtr playerPointer, ushort id)
        {
            return new Player(client, playerPointer, id);
        }
    }
}