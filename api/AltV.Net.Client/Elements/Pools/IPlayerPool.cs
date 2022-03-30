using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public interface IPlayerPool : IEntityPool<IPlayer>
    {
        ILocalPlayer LocalPlayer { get; }        
    }
}