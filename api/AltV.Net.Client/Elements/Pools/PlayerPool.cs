using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class PlayerPool : EntityPool<IPlayer>, IPlayerPool
    {
        public ILocalPlayer LocalPlayer { get; }

        public PlayerPool(IPlayerFactory entityFactory) : base(entityFactory)
        {
            unsafe
            {
                var localPlayerPointer = Alt.Core.Library.Player_GetLocal();
                var id = Alt.Core.Library.LocalPlayer_GetID(localPlayerPointer);
                Alt.Log("Local player has ID " + id);
                
                var localPlayer = entityFactory.GetLocalPlayer(Alt.Core, localPlayerPointer, id);
                this.Add(localPlayer);
                this.LocalPlayer = localPlayer;
            }
        }

        protected sealed override ushort GetId(IntPtr playerPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Player_GetID(playerPointer);
            }
        }
    }
}