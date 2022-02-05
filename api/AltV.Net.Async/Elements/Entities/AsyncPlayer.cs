using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Refs;
using AltV.Net.Native;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncPlayer<TPlayer> : AsyncEntity<TPlayer>, IPlayer where TPlayer : class, IPlayer
    {
        public new uint Model
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Model;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.Model = value;
                }
            }
        }

        public bool IsConnected
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsConnected;
                }
            }
        }

        public string Name
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Name;
                }
            }
        }

        public ulong SocialClubId
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.SocialClubId;
                }
            }
        }

        public ulong HardwareIdHash
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HardwareIdHash;
                }
            }
        }

        public ulong HardwareIdExHash
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HardwareIdExHash;
                }
            }
        }

        public string AuthToken
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.AuthToken;
                }
            }
        }

        public ushort Health
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Health;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.Health = value;
                }
            }
        }

        public ushort MaxHealth
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.MaxHealth;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.MaxHealth = value;
                }
            }
        }

        public bool IsDead
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsDead;
                }
            }
        }

        public bool IsJumping
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsJumping;
                }
            }
        }

        public bool IsInRagdoll
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsInRagdoll;
                }
            }
        }

        public bool IsAiming
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsAiming;
                }
            }
        }

        public bool IsShooting
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsShooting;
                }
            }
        }

        public bool IsReloading
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsReloading;
                }
            }
        }

        public ushort Armor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Armor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.Armor = value;
                }
            }
        }

        public ushort MaxArmor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.MaxArmor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.MaxArmor = value;
                }
            }
        }

        public float MoveSpeed
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.MoveSpeed;
                }
            }
        }

        public Position AimPosition
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.AimPosition;
                }
            }
        }

        public Rotation HeadRotation
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HeadRotation;
                }
            }
        }

        public bool IsInVehicle
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsInVehicle;
                }
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return null;
                    return BaseObject.Vehicle;
                }
            }
        }

        public uint CurrentWeapon
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.CurrentWeapon;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.CurrentWeapon = value;
                }
            }
        }

        public IEntity EntityAimingAt
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return null;
                    return BaseObject.EntityAimingAt;
                }
            }
        }

        public Position EntityAimOffset
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.EntityAimOffset;
                }
            }
        }

        public bool IsFlashlightActive
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsFlashlightActive;
                }
            }
        }

        public byte Seat
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Seat;
                }
            }
        }

        public uint Ping
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Ping;
                }
            }
        }

        public string Ip
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Ip;
                }
            }
        }

        public AsyncPlayer(TPlayer player, IAsyncContext asyncContext) : base(player, asyncContext)
        {
        }

        public void Spawn(Position position, uint delayMs = 0)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.Spawn(position, delayMs);
            }
        }

        public void Despawn()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.Despawn();
            }
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetDateTime(day, month, year, hour, minute, second);
            }
        }

        public void SetWeather(uint weather)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetWeather(weather);
            }
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GiveWeapon(weapon, ammo, selectWeapon);
            }
        }

        public bool RemoveWeapon(uint weapon)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.RemoveWeapon(weapon);
            }
        }

        public void RemoveAllWeapons()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.RemoveAllWeapons();
            }
        }

        public void Kick(string reason)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.Kick(reason);
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            var size = args.Length;
            using var asyncContext = RefContext.Create(false);
            var mValues = new MValueConst[size];
            MValueConstLocked.CreateFromObjectsLocked(args, mValues, asyncContext);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            lock (BaseObject)
            {
                if (BaseObject.Exists)
                {
                    Alt.Server.TriggerClientEvent(BaseObject, eventNamePtr, mValues);
                }
            }

            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void AddWeaponComponent(uint weapon, uint weaponComponent)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.AddWeaponComponent(weapon, weaponComponent);
            }
        }

        public void RemoveWeaponComponent(uint weapon, uint weaponComponent)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.RemoveWeaponComponent(weapon, weaponComponent);
            }
        }

        public bool HasWeaponComponent(uint weapon, uint weaponComponent)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.HasWeaponComponent(weapon, weaponComponent);
            }
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    weaponComponents = Array.Empty<uint>();
                    return;
                }

                BaseObject.GetCurrentWeaponComponents(out weaponComponents);
            }
        }

        public void SetWeaponTintIndex(uint weapon, byte tintIndex)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetWeaponTintIndex(weapon, tintIndex);
            }
        }

        public byte GetWeaponTintIndex(uint weapon)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetWeaponTintIndex(weapon);
            }
        }

        public byte GetCurrentWeaponTintIndex()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetCurrentWeaponTintIndex();
            }
        }

        public WeaponData[] GetWeapons()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetWeapons();
            }
        }

        public void ClearBloodDamage()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.ClearBloodDamage();
            }
        }

        public Cloth GetClothes(byte component)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetClothes(component);
            }
        }

        public void GetClothes(byte component, ref Cloth cloth)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetClothes(component, ref cloth);
            }
        }

        public void SetClothes(byte component, ushort drawable, byte texture, byte palette)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetClothes(component, drawable, texture, palette);
            }
        }

        public DlcCloth GetDlcClothes(byte component)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetDlcClothes(component);
            }
        }

        public void GetDlcClothes(byte component, ref DlcCloth cloth)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetDlcClothes(component, ref cloth);
            }
        }

        public void SetDlcClothes(byte component, ushort drawable, byte texture, byte palette, uint dlc)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetDlcClothes(component, drawable, texture, palette, dlc);
            }
        }

        public Prop GetProps(byte component)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetProps(component);
            }
        }

        public void GetProps(byte component, ref Prop prop)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetProps(component, ref prop);
            }
        }

        public void SetProps(byte component, ushort drawable, byte texture)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetProps(component, drawable, texture);
            }
        }

        public DlcProp GetDlcProps(byte component)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetDlcProps(component);
            }
        }

        public void GetDlcProps(byte component, ref DlcProp prop)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetDlcProps(component, ref prop);
            }
        }

        public void SetDlcProps(byte component, ushort drawable, byte texture, uint dlc)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetDlcProps(component, drawable, texture, dlc);
            }
        }

        public void ClearProps(byte component)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.ClearProps(component);
            }
        }

        public bool IsEntityInStreamingRange(IEntity entity)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.IsEntityInStreamingRange(entity);
            }
        }

        public bool TryCreateRef(out PlayerRef playerRef)
        {
            return BaseObject.TryCreateRef(out playerRef);
        }

        public bool Invincible
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Invincible;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.Invincible = value;
                }
            }
        }

        public void SetIntoVehicle(IVehicle vehicle, byte seat)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetIntoVehicle(vehicle, seat);
            }
        }

        public bool IsSuperJumpEnabled
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsSuperJumpEnabled;
                }
            }
        }

        public bool IsCrouching
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsCrouching;
                }
            }
        }

        public bool IsStealthy
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsStealthy;
                }
            }
        }

        public void PlayAmbientSpeech(string speechName, string speechParam, uint speechHash)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.PlayAmbientSpeech(speechName, speechParam, speechHash);
            }
        }

        public HeadBlendData HeadBlendData
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HeadBlendData;
                }
            }
        }

        public ushort EyeColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.EyeColor;
                }
            }
        }

        public byte HairColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HairColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.HairColor = value;
                }
            }
        }

        public byte HairHighlightColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HairHighlightColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return;
                    BaseObject.HairHighlightColor = value;
                }
            }
        }

        public bool SetHeadOverlay(byte overlayId, byte index, float opacity)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetHeadOverlay(overlayId, index, opacity);
            }
        }

        public bool RemoveHeadOverlay(byte overlayId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.RemoveHeadOverlay(overlayId);
            }
        }


        public bool SetHeadOverlayColor(byte overlayId, byte colorType, byte colorIndex, byte secondColorIndex)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetHeadOverlayColor(overlayId, colorType, colorIndex, secondColorIndex);
            }
        }

        public HeadOverlay GetHeadOverlay(byte overlayID)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetHeadOverlay(overlayID);
            }
        }

        public bool SetFaceFeature(byte index, float scale)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetFaceFeature(index, scale);
            }
        }

        public float GetFaceFeatureScale(byte index)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetFaceFeatureScale(index);
            }
        }

        public bool RemoveFaceFeature(byte index)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.RemoveFaceFeature(index);
            }
        }

        public bool SetHeadBlendPaletteColor(byte id, Rgba rgba)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetHeadBlendPaletteColor(id, rgba);
            }
        }

        public Rgba GetHeadBlendPaletteColor(byte id)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetHeadBlendPaletteColor(id);
            }
        }

        public void SetHeadBlendData(uint shapeFirstID, uint shapeSecondID, uint shapeThirdID, uint skinFirstID,
            uint skinSecondID, uint skinThirdID, float shapeMix, float skinMix, float thirdMix)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.SetHeadBlendData(shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID,
                    skinThirdID, shapeMix, skinMix, thirdMix);
            }
        }

        public bool SetEyeColor(ushort eyeColor)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetEyeColor(eyeColor);
            }
        }

        public void GetLocalMetaData(string key, out MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = default;
                    return;
                }
                BaseObject.GetLocalMetaData(key, out value);
            }
        }

        public void SetLocalMetaData(string key, in MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    return;
                }
                BaseObject.SetLocalMetaData(key, in value);
            }
        }

        public bool HasLocalMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.HasLocalMetaData(key);
            }
        }

        public void DeleteLocalMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.DeleteLocalMetaData(key);
            }
        }
    }
}