using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(ICore core, IntPtr playerPointer, uint id)
        {
            return new Player(core, playerPointer, id);
        }

        public ILocalPlayer GetLocalPlayer(ICore core, IntPtr localPlayerPointer, uint id)
        {
            return new LocalPlayer(core, localPlayerPointer, id);
        }
    }
}