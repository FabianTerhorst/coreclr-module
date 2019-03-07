using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        public static ushort GetId(IntPtr playerPointer) => AltVNative.Player.Player_GetID(playerPointer);

        public override uint Model
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetModel(NativePointer);
            }
        }

        public override Position Position
        {
            get
            {
                CheckExistence();
                var position = Position.Zero;
                AltVNative.Player.Player_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckExistence();
                AltVNative.Player.Player_SetPosition(NativePointer, value);
            }
        }

        public override Rotation Rotation
        {
            get
            {
                CheckExistence();
                var rotation = Rotation.Zero;
                AltVNative.Player.Player_GetRotation(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                CheckExistence();
                AltVNative.Player.Player_SetRotation(NativePointer, value);
            }
        }

        public override short Dimension
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetDimension(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Player.Player_SetDimension(NativePointer, value);
            }
        }

        public uint Ping
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetPing(NativePointer);
            }
        }

        public override void SetMetaData(string key, object value)
        {
            CheckExistence();
            var mValue = MValue.CreateFromObject(value);
            AltVNative.Player.Player_SetMetaData(NativePointer, key, ref mValue);
        }

        public override bool GetMetaData<T>(string key, out T result)
        {
            CheckExistence();
            var mValue = MValue.Nil;
            AltVNative.Player.Player_GetMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public override void SetSyncedMetaData(string key, object value)
        {
            CheckExistence();
            var mValue = MValue.CreateFromObject(value);
            AltVNative.Player.Player_SetSyncedMetaData(NativePointer, key, ref mValue);
        }

        public override bool GetSyncedMetaData<T>(string key, out T result)
        {
            CheckExistence();
            var mValue = MValue.Nil;
            AltVNative.Player.Player_GetSyncedMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public bool IsConnected
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsConnected(NativePointer);
            }
        }

        public string Name
        {
            get
            {
                CheckExistence();
                var ptr = IntPtr.Zero;
                AltVNative.Player.Player_GetName(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckExistence();
                AltVNative.Player.Player_SetName(NativePointer, value);
            }
        }

        public ushort Health
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetHealth(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Player.Player_SetHealth(NativePointer, value);
            }
        }

        public bool IsDead
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsDead(NativePointer);
            }
        }

        public bool IsJumping
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsJumping(NativePointer);
            }
        }

        public bool IsInRagdoll
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsInRagdoll(NativePointer);
            }
        }

        public bool IsAiming
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsAiming(NativePointer);
            }
        }

        public bool IsShooting
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsShooting(NativePointer);
            }
        }

        public bool IsReloading
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsReloading(NativePointer);
            }
        }

        public ushort Armor
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetArmor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Player.Player_SetArmor(NativePointer, value);
            }
        }

        public float MoveSpeed
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetMoveSpeed(NativePointer);
            }
        }

        public uint Weapon
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetWeapon(NativePointer);
            }
        }

        public ushort Ammo
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetAmmo(NativePointer);
            }
        }

        public Position AimPosition
        {
            get
            {
                CheckExistence();
                var position = Position.Zero;
                AltVNative.Player.Player_GetAimPos(NativePointer, ref position);
                return position;
            }
        }

        public Rotation HeadRotation
        {
            get
            {
                CheckExistence();
                var rotation = Rotation.Zero;
                AltVNative.Player.Player_GetHeadRotation(NativePointer, ref rotation);
                return rotation;
            }
        }

        public bool IsInVehicle
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_IsInVehicle(NativePointer);
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                CheckExistence();
                var entityPointer = AltVNative.Player.Player_GetVehicle(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.VehiclePool.GetOrCreate(entityPointer, out var vehicle) ? vehicle : null;
            }
        }

        public byte Seat
        {
            get
            {
                CheckExistence();
                return AltVNative.Player.Player_GetSeat(NativePointer);
            }
        }

        public Player(IntPtr nativePointer, ushort id) : base(nativePointer, BaseObjectType.Player, id)
        {
        }

        public void Spawn(Position position)
        {
            CheckExistence();
            AltVNative.Player.Player_Spawn(NativePointer, position);
        }

        public void Despawn()
        {
            CheckExistence();
            AltVNative.Player.Player_Despawn(NativePointer);
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            CheckExistence();
            AltVNative.Player.Player_SetDateTime(NativePointer, day, month, year, hour, minute, second);
        }

        public void SetWeather(uint weather)
        {
            CheckExistence();
            AltVNative.Player.Player_SetWeather(NativePointer, weather);
        }

        public void Kick(string reason)
        {
            CheckExistence();
            AltVNative.Player.Player_Kick(NativePointer, reason);
        }

        public void Emit(string eventName, params object[] args)
        {
            CheckExistence();
            Alt.Server.TriggerClientEvent(this, eventName, args);
        }

        public ReadOnlyPlayer Copy()
        {
            CheckExistence();
            var readOnlyPlayer = ReadOnlyPlayer.Empty;
            AltVNative.Player.Player_Copy(NativePointer, ref readOnlyPlayer);
            return readOnlyPlayer;
        }
    }
}