using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Mock
{
    public class MockPlayer : MockEntity, IPlayer
    {
        public MockPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, BaseObjectType.Player, id)
        {
        }

        public bool IsConnected { get; }
        public string Name { get; set; }
        public ushort Health { get; set; }
        public bool IsDead { get; set; }
        public bool IsJumping { get; }
        public bool IsInRagdoll { get; }
        public bool IsAiming { get; }
        public bool IsShooting { get; }
        public bool IsReloading { get; }
        public ushort Armor { get; set; }
        public float MoveSpeed { get; }
        public uint Weapon { get; }
        public ushort Ammo { get; }
        public Position AimPosition { get; }
        public Rotation HeadRotation { get; }
        public bool IsInVehicle { get; set; }
        public IVehicle Vehicle { get; set; }
        public byte Seat { get; set; }
        public uint Ping { get; }
        public ushort MaxHealth { get; set; }
        public ushort MaxArmor { get; set; }
        public uint CurrentWeapon { get; set; }
        public IEntity EntityAimingAt { get; }
        public Position EntityAimOffset { get; }
        public bool IsFlashlightActive { get; }
        public string Ip { get; }
        public ulong SocialClubId { get; }
        public ulong HardwareIdHash { get; }
        public ulong HardwareIdExHash { get; }
        public string AuthToken { get; }

        bool IPlayer.RemoveWeapon(uint weapon)
        {
            throw new NotImplementedException();
        }

        public bool HasWeaponComponent(uint weapon, uint weaponComponent)
        {
            throw new NotImplementedException();
        }

        public byte GetWeaponTintIndex(uint weapon)
        {
            throw new NotImplementedException();
        }

        public void AddWeaponComponent(uint weapon, uint weaponComponent)
        {
            throw new NotImplementedException();
        }

        public void RemoveWeaponComponent(uint weapon, uint weaponComponent)
        {
            throw new NotImplementedException();
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            throw new NotImplementedException();
        }

        public void SetWeaponTintIndex(uint weapon, byte tintIndex)
        {
            throw new NotImplementedException();
        }

        public byte GetCurrentWeaponTintIndex()
        {
            throw new NotImplementedException();
        }

        public void Spawn(Position position, uint delayMs)
        {
        }

        public void Despawn()
        {
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
        }

        public void SetWeather(uint weather)
        {
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
        }

        public void RemoveWeapon(uint weapon)
        {
        }

        public void RemoveAllWeapons()
        {
        }

        public void Kick(string reason)
        {
            if (Exists)
            {
                this.Disconnect(reason);
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            if (Exists)
            {
                Alt.Server.TriggerClientEvent(this, eventName, args);
            }
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public bool TryCreateRef(out PlayerRef playerRef)
        {
            throw new NotImplementedException();
        }
    }
}