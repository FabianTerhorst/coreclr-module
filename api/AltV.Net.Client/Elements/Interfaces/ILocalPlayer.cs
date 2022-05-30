namespace AltV.Net.Client.Elements.Interfaces
{
    public interface ILocalPlayer : IPlayer
    {
        public IntPtr LocalPlayerNativePointer { get; }
        ushort CurrentAmmo { get; }
        float CurrentWeaponRecoil { get; }
        float CurrentWeaponSpread { get; }
        float CurrentWeaponDamage { get; }
        float CurrentWeaponRange { get; }
    }
}