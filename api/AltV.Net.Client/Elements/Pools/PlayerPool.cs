using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class PlayerPool : EntityPool<IPlayer>, IPlayerPool
    {
        public ILocalPlayer LocalPlayer { get; private set; }

        public PlayerPool(IPlayerFactory entityFactory) : base(entityFactory)
        {
        }

        public void InitLocalPlayer(ICore core)
        {
            if (LocalPlayer is not null) return;

            unsafe
            {
                var localPlayerPointer = core.Library.Client.Player_GetLocal();
                var id = core.Library.Client.LocalPlayer_GetID(localPlayerPointer);

                var localPlayer = ((IPlayerFactory) _entityFactory).GetLocalPlayer(Alt.Core, localPlayerPointer, id);
                this.Add(localPlayer);
                this.LocalPlayer = localPlayer;
            }
        }

        protected sealed override uint GetId(IntPtr playerPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Player_GetID(playerPointer);
            }
        }
    }
}