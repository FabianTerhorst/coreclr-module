using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ReadOnlyPlayer : IPlayer
    {
        public static ReadOnlyPlayer Empty;
        
        public ushort Id { get; }
        public BaseObjectType Type { get; }
        private readonly Position position;
        private readonly Rotation rotation;
        private readonly short dimension;
        private readonly string name;
        private readonly ushort health;
        private readonly ushort armor;
        public uint Model { get; }
        public uint Ping { get; }

        public IntPtr NativePointer => IntPtr.Zero;
        public bool Exists => false;

        public Position Position
        {
            get => position;
            set { }
        }

        public Rotation Rotation
        {
            get => rotation;
            set { }
        }

        public short Dimension
        {
            get => dimension;
            set { }
        }

        public bool IsConnected { get; }

        public string Name
        {
            get => name;
            set
            {
                
            }
        }

        public ushort Health
        {
            get => health;
            set
            {
                
            }
        }

        public bool IsDead { get; }
        public bool IsJumping { get; }
        public bool IsInRagdoll { get; }
        public bool IsAiming { get; }
        public bool IsShooting { get; }
        public bool IsReloading { get; }

        public ushort Armor
        {
            get => armor;
            set
            {
                
            }
        }

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

        public void Kick(string reason)
        {
            throw new NotImplementedException();
        }

        public void SetPosition(float x, float y, float z) => throw new NotImplementedException();

        public void SetRotation(float roll, float pitch, float yaw) => throw new NotImplementedException();

        public bool GetMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void SetData(string key, object value) => throw new NotImplementedException();

        public bool GetData<T>(string key, out T result) => throw new NotImplementedException();

        public void Remove() => throw new NotImplementedException();

        public void Emit(string eventName, params object[] args) => throw new NotImplementedException();

        public ReadOnlyPlayer Copy() => throw new NotImplementedException();
    }
}