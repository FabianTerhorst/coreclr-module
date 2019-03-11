using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ReadOnlyPlayer : IPlayer, IDisposable
    {
        public static ReadOnlyPlayer Empty;

        private ushort id;
        private Position position;
        private Rotation rotation;
        private short dimension;
        private uint ping;
        private uint model;
        private byte seat;
        private Position aimPosition;
        private Rotation headRotation;
        private ushort armor;
        private float moveSpeed;
        private IntPtr name;
        private ushort health;
        private bool isInRagdoll;
        private bool isDead;
        private bool isShooting;
        private bool isAiming;
        private bool isInVehicle;
        private bool isJumping;
        private bool isReloading;
        private bool isConnected;
        private IntPtr vehiclePointer;

        public IntPtr NativePointer => IntPtr.Zero;
        public bool Exists => false;
        public BaseObjectType Type => BaseObjectType.Player;

        public void SetMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetData(string key, object value)
        {
            Origin.SetData(key, value);
        }

        public bool GetData<T>(string key, out T result)
        {
            return Origin.GetData(key, out result);
        }

        public Position Position
        {
            get => position;
            set => throw new NotImplementedException();
        }

        public short Dimension
        {
            get => dimension;
            set => throw new NotImplementedException();
        }

        public ushort Id => id;

        public Rotation Rotation
        {
            get => rotation;
            set => throw new NotImplementedException();
        }

        public uint Model => model;

        public void SetSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected => isConnected;

        public string Name
        {
            get => Marshal.PtrToStringAnsi(name);
            set => throw new NotImplementedException();
        }

        public ushort Health
        {
            get => health;
            set => throw new NotImplementedException();
        }

        public bool IsDead => isDead;
        public bool IsJumping => isJumping;
        public bool IsInRagdoll => isInRagdoll;
        public bool IsAiming => isAiming;
        public bool IsShooting => isShooting;
        public bool IsReloading => isReloading;

        public ushort Armor
        {
            get => armor;
            set => throw new NotImplementedException();
        }

        public float MoveSpeed => moveSpeed;
        public uint Weapon => throw new NotImplementedException();
        public ushort Ammo => throw new NotImplementedException();
        public Position AimPosition => aimPosition;
        public Rotation HeadRotation => headRotation;
        public bool IsInVehicle => isInVehicle;

        public IVehicle Vehicle
        {
            get
            {
                if (vehiclePointer == IntPtr.Zero) return null;
                return Alt.Module.VehiclePool.GetOrCreate(vehiclePointer, out var vehicle) ? vehicle : null;
            }
        }

        public byte Seat => seat;
        public uint Ping => ping;

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
            return Origin.Copy();
        }

        internal IPlayer Origin;

        public bool GetOrigin<T>(out T player) where T : IPlayer
        {
            if (!(Origin is T originT))
            {
                player = default;
                return true;
            }

            player = originT;
            return true;
        }

        public void Dispose()
        {
            Marshal.FreeCoTaskMem(name);
        }
    }
}