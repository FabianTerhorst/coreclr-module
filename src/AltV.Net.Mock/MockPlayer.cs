using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockPlayer : IPlayer
    {
        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public ushort Id { get; }
        public EntityType Type { get; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public ushort Dimension { get; set; }

        public MockPlayer(IntPtr nativePointer, ushort id)
        {
            NativePointer = nativePointer;
            Type = EntityType.Player;
            Id = id;
            Exists = true;
        }

        public void SetPosition(float x, float y, float z)
        {
        }

        public void SetRotation(float roll, float pitch, float yaw)
        {
        }

        public void SetMetaData(string key, MValue value)
        {
        }

        public MValue GetMetaData(string key)
        {
            return MValue.Nil;
        }

        public void SetData(string key, object value)
        {
        }

        public bool GetData<T>(string key, out T result)
        {
            result = default;
            return false;
        }

        public bool Remove()
        {
            return false;
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

        public void Spawn(Position position)
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

        public void Kick(string reason)
        {
        }

        public void Emit(string eventName, params object[] args)
        {
        }

        public ReadOnlyPlayer Copy()
        {
            return ReadOnlyPlayer.Empty;
        }
    }
}