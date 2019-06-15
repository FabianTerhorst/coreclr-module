using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape.Tests
{
    public class MockPlayer : IPlayer
    {
        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public BaseObjectType Type { get; }
        public void SetMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetMetaData(string key, ref MValue value)
        {
            throw new NotImplementedException();
        }

        public void GetMetaData(string key, ref MValue value)
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
        public short Dimension { get; set; }
        public ushort Id { get; }
        public Rotation Rotation { get; set; }
        public uint Model { get; set; }

        public void SetSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetSyncedMetaData(string key, ref MValue value)
        {
            throw new NotImplementedException();
        }

        public void GetSyncedMetaData(string key, ref MValue value)
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

        public ReadOnlyPlayer Copy()
        {
            throw new NotImplementedException();
        }
    }
}