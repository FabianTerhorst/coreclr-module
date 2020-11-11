using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Refs;

namespace AltV.Net.ColShape.Tests
{
    public class MockPlayer : IPlayer
    {
        public IntPtr NativePointer { get; }
        public IPlayer NetworkOwner { get; }
        public bool Exists { get; }
        public BaseObjectType Type { get; }
        public ushort MaxHealth { get; set; }
        public ushort MaxArmor { get; set; }
        public uint CurrentWeapon { get; set; }
        public IEntity EntityAimingAt { get; }
        public Position EntityAimOffset { get; }
        public bool IsFlashlightActive { get; }
        public string Ip { get; }

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

        public void ResetNetworkOwner()
        {
            throw new NotImplementedException();
        }

        public void SetNetworkOwner(IPlayer player, bool disableMigration)
        {
            throw new NotImplementedException();
        }

        public bool HasData(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(string key)
        {
            throw new NotImplementedException();
        }

        public bool HasMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public bool HasSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteStreamSyncedMetaData(string key)
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

        public void SetMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetMetaData(string key, in MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void GetMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void SetData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void CheckIfEntityExists()
        {
            throw new NotImplementedException();
        }

        public Position Position { get; set; }
        public int Dimension { get; set; }
        public ushort Id { get; }
        public Rotation Rotation { get; set; }
        public uint Model { get; set; }

        public MockPlayer()
        {
            Exists = true;
        }

        public void SetSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected { get; }
        public string Name { get; set; }
        public ushort Health { get; set; }
        public bool IsDead { get; }
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
        public bool IsInVehicle { get; }
        public IVehicle Vehicle { get; }
        public byte Seat { get; }
        public uint Ping { get; }
        public ulong SocialClubId { get; }
        public ulong HardwareIdHash { get; }
        public ulong HardwareIdExHash { get; }
        public string AuthToken { get; }

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

        public void RemoveWeapon(uint weapon)
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

        public void OnRemove()
        {
            throw new NotImplementedException();
        }

        public bool AddRef()
        {
            throw new NotImplementedException();
        }

        public bool RemoveRef()
        {
            throw new NotImplementedException();
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllDataKeys()
        {
            throw new NotImplementedException();
        }

        public bool TryCreateRef(out PlayerRef playerRef)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out int value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out uint value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out float value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            throw new NotImplementedException();
        }
    }
}