using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Refs;
using AltV.Net.Native;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        public IntPtr PlayerNativePointer { get; }
        public override IntPtr NativePointer => PlayerNativePointer;
        
        private static IntPtr GetEntityPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Player_GetEntity(nativePointer);
            }
        }
        
        public static ushort GetId(IntPtr playerPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Player_GetID(playerPointer);
            }
        }

        public override uint Model
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Core.Library.Shared.Entity_GetModel(EntityNativePointer);
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.Player_SetModel(PlayerNativePointer, value);
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
                    return Core.Library.Server.Player_GetPing(PlayerNativePointer);
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
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Player_GetIP(PlayerNativePointer, &size), size);
                }
            }
        }

        public void GetLocalMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Core, Core.Library.Server.Player_GetLocalMetaData(PlayerNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetLocalMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.Player_SetLocalMetaData(PlayerNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasLocalMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Server.Player_HasLocalMetaData(PlayerNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteLocalMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.Player_DeleteLocalMetaData(PlayerNativePointer, stringPtr);
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
                    return Core.Library.Server.Player_IsConnected(PlayerNativePointer) == 1;
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
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Shared.Player_GetName(PlayerNativePointer, &size), size);
                }
            }
        }

        public ulong SocialClubId
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Player_GetSocialID(PlayerNativePointer);
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
                    return Core.Library.Server.Player_GetHwidHash(PlayerNativePointer);
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
                    return Core.Library.Server.Player_GetHwidExHash(PlayerNativePointer);
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
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Player_GetAuthToken(PlayerNativePointer, &size), size);
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
                    return Core.Library.Shared.Player_GetHealth(PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Player_SetHealth(PlayerNativePointer, value);
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
                    return Core.Library.Shared.Player_GetMaxHealth(PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Player_SetMaxHealth(PlayerNativePointer, value);
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
                    return Core.Library.Shared.Player_IsDead(PlayerNativePointer) == 1;
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
                    return Core.Library.Shared.Player_IsJumping(PlayerNativePointer) == 1;
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
                    return Core.Library.Shared.Player_IsInRagdoll(PlayerNativePointer) == 1;
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
                    return Core.Library.Shared.Player_IsAiming(PlayerNativePointer) == 1;
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
                    return Core.Library.Shared.Player_IsShooting(PlayerNativePointer) == 1;
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
                    return Core.Library.Shared.Player_IsReloading(PlayerNativePointer) == 1;
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
                    return Core.Library.Shared.Player_GetArmor(PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Player_SetArmor(PlayerNativePointer, value);
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
                    return Core.Library.Shared.Player_GetMaxArmor(PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Player_SetMaxArmor(PlayerNativePointer, value);
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
                    return Core.Library.Shared.Player_GetMoveSpeed(PlayerNativePointer);
                }
            }
        }

        public float ForwardSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return this.Core.Library.Shared.Player_GetForwardSpeed(PlayerNativePointer);
                }
            }
        }

        public float StrafeSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return this.Core.Library.Shared.Player_GetStrafeSpeed(PlayerNativePointer);
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
                    var position = Vector3.Zero;
                    Core.Library.Shared.Player_GetAimPos(PlayerNativePointer, &position);
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
                    Core.Library.Shared.Player_GetHeadRotation(PlayerNativePointer, &rotation);
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
                    return Core.Library.Shared.Player_IsInVehicle(PlayerNativePointer) == 1;
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
                    var entityPointer = Core.Library.Shared.Player_GetVehicle(PlayerNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.VehiclePool.Get(entityPointer);
                }
            }
        }
        ISharedVehicle ISharedPlayer.Vehicle => Vehicle;

        public uint CurrentWeapon
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_GetCurrentWeapon(PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Player_SetCurrentWeapon(PlayerNativePointer, value);
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
                    var entityPointer = Core.Library.Shared.Player_GetEntityAimingAt(PlayerNativePointer, &type);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.BaseEntityPool.Get(entityPointer, type, out var entity) ? entity : null;
                }
            }
        }
        ISharedEntity ISharedPlayer.EntityAimingAt => EntityAimingAt;

        public Position EntityAimOffset
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Vector3.Zero;
                    Core.Library.Shared.Player_GetEntityAimOffset(PlayerNativePointer, &position);
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
                    return Core.Library.Shared.Player_IsFlashlightActive(PlayerNativePointer) == 1;
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
                    return Core.Library.Shared.Player_GetSeat(PlayerNativePointer);
                }
            }
        }

        public bool IsSpawned
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_IsSpawned(PlayerNativePointer) == 1;
                }
            }
        }

        public uint CurrentAnimationDict
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_GetCurrentAnimationDict(PlayerNativePointer);
                }
            }
        }

        public uint CurrentAnimationName
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_GetCurrentAnimationName(PlayerNativePointer);
                }
            }
        }

        public Player(ICore core, IntPtr nativePointer, ushort id) : base(core, GetEntityPointer(core, nativePointer), BaseObjectType.Player, id)
        {
            PlayerNativePointer = nativePointer;
        }

        public void Spawn(Position position, uint delayMs)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_Spawn(PlayerNativePointer, position, delayMs);
            }
        }

        public void Despawn()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_Despawn(PlayerNativePointer);
            }
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_SetDateTime(PlayerNativePointer, day, month, year, hour, minute, second);
            }
        }

        public void SetWeather(uint weather)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_SetWeather(PlayerNativePointer, weather);
            }
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_GiveWeapon(PlayerNativePointer, weapon, ammo, selectWeapon ? (byte) 1 : (byte) 0);
            }
        }

        public bool RemoveWeapon(uint weapon)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_RemoveWeapon(PlayerNativePointer, weapon) == 1;
            }
        }

        public void RemoveAllWeapons()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_RemoveAllWeapons(PlayerNativePointer);
            }
        }

        public void AddWeaponComponent(uint weapon, uint weaponComponent)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_AddWeaponComponent(PlayerNativePointer, weapon, weaponComponent);
            }
        }

        public void RemoveWeaponComponent(uint weapon, uint weaponComponent)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_RemoveWeaponComponent(PlayerNativePointer, weapon, weaponComponent);
            }
        }

        public bool HasWeaponComponent(uint weapon, uint weaponComponent)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_HasWeaponComponent(PlayerNativePointer, weapon, weaponComponent) == 1;
            }
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            unsafe
            {
                CheckIfEntityExists();
                var array = UIntArray.Nil;
                Core.Library.Shared.Player_GetCurrentWeaponComponents(PlayerNativePointer, &array);
                weaponComponents = array.ToArray();
                Core.Library.Shared.FreeUIntArray(&array);
            }
        }

        public void SetWeaponTintIndex(uint weapon, byte tintIndex)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_SetWeaponTintIndex(PlayerNativePointer, weapon, tintIndex);
            }
        }

        public byte GetWeaponTintIndex(uint weapon)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_GetWeaponTintIndex(PlayerNativePointer, weapon);
            }
        }

        public byte GetCurrentWeaponTintIndex()
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_GetCurrentWeaponTintIndex(PlayerNativePointer);
            }
        }

        public WeaponData[] GetWeapons()
        {
            unsafe
            {
                CheckIfEntityExists();

                var array = WeaponArray.Nil;
                Core.Library.Server.Player_GetWeapons(PlayerNativePointer, &array);

                var weaponDatas = array.ToInternalArray();
                var weapons = WeaponArray.Convert(weaponDatas);

                foreach (var weapon in weaponDatas)
                {
                    if (weapon.ComponentsCount == 0)
                        continue;

                    Core.Library.Shared.FreeUIntArray(&weapon.Components);
                }

                return weapons;
            }
        }

        public void Kick(string reason)
        {
            unsafe
            {
                CheckIfEntityExists();
                var reasonPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
                Core.Library.Server.Player_Kick(PlayerNativePointer, reasonPtr);
                Marshal.FreeHGlobal(reasonPtr);
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            CheckIfEntityExists();
            Alt.Core.TriggerClientEvent(this, eventName, args);
        }
        
        public void ClearBloodDamage()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_ClearBloodDamage(PlayerNativePointer);
            }
        }

        public Cloth GetClothes(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var cloth = Cloth.Zero;
                Core.Library.Server.Player_GetClothes(PlayerNativePointer, component, &cloth);
                return cloth;
            }
        }
        public void GetClothes(byte component, ref Cloth cloth)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currCloth = Cloth.Zero;
                Core.Library.Server.Player_GetClothes(PlayerNativePointer, component, &currCloth);
                cloth = currCloth;
            }
        }

        public bool SetClothes(byte component, ushort drawable, byte texture, byte palette)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetClothes(PlayerNativePointer, component, drawable, texture, palette) == 1;
            }
        }

        public DlcCloth GetDlcClothes(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var cloth = DlcCloth.Zero;
                Core.Library.Server.Player_GetDlcClothes(PlayerNativePointer, component, &cloth);
                return cloth;
            }
        }
        public void GetDlcClothes(byte component, ref DlcCloth cloth)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currCloth = DlcCloth.Zero;
                Core.Library.Server.Player_GetDlcClothes(PlayerNativePointer, component, &currCloth);
                cloth = currCloth;
            }
        }

        public bool SetDlcClothes(byte component, ushort drawable, byte texture, byte palette, uint dlc)
        {
            if (drawable > 127)
                throw new ArgumentOutOfRangeException(nameof(drawable), "Drawable can't be higher than 127");

            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetDlcClothes(PlayerNativePointer, component, drawable, texture, palette, dlc) == 1;
            }
        }

        public Prop GetProps(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var prop = Prop.Zero;
                Core.Library.Server.Player_GetProps(PlayerNativePointer, component, &prop);
                return prop;
            }
        }
        public void GetProps(byte component, ref Prop prop)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currProp = Prop.Zero;
                Core.Library.Server.Player_GetProps(PlayerNativePointer, component, &currProp);
                prop = currProp;
            }
        }

        public bool SetProps(byte component, ushort drawable, byte texture)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetProps(PlayerNativePointer, component, drawable, texture) == 1;
            }
        }

        public DlcProp GetDlcProps(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                var prop = DlcProp.Zero;
                Core.Library.Server.Player_GetDlcProps(PlayerNativePointer, component, &prop);
                return prop;
            }
        }

        public void GetDlcProps(byte component, ref DlcProp prop)
        {
            unsafe
            {
                CheckIfEntityExists();
                var currProp = DlcProp.Zero;
                Core.Library.Server.Player_GetDlcProps(PlayerNativePointer, component, &currProp);
                prop = currProp;
            }
        }

        public bool SetDlcProps(byte component, ushort drawable, byte texture, uint dlc)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetDlcProps(PlayerNativePointer, component, drawable, texture, dlc) == 1;
            }
        }

        public void ClearProps(byte component)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_ClearProps(PlayerNativePointer, component);
            }
        }

        public bool IsEntityInStreamingRange(IEntity entity)
        {
            unsafe
            {
                CheckIfEntityExists();
                if(entity == null) return false;

                return Core.Library.Server.Player_IsEntityInStreamingRange(PlayerNativePointer, entity.EntityNativePointer) == 1;
            }
        }

        public override void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation, bool collision, bool noFixedRotation)
        {
            unsafe
            {
                CheckIfEntityExists();
                if(entity == null) return;

                Core.Library.Server.Player_AttachToEntity(PlayerNativePointer, entity.EntityNativePointer, otherBone, ownBone, position, rotation, collision ? (byte) 1 : (byte) 0, noFixedRotation ? (byte) 1 : (byte) 0);
            }
        }

        public override void Detach()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_Detach(PlayerNativePointer);
            }
        }

        public bool Invincible
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Core.Library.Server.Player_GetInvincible(PlayerNativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.Player_SetInvincible(PlayerNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public void SetIntoVehicle(IVehicle vehicle, byte seat)
        {
            unsafe
            {
                CheckIfEntityExists();
                vehicle.CheckIfEntityExists();
                Core.Library.Server.Player_SetIntoVehicle(PlayerNativePointer, vehicle.VehicleNativePointer, seat);
            }
        }

        public bool IsSuperJumpEnabled
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Core.Library.Server.Player_IsSuperJumpEnabled(PlayerNativePointer) == 1;
                }
            }
        }

        public bool IsCrouching
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Core.Library.Server.Player_IsCrouching(PlayerNativePointer) == 1;
                }
            }
        }

        public bool IsStealthy
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Core.Library.Server.Player_IsStealthy(PlayerNativePointer) == 1;
                }
            }
        }

        public void PlayAmbientSpeech(string speechName, string speechParam, uint speechDictHash)
        {
            unsafe
            {
                var speechNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(speechName);
                var speechParamPtr = AltNative.StringUtils.StringToHGlobalUtf8(speechParam);
                Core.Library.Server.Player_PlayAmbientSpeech(PlayerNativePointer, speechNamePtr, speechParamPtr, speechDictHash);
                Marshal.FreeHGlobal(speechNamePtr);
                Marshal.FreeHGlobal(speechParamPtr);
            }
        }

        public bool TryCreateRef(out PlayerRef playerRef)
        {
            playerRef = new PlayerRef(this);
            return playerRef.Exists;
        }

        public HeadBlendData HeadBlendData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var headBlendData = HeadBlendData.Zero;
                    Core.Library.Server.Player_GetHeadBlendData(PlayerNativePointer, &headBlendData);
                    return headBlendData;
                }
            }
        }

        public ushort EyeColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Player_GetEyeColor(PlayerNativePointer);
                }
            }
        }

        public byte HairColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Player_GetHairColor(PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Player_SetHairColor(PlayerNativePointer, value);
                }
            }
        }

        public byte HairHighlightColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Player_GetHairHighlightColor(PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Player_SetHairHighlightColor(PlayerNativePointer, value);
                }
            }
        }

        public bool SetHeadOverlay(byte overlayId, byte index, float opacity)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetHeadOverlay(PlayerNativePointer, overlayId, index, opacity) == 1;
            }
        }

        public bool RemoveHeadOverlay(byte overlayId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_RemoveHeadOverlay(PlayerNativePointer, overlayId) == 1;
            }
        }

        public bool SetHeadOverlayColor(byte overlayId, byte colorType, byte colorIndex, byte secondColorIndex)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetHeadOverlayColor(PlayerNativePointer, overlayId, colorType, colorIndex, secondColorIndex) == 1;
            }
        }

        public bool SetFaceFeature(byte index, float scale)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetFaceFeature(PlayerNativePointer, index, scale) == 1;
            }
        }

        public float GetFaceFeatureScale(byte index)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_GetFaceFeatureScale(PlayerNativePointer, index);
            }
        }

        public bool RemoveFaceFeature(byte index)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_RemoveFaceFeature(PlayerNativePointer, index) == 1;
            }
        }

        public bool SetHeadBlendPaletteColor(byte id, Rgba rgba)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetHeadBlendPaletteColor(PlayerNativePointer, id, rgba.R, rgba.G, rgba.B) == 1;
            }
        }

        public Rgba GetHeadBlendPaletteColor(byte id)
        {
            unsafe
            {
                CheckIfEntityExists();
                var headBlendPaletteColor = Rgba.Zero;
                Core.Library.Server.Player_GetHeadBlendPaletteColor(PlayerNativePointer, id, &headBlendPaletteColor);
                return headBlendPaletteColor;
            }
        }

        public void SetHeadBlendData(uint shapeFirstID, uint shapeSecondID, uint shapeThirdID, uint skinFirstID, uint skinSecondID, uint skinThirdID, float shapeMix, float skinMix, float thirdMix)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Player_SetHeadBlendData(PlayerNativePointer, shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID, skinThirdID, shapeMix, skinMix, thirdMix);
            }
        }

        public bool SetEyeColor(ushort eyeColor)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Player_SetEyeColor(PlayerNativePointer, eyeColor) == 1;
            }
        }

        public HeadOverlay GetHeadOverlay(byte overlayID)
        {
            unsafe
            {
                CheckIfEntityExists();
                var headOverlay = HeadOverlay.Zero;
                Core.Library.Server.Player_GetHeadOverlay(PlayerNativePointer, overlayID, & headOverlay);
                return headOverlay;
            }
        }
    }
}
