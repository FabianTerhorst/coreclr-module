using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        public bool IsConnected => Exists && AltVNative.Player.Player_IsConnected(NativePointer);

        public string Name
        {
            get
            {
                if (!Exists) return string.Empty;
                var ptr = IntPtr.Zero;
                AltVNative.Player.Player_GetName(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Player.Player_SetName(NativePointer, value);
                }
            }
        }

        public ushort Health
        {
            get => !Exists ? default : AltVNative.Player.Player_GetHealth(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Player.Player_SetHealth(NativePointer, value);
                }
            }
        }

        public bool IsDead => Exists && AltVNative.Player.Player_IsDead(NativePointer);

        public bool IsJumping => Exists && AltVNative.Player.Player_IsJumping(NativePointer);

        public bool IsInRagdoll => Exists && AltVNative.Player.Player_IsInRagdoll(NativePointer);

        public bool IsAiming => Exists && AltVNative.Player.Player_IsAiming(NativePointer);

        public bool IsShooting => Exists && AltVNative.Player.Player_IsShooting(NativePointer);

        public bool IsReloading => Exists && AltVNative.Player.Player_IsReloading(NativePointer);

        public ushort Armor
        {
            get => !Exists ? default : AltVNative.Player.Player_GetArmor(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Player.Player_SetArmor(NativePointer, value);
                }
            }
        }

        public float MoveSpeed => !Exists ? default : AltVNative.Player.Player_GetMoveSpeed(NativePointer);

        public uint Weapon => !Exists ? default : AltVNative.Player.Player_GetWeapon(NativePointer);

        public ushort Ammo => !Exists ? default : AltVNative.Player.Player_GetAmmo(NativePointer);

        public Position AimPosition => !Exists ? Position.Zero : AltVNative.Player.Player_GetAimPos(NativePointer);

        public Rotation HeadRotation =>
            !Exists ? Rotation.Zero : AltVNative.Player.Player_GetHeadRotation(NativePointer);

        public bool IsInVehicle => Exists && AltVNative.Player.Player_IsInVehicle(NativePointer);

        public IVehicle Vehicle
        {
            get
            {
                if (!Exists) return null;
                var entityPointer = AltVNative.Player.Player_GetVehicle(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.VehiclePool.GetOrCreate(entityPointer, out var vehicle) ? vehicle : null;
            }
        }

        public sbyte Seat => !Exists ? default : AltVNative.Player.Player_GetSeat(NativePointer);

        public Player(IntPtr nativePointer, ushort id) : base(nativePointer, EntityType.Player, id)
        {
        }

        public void Spawn(Position position)
        {
            if (Exists)
            {
                AltVNative.Player.Player_Spawn(NativePointer, position);
            }
        }

        public void Despawn()
        {
            if (Exists)
            {
                AltVNative.Player.Player_Despawn(NativePointer);
            }
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            if (Exists)
            {
                AltVNative.Player.Player_SetDateTime(NativePointer, day, month, year, hour, minute, second);
            }
        }

        public void SetWeather(uint weather)
        {
            if (Exists)
            {
                AltVNative.Player.Player_SetWeather(NativePointer, weather);
            }
        }

        public void Kick(string reason)
        {
            if (Exists)
            {
                AltVNative.Player.Player_Kick(NativePointer, reason);
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            if (Exists)
            {
                Alt.Server.TriggerClientEvent(this, eventName, args);
            }
        }

        public ReadOnlyPlayer Copy()
        {
            var readOnlyPlayer = ReadOnlyPlayer.Empty;
            AltVNative.Player.Player_Copy(NativePointer, ref readOnlyPlayer);
            return readOnlyPlayer;
        }
    }
}