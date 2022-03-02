using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;

namespace AltV.Net.Client.Elements.Pools
{
    public class PlayerPool : EntityPool<IPlayer>
    {
        internal IPlayer LocalPlayer { get; }

        public PlayerPool(IEntityFactory<IPlayer> entityFactory) : base(entityFactory)
        {
            unsafe
            {
                this.GetOrCreate(Alt.Core, Alt.Core.Library.Player_GetLocal(), out var localPlayer);
                this.LocalPlayer = localPlayer;
            }
        }

        protected override ushort GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Player_GetID(entityPointer);
            }
        }
    }
}