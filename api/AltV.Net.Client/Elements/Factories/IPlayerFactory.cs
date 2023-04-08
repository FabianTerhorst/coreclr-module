using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public interface IPlayerFactory : IEntityFactory<IPlayer>
    {
        public ILocalPlayer GetLocalPlayer(ICore core, IntPtr localPlayerPointer, uint id);
    }
}