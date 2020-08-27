using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net
{
    [StructLayout(LayoutKind.Sequential)]  
    public readonly struct FireInfo
    {
        public readonly Position Position;
        public readonly uint WeaponHash;

        public FireInfo(Position position, uint weaponHash)
        {
            Position = position;
            WeaponHash = weaponHash;
        }
    }
}