using System.Diagnostics.Tracing;
using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(ICore core, IntPtr playerPointer, ushort id)
        {
            return new Player(core, playerPointer, id);
        }
        
        public ILocalPlayer GetLocalPlayer(ICore core, IntPtr localPlayerPointer, ushort id)
        {
            return new LocalPlayer(core, localPlayerPointer, id);
        }
    }
}