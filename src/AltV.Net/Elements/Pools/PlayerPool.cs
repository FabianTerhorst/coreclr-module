using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class PlayerPool : EntityPool<IPlayer>
    {
        public PlayerPool(IEntityFactory<IPlayer> playerFactory) : base(playerFactory)
        {
        }
    }
}