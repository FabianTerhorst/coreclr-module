using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Native;

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

        //TODO: implement in struct
        public ushort MaxHealth
        {
            get => 0;
            set { }
        }

        public ushort MaxArmor
        {
            get => 0;
            set { }
        }

        public uint CurrentWeapon
        {
            get => 0;
            set { }
        }
        public IntPtr entityAimingAt => IntPtr.Zero;
        public byte entityAimingAtEntityType => 0;
        public Position EntityAimOffset => new Position();
        public bool IsFlashlightActive => false;
        public string Ip => "0.0.0.0";

        public IEntity EntityAimingAt
        {
            get
            {
                Alt.Module.BaseEntityPool.GetOrCreate(entityAimingAt, (BaseObjectType) entityAimingAtEntityType,
                    out var entity);
                return entity;
            }
        }

        public ulong SocialClubId { get; }
        public ulong HardwareIdHash { get; }
        public ulong HardwareIdExHash { get; }
        public string AuthToken { get; }

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
            throw new NotImplementedException();
        }

        public bool GetData<T>(string key, out T result)
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

        public void SetSyncedMetaData(string key, ref MValue value)
        {
            throw new NotImplementedException();
        }

        public void GetSyncedMetaData(string key, ref MValue value)
        {
            throw new NotImplementedException();
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

        public uint Model
        {
            get => model;
            set => model = value;
        }

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
            get => Marshal.PtrToStringUTF8(name);
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
                //TODO: this can only be executed on main thread because of vehicle pool maybe copy dictionary
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

        public void Dispose()
        {
            AltNative.Player.Player_Copy_Dispose(ref this);
        }

        public void CheckIfEntityExists()
        {
        }

        public void OnRemove()
        {
            throw new NotImplementedException();
        }
    }
}