namespace AltV.Net.Shared.Elements.Entities;

public interface ISharedPed : ISharedEntity
{
    IntPtr PedNativePointer { get; }

    ushort Armour { get; }
    ushort Health { get; }
    ushort MaxHealth { get; }
    uint CurrentWeapon { get; }

}