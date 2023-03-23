using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities;

public interface IPed : ISharedPed, IEntity
{
    new ushort Armour { get; set; }
    new ushort Health { get; set; }
    new ushort MaxHealth { get; set; }
    new uint CurrentWeapon { get; set; }
}