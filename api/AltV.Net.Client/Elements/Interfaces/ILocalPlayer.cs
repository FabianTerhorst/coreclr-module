using AltV.Net.Client.Elements.Data;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface ILocalPlayer : IPlayer
    {
        IntPtr LocalPlayerNativePointer { get; }
        WeaponData GetWeaponData();
        
        ushort CurrentAmmo { get; }
    }
}