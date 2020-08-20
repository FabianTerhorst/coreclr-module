using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Refs;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        public static ushort GetId(IntPtr playerPointer) => AltNative.Player.Player_GetID(playerPointer);

        public override IPlayer NetworkOwner
        {
            get
            {
                CheckIfEntityExists();
                var entityPointer = AltNative.Player.Player_GetNetworkOwner(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.PlayerPool.GetOrCreate(entityPointer, out var player) ? player : null;
            }
        }

        public override uint Model
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetModel(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetModel(NativePointer, value);
            }
        }

        public override Position Position
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Player.Player_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetPosition(NativePointer, value);
            }
        }

        public override Rotation Rotation
        {
            get
            {
                CheckIfEntityExists();
                var rotation = Rotation.Zero;
                AltNative.Player.Player_GetRotation(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetRotation(NativePointer, value);
            }
        }

        public override int Dimension
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetDimension(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetDimension(NativePointer, value);
            }
        }

        public uint Ping
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetPing(NativePointer);
            }
        }

        public string Ip
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Player.Player_GetIP(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
        }

        public override void SetNetworkOwner(IPlayer player, bool disableMigration)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_SetNetworkOwner(NativePointer, player?.NativePointer ?? IntPtr.Zero, disableMigration);
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(AltNative.Player.Player_GetMetaData(NativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Player.Player_SetMetaData(NativePointer, stringPtr, value.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
        }

        public override bool HasMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var result = AltNative.Player.Player_HasMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result;
        }

        public override void DeleteMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Player.Player_DeleteMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }

        public override void SetSyncedMetaData(string key, in MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Player.Player_SetSyncedMetaData(NativePointer, stringPtr, value.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
        }

        public override void GetSyncedMetaData(string key, out MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(AltNative.Player.Player_GetSyncedMetaData(NativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }
        
        public override bool HasSyncedMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var result = AltNative.Player.Player_HasSyncedMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result;
        }

        public override void DeleteSyncedMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Player.Player_DeleteSyncedMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }
        
        public override void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Player.Player_SetStreamSyncedMetaData(NativePointer, stringPtr, value.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
        }

        public override void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(AltNative.Player.Player_GetStreamSyncedMetaData(NativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }
        
        public override bool HasStreamSyncedMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var result = AltNative.Player.Player_HasStreamSyncedMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result;
        }

        public override void DeleteStreamSyncedMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Player.Player_DeleteStreamSyncedMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }

        public bool IsConnected
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsConnected(NativePointer);
            }
        }

        public string Name
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Player.Player_GetName(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
            /*set
            {
                CheckIfEntityExists();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                AltNative.Player.Player_SetName(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }*/
        }

        public ulong SocialClubId
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetSocialID(NativePointer);
            }
        }

        public ulong HardwareIdHash
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetHwidHash(NativePointer);
            }
        }

        public ulong HardwareIdExHash
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetHwidExHash(NativePointer);
            }
        }

        public string AuthToken
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Player.Player_GetAuthToken(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
        }

        public ushort Health
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetHealth(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetHealth(NativePointer, value);
            }
        }

        public ushort MaxHealth
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetMaxHealth(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetMaxHealth(NativePointer, value);
            }
        }

        public bool IsDead
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsDead(NativePointer);
            }
        }

        public bool IsJumping
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsJumping(NativePointer);
            }
        }

        public bool IsInRagdoll
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsInRagdoll(NativePointer);
            }
        }

        public bool IsAiming
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsAiming(NativePointer);
            }
        }

        public bool IsShooting
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsShooting(NativePointer);
            }
        }

        public bool IsReloading
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsReloading(NativePointer);
            }
        }

        public ushort Armor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetArmor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetArmor(NativePointer, value);
            }
        }

        public ushort MaxArmor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetMaxArmor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetMaxArmor(NativePointer, value);
            }
        }

        public float MoveSpeed
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetMoveSpeed(NativePointer);
            }
        }

        public Position AimPosition
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Player.Player_GetAimPos(NativePointer, ref position);
                return position;
            }
        }

        public Rotation HeadRotation
        {
            get
            {
                CheckIfEntityExists();
                var rotation = Rotation.Zero;
                AltNative.Player.Player_GetHeadRotation(NativePointer, ref rotation);
                return rotation;
            }
        }

        public bool IsInVehicle
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsInVehicle(NativePointer);
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                CheckIfEntityExists();
                var entityPointer = AltNative.Player.Player_GetVehicle(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.VehiclePool.GetOrCreate(entityPointer, out var vehicle) ? vehicle : null;
            }
        }

        public uint CurrentWeapon
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetCurrentWeapon(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetCurrentWeapon(NativePointer, value);
            }
        }

        public IEntity EntityAimingAt
        {
            get
            {
                CheckIfEntityExists();
                var type = BaseObjectType.Undefined;
                var entityPointer = AltNative.Player.Player_GetEntityAimingAt(NativePointer, ref type);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.BaseEntityPool.GetOrCreate(entityPointer, type, out var entity) ? entity : null;
            }
        }

        public Position EntityAimOffset
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Player.Player_GetEntityAimOffset(NativePointer, ref position);
                return position;
            }
        }

        public bool IsFlashlightActive
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsFlashlightActive(NativePointer);
            }
        }

        public byte Seat
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetSeat(NativePointer);
            }
        }

        public Player(IntPtr nativePointer, ushort id) : base(nativePointer, BaseObjectType.Player, id)
        {
        }

        public void Spawn(Position position, uint delayMs)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_Spawn(NativePointer, position, delayMs);
        }

        public void Despawn()
        {
            CheckIfEntityExists();
            AltNative.Player.Player_Despawn(NativePointer);
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_SetDateTime(NativePointer, day, month, year, hour, minute, second);
        }

        public void SetWeather(uint weather)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_SetWeather(NativePointer, weather);
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_GiveWeapon(NativePointer, weapon, ammo, selectWeapon);
        }

        public void RemoveWeapon(uint weapon)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_RemoveWeapon(NativePointer, weapon);
        }

        public void RemoveAllWeapons()
        {
            CheckIfEntityExists();
            AltNative.Player.Player_RemoveAllWeapons(NativePointer);
        }

        public void AddWeaponComponent(uint weapon, uint weaponComponent)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_AddWeaponComponent(NativePointer, weapon, weaponComponent);
        }

        public void RemoveWeaponComponent(uint weapon, uint weaponComponent)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_RemoveWeaponComponent(NativePointer, weapon, weaponComponent);
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            CheckIfEntityExists();
            var array = UIntArray.Nil;
            AltNative.Player.Player_GetCurrentWeaponComponents(NativePointer, ref array);
            weaponComponents = array.ToArrayAndFree();
        }

        public void SetWeaponTintIndex(uint weapon, byte tintIndex)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_SetWeaponTintIndex(NativePointer, weapon, tintIndex);
        }

        public byte GetCurrentWeaponTintIndex()
        {
            CheckIfEntityExists();
            return AltNative.Player.Player_GetCurrentWeaponTintIndex(NativePointer);
        }

        public void Kick(string reason)
        {
            CheckIfEntityExists();
            var reasonPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
            AltNative.Player.Player_Kick(NativePointer, reasonPtr);
            Marshal.FreeHGlobal(reasonPtr);
        }

        public void Emit(string eventName, params object[] args)
        {
            CheckIfEntityExists();
            Alt.Server.TriggerClientEvent(this, eventName, args);
        }

        protected override void InternalAddRef()
        {
            AltNative.Player.Player_AddRef(NativePointer);
        }

        protected override void InternalRemoveRef()
        {
            AltNative.Player.Player_RemoveRef(NativePointer);
        }

        public bool TryCreateRef(out PlayerRef playerRef)
        {
            playerRef = new PlayerRef(this);
            return playerRef.Exists;
        }
    }
}