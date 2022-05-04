using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities
{
    public class LocalPlayer : Player, ILocalPlayer
    {
        private static IntPtr GetPlayerPointer(ICore core, IntPtr localPlayerPointer)
        {
            unsafe
            {
                return core.Library.Client.LocalPlayer_GetPlayer(localPlayerPointer);
            }
        }

        public LocalPlayer(ICore core, IntPtr localPlayerPointer, ushort id) : base(core, GetPlayerPointer(core, localPlayerPointer), id, BaseObjectType.LocalPlayer)
        {
            LocalPlayerNativePointer = localPlayerPointer;
        }

        public IntPtr LocalPlayerNativePointer { get; }

        public override bool IsLocal => true;

        public ushort CurrentAmmo
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.LocalPlayer_GetCurrentAmmo(LocalPlayerNativePointer);
                }
            }
        }
    }
}