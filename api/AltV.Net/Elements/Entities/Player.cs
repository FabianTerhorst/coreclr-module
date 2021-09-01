using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Refs;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        public static ushort GetId(IntPtr playerPointer)
        {
            unsafe
            {
                return Alt.Server.Library.Player_GetID(playerPointer);
            }
        }

        public override IPlayer NetworkOwner
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    var entityPointer = Server.Library.Player_GetNetworkOwner(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.PlayerPool.Get(entityPointer, out var player) ? player : null;
                }
            }
        }

        public override uint Model
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Player_GetModel(NativePointer);
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Player_SetModel(NativePointer, value);
                }
            }
        }

        public override Position Position
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    var position = Position.Zero;
                    Server.Library.Player_GetPosition(NativePointer, &position);
                    return position;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Player_SetPosition(NativePointer, value);
                }
            }
        }

        public override Rotation Rotation
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    var rotation = Rotation.Zero;
                    Server.Library.Player_GetRotation(NativePointer, &rotation);
                    return rotation;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Player_SetRotation(NativePointer, value);
                }
            }
        }

        public override bool Visible
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Player_GetVisible(NativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Player_SetVisible(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public override bool Streamed
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Player_GetStreamed(NativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Player_SetStreamed(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public override int Dimension
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Player_GetDimension(NativePointer);
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Player_SetDimension(NativePointer, value);
                }
            }
        }

        public uint Ping
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Player_GetPing(NativePointer);
                }
            }
        }

        public string Ip
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    Server.Library.Player_GetIP(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
        }

        public override void SetNetworkOwner(IPlayer player, bool disableMigration)
        {
            CheckIfEntityExists();
            unsafe
            {
                Server.Library.Player_SetNetworkOwner(NativePointer, player?.NativePointer ?? IntPtr.Zero, disableMigration ? (byte) 1 : (byte) 0);
            }
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Player_GetMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Player_SetMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Player_HasMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Player_DeleteMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Player_SetSyncedMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void GetSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Player_GetSyncedMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public override bool HasSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Player_HasSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Player_DeleteSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public override void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Player_SetStreamSyncedMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Player_GetStreamSyncedMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public override bool HasStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Player_HasStreamSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Player_DeleteStreamSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool IsConnected
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsConnected(NativePointer) == 1;
                }
            }
        }

        public string Name
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var ptr = IntPtr.Zero;
                    Server.Library.Player_GetName(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
            /*set
            {
                CheckIfEntityExists();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                Server.Library.Player_SetName(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }*/
        }

        public ulong SocialClubId
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetSocialID(NativePointer);
                }
            }
        }

        public ulong HardwareIdHash
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetHwidHash(NativePointer);
                }
            }
        }

        public ulong HardwareIdExHash
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetHwidExHash(NativePointer);
                }
            }
        }

        public string AuthToken
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var ptr = IntPtr.Zero;
                    Server.Library.Player_GetAuthToken(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
        }

        public ushort Health
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetHealth(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Player_SetHealth(NativePointer, value);
                }
            }
        }

        public ushort MaxHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetMaxHealth(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Player_SetMaxHealth(NativePointer, value);
                }
            }
        }

        public bool IsDead
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsDead(NativePointer) == 1;
                }
            }
        }

        public bool IsJumping
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsJumping(NativePointer) == 1;
                }
            }
        }

        public bool IsInRagdoll
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsInRagdoll(NativePointer) == 1;
                }
            }
        }

        public bool IsAiming
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsAiming(NativePointer) == 1;
                }
            }
        }

        public bool IsShooting
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsShooting(NativePointer) == 1;
                }
            }
        }

        public bool IsReloading
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsReloading(NativePointer) == 1;
                }
            }
        }

        public ushort Armor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetArmor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Player_SetArmor(NativePointer, value);
                }
            }
        }

        public ushort MaxArmor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetMaxArmor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Player_SetMaxArmor(NativePointer, value);
                }
            }
        }

        public float MoveSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetMoveSpeed(NativePointer);
                }
            }
        }

        public Position AimPosition
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.Player_GetAimPos(NativePointer, &position);
                    return position;
                }
            }
        }

        public Rotation HeadRotation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rotation = Rotation.Zero;
                    Server.Library.Player_GetHeadRotation(NativePointer, &rotation);
                    return rotation;
                }
            }
        }

        public bool IsInVehicle
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsInVehicle(NativePointer) == 1;
                }
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Player_GetVehicle(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.VehiclePool.Get(entityPointer, out var vehicle) ? vehicle : null;
                }
            }
        }

        public uint CurrentWeapon
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetCurrentWeapon(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Player_SetCurrentWeapon(NativePointer, value);
                }
            }
        }

        public IEntity EntityAimingAt
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var type = BaseObjectType.Undefined;
                    var entityPointer = Server.Library.Player_GetEntityAimingAt(NativePointer, &type);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.BaseEntityPool.Get(entityPointer, type, out var entity) ? entity : null;
                }
            }
        }

        public Position EntityAimOffset
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.Player_GetEntityAimOffset(NativePointer, &position);
                    return position;
                }
            }
        }

        public bool IsFlashlightActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_IsFlashlightActive(NativePointer) == 1;
                }
            }
        }

        public byte Seat
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Player_GetSeat(NativePointer);
                }
            }
        }

        public Player(IServer server, IntPtr nativePointer, ushort id) : base(server, nativePointer, BaseObjectType.Player, id)
        {
        }

        public void Spawn(Position position, uint delayMs)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_Spawn(NativePointer, position, delayMs);
            }
        }

        public void Despawn()
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_Despawn(NativePointer);
            }
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_SetDateTime(NativePointer, day, month, year, hour, minute, second);
            }
        }

        public void SetWeather(uint weather)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_SetWeather(NativePointer, weather);
            }
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_GiveWeapon(NativePointer, weapon, ammo, selectWeapon ? (byte) 1 : (byte) 0);
            }
        }

        public bool RemoveWeapon(uint weapon)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Player_RemoveWeapon(NativePointer, weapon) == 1;
            }
        }

        public void RemoveAllWeapons()
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_RemoveAllWeapons(NativePointer);
            }
        }

        public void AddWeaponComponent(uint weapon, uint weaponComponent)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_AddWeaponComponent(NativePointer, weapon, weaponComponent);
            }
        }

        public void RemoveWeaponComponent(uint weapon, uint weaponComponent)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_RemoveWeaponComponent(NativePointer, weapon, weaponComponent);
            }
        }

        public bool HasWeaponComponent(uint weapon, uint weaponComponent)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Player_HasWeaponComponent(NativePointer, weapon, weaponComponent) == 1;
            }
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            unsafe
            {
                CheckIfEntityExists();
                var array = UIntArray.Nil;
                Server.Library.Player_GetCurrentWeaponComponents(NativePointer, &array);
                weaponComponents = array.ToArray();
                Server.Library.FreeUIntArray(&array);
            }
        }

        public void SetWeaponTintIndex(uint weapon, byte tintIndex)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_SetWeaponTintIndex(NativePointer, weapon, tintIndex);
            }
        }

        public byte GetWeaponTintIndex(uint weapon)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Player_GetWeaponTintIndex(NativePointer, weapon);
            }
        }

        public byte GetCurrentWeaponTintIndex()
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Player_GetCurrentWeaponTintIndex(NativePointer);
            }
        }

        public void Kick(string reason)
        {
            unsafe
            {
                CheckIfEntityExists();
                var reasonPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
                Server.Library.Player_Kick(NativePointer, reasonPtr);
                Marshal.FreeHGlobal(reasonPtr);
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            CheckIfEntityExists();
            Alt.Server.TriggerClientEvent(this, eventName, args);
        }

        protected override void InternalAddRef()
        {
            unsafe
            {
                Server.Library.Player_AddRef(NativePointer);
            }
        }

        protected override void InternalRemoveRef()
        {
            unsafe
            {
                Server.Library.Player_RemoveRef(NativePointer);
            }
        }

        public void ClearBloodDamage()
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_ClearBloodDamage(NativePointer);
            }
        }

        public Cloth GetClothes(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var cloth = Cloth.Zero;
                Server.Library.Player_GetClothes(NativePointer, component, &cloth);
                return cloth;
            }
        }
        public void GetClothes(byte component, ref Cloth cloth)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currCloth = Cloth.Zero;
                Server.Library.Player_GetClothes(NativePointer, component, &currCloth);
                cloth = currCloth;
            }
        }

        public void SetClothes(byte component, ushort drawable, byte texture, byte palette)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_SetClothes(NativePointer, component, drawable, texture, palette);
            }
        }

        public DlcCloth GetDlcClothes(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var cloth = DlcCloth.Zero;
                Server.Library.Player_GetDlcClothes(NativePointer, component, &cloth);
                return cloth;
            }
        }
        public void GetDlcClothes(byte component, ref DlcCloth cloth)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currCloth = DlcCloth.Zero;
                Server.Library.Player_GetDlcClothes(NativePointer, component, &currCloth);
                cloth = currCloth;
            }
        }

        public void SetDlcClothes(byte component, ushort drawable, byte texture, byte palette, uint dlc)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_SetDlcClothes(NativePointer, component, drawable, texture, palette, dlc);
            }
        }

        public Prop GetProps(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var prop = Prop.Zero;
                Server.Library.Player_GetProps(NativePointer, component, &prop);
                return prop;
            }
        }
        public void GetProps(byte component, ref Prop prop)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currProp = Prop.Zero;
                Server.Library.Player_GetProps(NativePointer, component, &currProp);
                prop = currProp;
            }
        }

        public void SetProps(byte component, ushort drawable, byte texture)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_SetProps(NativePointer, component, drawable, texture);
            }
        }

        public DlcProp GetDlcProps(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var prop = DlcProp.Zero;
                Server.Library.Player_GetDlcProps(NativePointer, component, &prop);
                return prop;
            }
        }
        
        public void GetDlcProps(byte component, ref DlcProp prop)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currProp = DlcProp.Zero;
                Server.Library.Player_GetDlcProps(NativePointer, component, &currProp);
                prop = currProp;
            }
        }

        public void SetDlcProps(byte component, ushort drawable, byte texture, uint dlc)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_SetDlcProps(NativePointer, component, drawable, texture, dlc);
            }
        }

        public void ClearProps(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_ClearProps(NativePointer, component);
            }
        }

        public bool IsEntityInStreamingRange(IEntity entity)
        {
            unsafe
            {
                CheckIfEntityExists();
                if(entity == null) return false;

                if(entity.Type == BaseObjectType.Player) 
                    return Server.Library.Player_IsEntityInStreamingRange_Player(NativePointer, entity.NativePointer) == 1;
                if(entity.Type == BaseObjectType.Vehicle)
                    return Server.Library.Player_IsEntityInStreamingRange_Vehicle(NativePointer, entity.NativePointer) == 1;

                return false;
            }
        }

        public override void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation, bool collision, bool noFixedRotation)
        {
            unsafe
            {
                CheckIfEntityExists();
                if(entity == null) return;
            
                if(entity.Type == BaseObjectType.Player) 
                    Server.Library.Player_AttachToEntity_Player(NativePointer, entity.NativePointer, otherBone, ownBone, position, rotation, collision ? (byte) 1 : (byte) 0, noFixedRotation ? (byte) 1 : (byte) 0);
                if(entity.Type == BaseObjectType.Vehicle)
                    Server.Library.Player_AttachToEntity_Vehicle(NativePointer, entity.NativePointer, otherBone, ownBone, position, rotation, collision ? (byte) 1 : (byte) 0, noFixedRotation ? (byte) 1 : (byte) 0);
            }
        }

        public override void Detach()
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Player_Detach(NativePointer);
            }
        }

        public bool TryCreateRef(out PlayerRef playerRef)
        {
            playerRef = new PlayerRef(this);
            return playerRef.Exists;
        }
    }
}
