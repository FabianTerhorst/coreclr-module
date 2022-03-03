using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Entities
{
    public class LocalPlayer : Player, ILocalPlayer
    {
        private static IntPtr GetPlayerPointer(ICore core, IntPtr localPlayerPointer)
        {
            unsafe
            {
                return core.Library.LocalPlayer_GetPlayer(localPlayerPointer);
            }
        }
        
        public LocalPlayer(ICore core, IntPtr localPlayerPointer, ushort id) : base(core, GetPlayerPointer(core, localPlayerPointer), id)
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
                    return Core.Library.LocalPlayer_GetCurrentAmmo(LocalPlayerNativePointer);
                }
            }
        }
    }
}