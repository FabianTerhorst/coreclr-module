﻿using System;
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
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Model;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Model = value); }
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
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Health;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Health = value); }
        }

        public ushort MaxHealth
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.MaxHealth;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.MaxHealth = value); }
        }

        public bool IsDead
        {
            get
            {
                AsyncContext.RunAll();
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
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Armor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Armor = value); }
        }

        public ushort MaxArmor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.MaxArmor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.MaxArmor = value); }
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
                AsyncContext.RunAll();
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
                AsyncContext.RunAll();
                IVehicle entity = default;
                AsyncContext.RunOnMainThreadBlocking(() => entity = BaseObject.Vehicle);
                return entity;
            }
        }

        public uint CurrentWeapon
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.CurrentWeapon;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.CurrentWeapon = value); }
        }

        public IEntity EntityAimingAt
        {
            get
            {
                IEntity entity = default;
                AsyncContext.RunOnMainThreadBlocking(() => entity = BaseObject.EntityAimingAt);
                return entity;
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
                AsyncContext.RunAll();
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
            AsyncContext.Enqueue(() => BaseObject.Spawn(position, delayMs));
        }

        public void Despawn()
        {
            AsyncContext.Enqueue(() => BaseObject.Despawn());
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            AsyncContext.Enqueue(() => BaseObject.SetDateTime(day, month, year, hour, minute, second));
        }
        
        public void SetWeather(WeatherType weather)
                 => SetWeather((uint)weather);
        
        public void SetWeather(uint weather)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWeather(weather));
        }
        
        public void GiveWeapon(WeaponModel weapon, int ammo, bool selectWeapon)
                 => GiveWeapon((uint)weapon, int ammo, bool selectWeapon);
        
        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            AsyncContext.Enqueue(() => BaseObject.GiveWeapon(weapon, ammo, selectWeapon));
        }

        public bool RemoveWeapon(WeaponModel weapon)
                 => RemoveWeapon((uint)weapon); 
                 
        public bool RemoveWeapon(uint weapon)
        {
            bool result = default;
            AsyncContext.RunOnMainThreadBlocking(() => result = BaseObject.RemoveWeapon(weapon));
            return result;
        }

        public void RemoveAllWeapons()
        {
            AsyncContext.Enqueue(() => BaseObject.RemoveAllWeapons());
        }

        public void Kick(string reason)
        {
            AsyncContext.Enqueue(() => BaseObject.Kick(reason));
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
            AsyncContext.Enqueue(() => BaseObject.AddWeaponComponent(weapon, weaponComponent));
        }

        public void RemoveWeaponComponent(uint weapon, uint weaponComponent)
        {
            AsyncContext.Enqueue(() => BaseObject.RemoveWeaponComponent(weapon, weaponComponent));
        }

        public bool HasWeaponComponent(uint weapon, uint weaponComponent)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.HasWeaponComponent(weapon, weaponComponent);
            }
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            AsyncContext.RunAll();
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
            AsyncContext.Enqueue(() => BaseObject.SetWeaponTintIndex(weapon, tintIndex));
        }

        public byte GetWeaponTintIndex(uint weapon)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetWeaponTintIndex(weapon);
            }
        }

        public byte GetCurrentWeaponTintIndex()
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetCurrentWeaponTintIndex();
            }
        }

        public WeaponData[] GetWeapons()
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetWeapons();
            }
        }

        public void ClearBloodDamage()
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.ClearBloodDamage();
            }
        }

        public Cloth GetClothes(byte component)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetClothes(component);
            }
        }

        public void GetClothes(byte component, ref Cloth cloth)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetClothes(component, ref cloth);
            }
        }

        public void SetClothes(byte component, ushort drawable, byte texture, byte palette)
        {
            AsyncContext.Enqueue(() => BaseObject.SetClothes(component, drawable, texture, palette));
        }

        public DlcCloth GetDlcClothes(byte component)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetDlcClothes(component);
            }
        }

        public void GetDlcClothes(byte component, ref DlcCloth cloth)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetDlcClothes(component, ref cloth);
            }
        }

        public void SetDlcClothes(byte component, ushort drawable, byte texture, byte palette, uint dlc)
        {
            AsyncContext.Enqueue(() => BaseObject.SetDlcClothes(component, drawable, texture, palette, dlc));
        }

        public Prop GetProps(byte component)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetProps(component);
            }
        }

        public void GetProps(byte component, ref Prop prop)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetProps(component, ref prop);
            }
        }

        public void SetProps(byte component, ushort drawable, byte texture)
        {
            AsyncContext.Enqueue(() => BaseObject.SetProps(component, drawable, texture));
        }

        public DlcProp GetDlcProps(byte component)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetDlcProps(component);
            }
        }

        public void GetDlcProps(byte component, ref DlcProp prop)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return;
                BaseObject.GetDlcProps(component, ref prop);
            }
        }

        public void SetDlcProps(byte component, ushort drawable, byte texture, uint dlc)
        {
            AsyncContext.Enqueue(() => BaseObject.SetDlcProps(component, drawable, texture, dlc));
        }

        public void ClearProps(byte component)
        {
            AsyncContext.Enqueue(() => BaseObject.ClearProps(component));
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
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Invincible;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Invincible = value); }
        }

        public void SetIntoVehicle(IVehicle vehicle, byte seat)
        {
            AsyncContext.Enqueue(() => BaseObject.SetIntoVehicle(vehicle, seat));
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
            AsyncContext.Enqueue(() => BaseObject.PlayAmbientSpeech(speechName, speechParam, speechHash));
        }

        public HeadBlendData HeadBlendData
        {
            get
            {
                lock(BaseObject)
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
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HairColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.HairColor = value); }
        }

        public byte HairHighlightColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HairHighlightColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.HairHighlightColor = value); }
        }

        public bool SetHeadOverlay(byte overlayId, byte index, float opacity)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetHeadOverlay(overlayId, index, opacity);
            }
        }

        public bool RemoveHeadOverlay(byte overlayId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.RemoveHeadOverlay(overlayId);
            }
        }


        public bool SetHeadOverlayColor(byte overlayId, byte colorType, byte colorIndex, byte secondColorIndex)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetHeadOverlayColor(overlayId, colorType, colorIndex, secondColorIndex);
            }
        }

        public HeadOverlay GetHeadOverlay(byte overlayID)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetHeadOverlay(overlayID);
            }
        }

        public bool SetFaceFeature(byte index, float scale)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetFaceFeature(index, scale);
            }
        }

        public float GetFaceFeatureScale(byte index)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetFaceFeatureScale(index);
            }
        }

        public bool RemoveFaceFeature(byte index)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.RemoveFaceFeature(index);
            }
        }

        public bool SetHeadBlendPaletteColor(byte id, Rgba rgba)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetHeadBlendPaletteColor(id, rgba);
            }
        }

        public Rgba GetHeadBlendPaletteColor(byte id)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetHeadBlendPaletteColor(id);
            }
        }

        public void SetHeadBlendData(uint shapeFirstID, uint shapeSecondID, uint shapeThirdID, uint skinFirstID, uint skinSecondID, uint skinThirdID, float shapeMix, float skinMix, float thirdMix)
        {
            AsyncContext.Enqueue(() => BaseObject.SetHeadBlendData(shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID, skinThirdID, shapeMix, skinMix, thirdMix));
        }

        public bool SetEyeColor(ushort eyeColor)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetEyeColor(eyeColor);
            }
        }
    }
}
