using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncPlayer : AsyncEntity<IPlayer>, IPlayer
    {
        public uint Model { get; set; }
        public bool IsConnected { get; }
        public string Name { get; }
        public ulong SocialClubId { get; }
        public ulong HardwareIdHash { get; }
        public ulong HardwareIdExHash { get; }
        public string AuthToken { get; }
        public ushort Health { get; set; }
        public ushort MaxHealth { get; set; }
        public bool IsDead { get; }
        public bool IsJumping { get; }
        public bool IsInRagdoll { get; }
        public bool IsAiming { get; }
        public bool IsShooting { get; }
        public bool IsReloading { get; }
        public ushort Armor { get; set; }
        public ushort MaxArmor { get; set; }
        public float MoveSpeed { get; }
        public Position AimPosition { get; }
        public Rotation HeadRotation { get; }
        public bool IsInVehicle { get; }
        public IVehicle Vehicle { get; }
        public uint CurrentWeapon { get; set; }
        public IEntity EntityAimingAt { get; }
        public Position EntityAimOffset { get; }
        public bool IsFlashlightActive { get; }
        public byte Seat { get; }
        public uint Ping { get; }
        public string Ip { get; }
        
        public AsyncPlayer(IPlayer player, IAsyncContext asyncContext):base(player, asyncContext)
        {
        }
        
        public void Spawn(Position position, uint delayMs = 0)
        {
            throw new NotImplementedException();
        }

        public void Despawn()
        {
            throw new NotImplementedException();
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            throw new NotImplementedException();
        }

        public void SetWeather(uint weather)
        {
            throw new NotImplementedException();
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            throw new NotImplementedException();
        }

        public bool RemoveWeapon(uint weapon)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllWeapons()
        {
            throw new NotImplementedException();
        }

        public void Kick(string reason)
        {
            throw new NotImplementedException();
        }

        public void Emit(string eventName, params object[] args)
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

        public bool HasWeaponComponent(uint weapon, uint weaponComponent)
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

        public byte GetWeaponTintIndex(uint weapon)
        {
            throw new NotImplementedException();
        }

        public byte GetCurrentWeaponTintIndex()
        {
            throw new NotImplementedException();
        }

        public void ClearBloodDamage()
        {
            throw new NotImplementedException();
        }

        public Cloth GetClothes(byte component)
        {
            throw new NotImplementedException();
        }

        public void GetClothes(byte component, ref Cloth cloth)
        {
            throw new NotImplementedException();
        }

        public void SetClothes(byte component, ushort drawable, byte texture, byte palette)
        {
            throw new NotImplementedException();
        }

        public DlcCloth GetDlcClothes(byte component)
        {
            throw new NotImplementedException();
        }

        public void GetDlcClothes(byte component, ref DlcCloth cloth)
        {
            throw new NotImplementedException();
        }

        public void SetDlcClothes(byte component, ushort drawable, byte texture, byte palette, uint dlc)
        {
            throw new NotImplementedException();
        }

        public Prop GetProps(byte component)
        {
            throw new NotImplementedException();
        }

        public void GetProps(byte component, ref Prop prop)
        {
            throw new NotImplementedException();
        }

        public void SetProps(byte component, ushort drawable, byte texture)
        {
            throw new NotImplementedException();
        }

        public DlcProp GetDlcProps(byte component)
        {
            throw new NotImplementedException();
        }

        public void GetDlcProps(byte component, ref DlcProp prop)
        {
            throw new NotImplementedException();
        }

        public void SetDlcProps(byte component, ushort drawable, byte texture, uint dlc)
        {
            throw new NotImplementedException();
        }

        public void ClearProps(byte component)
        {
            throw new NotImplementedException();
        }

        public bool IsEntityInStreamingRange(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool TryCreateRef(out PlayerRef playerRef)
        {
            throw new NotImplementedException();
        }

        public bool Invincible { get; set; }
        public void SetIntoVehicle(IVehicle vehicle, byte seat)
        {
            throw new NotImplementedException();
        }
    }
}