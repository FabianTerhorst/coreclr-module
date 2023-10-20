using AltV.Net.Data;
using WeaponData = AltV.Net.Client.Elements.Data.WeaponData;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface ILocalPlayer : IPlayer
    {
        IntPtr LocalPlayerNativePointer { get; }
        WeaponData GetWeaponData();

        ushort CurrentAmmo { get; }

        ushort GetWeaponAmmo(uint weaponHash);

        bool HasWeapon(uint weaponHash);

        uint[] Weapons();

        uint[] WeaponComponents(uint weaponHash);

        float Stamina { get; set; }
        float MaxStamina { get; set; }

        int Dimension { get; }
    }
}