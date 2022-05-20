using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVehicle<TVehicle> : AsyncEntity<TVehicle>, IVehicle where TVehicle : class, IVehicle
    {
        public IntPtr VehicleNativePointer => BaseObject.VehicleNativePointer;
        
        public IPlayer Driver
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return null;
                    return BaseObject.Driver;
                }
            }
        }

        public bool IsDestroyed
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsDestroyed;
                }
            }
        }

        public byte ModKit
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ModKit;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.ModKit = value;
                }
            }
        }

        public byte ModKitsCount
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ModKitsCount;
                }
            }
        }

        public bool IsPrimaryColorRgb
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsPrimaryColorRgb;
                }
            }
        }

        public byte PrimaryColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.PrimaryColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.PrimaryColor = value;
                }
            }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.PrimaryColorRgb;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.PrimaryColorRgb = value;
                }
            }
        }

        public bool IsSecondaryColorRgb
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsSecondaryColorRgb;
                }
            }
        }

        public byte SecondaryColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.SecondaryColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.SecondaryColor = value;
                }
            }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.SecondaryColorRgb;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.SecondaryColorRgb = value;
                }
            }
        }

        public byte PearlColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.PearlColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.PearlColor = value;
                }
            }
        }

        public byte WheelColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.WheelColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.WheelColor = value;
                }
            }
        }

        public byte InteriorColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.InteriorColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.InteriorColor = value;
                }
            }
        }

        public byte DashboardColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.DashboardColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.DashboardColor = value;
                }
            }
        }

        public bool IsTireSmokeColorCustom
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsTireSmokeColorCustom;
                }
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TireSmokeColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TireSmokeColor = value;
                }
            }
        }

        public byte WheelType
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.WheelType;
                }
            }
        }

        public byte WheelVariation
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.WheelVariation;
                }
            }
        }

        public byte RearWheel
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.RearWheel;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.RearWheel = value;
                }
            }
        }

        public bool CustomTires
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.CustomTires;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.CustomTires = value;
                }
            }
        }

        public byte SpecialDarkness
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.SpecialDarkness;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.SpecialDarkness = value;
                }
            }
        }

        public uint NumberplateIndex
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.NumberplateIndex;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.NumberplateIndex = value;
                }
            }
        }

        public string NumberplateText
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.NumberplateText;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.NumberplateText = value;
                }
            }
        }

        public byte WindowTint
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.WindowTint;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.WindowTint = value;
                }
            }
        }

        public byte DirtLevel
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.DirtLevel;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.DirtLevel = value;
                }
            }
        }

        public Rgba NeonColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.NeonColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.NeonColor = value;
                }
            }
        }

        public byte Livery
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Livery;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Livery = value;
                }
            }
        }

        public byte RoofLivery
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.RoofLivery;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.RoofLivery = value;
                }
            }
        }

        public string AppearanceData
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.AppearanceData;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.AppearanceData = value;
                }
            }
        }

        public IVehicle Attached
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Attached;
                }
            }
        }

        public IVehicle AttachedTo
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.AttachedTo;
                }
            }
        }

        public AsyncVehicle(TVehicle vehicle, IAsyncContext asyncContext) : base(vehicle, asyncContext)
        {
        }

        public byte GetMod(byte category)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetMod(category);
            }
        }

        public byte GetModsCount(byte category)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetModsCount(category);
            }
        }

        public bool SetMod(byte category, byte id)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.SetMod(category, id);
            }
        }

        public void SetWheels(byte type, byte variation)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWheels(type, variation);
            }
        }

        public bool IsExtraOn(byte extraId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsExtraOn(extraId);
            }
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.ToggleExtra(extraId, state);
            }
        }

        public bool IsNeonActive
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsNeonActive;
                }
            }
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    left = false;
                    right = false;
                    top = false;
                    back = false;
                    return;
                }

                BaseObject.GetNeonActive(ref left, ref right, ref top, ref back);
            }
        }

        public void SetNeonActive(bool left, bool right, bool top, bool back)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetNeonActive(left, right, top, back);
            }
        }

        public bool EngineOn
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.EngineOn;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.EngineOn = value;
                }
            }
        }

        public bool IsHandbrakeActive
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsHandbrakeActive;
                }
            }
        }

        public byte HeadlightColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.HeadlightColor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.HeadlightColor = value;
                }
            }
        }

        public uint RadioStation
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.RadioStation;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.RadioStation = value;
                }
            }
        }

        public bool SirenActive
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.SirenActive;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.SirenActive = value;
                }
            }
        }

        public VehicleLockState LockState
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.LockState;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.LockState = value;
                }
            }
        }

        public byte GetDoorState(byte doorId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetDoorState(doorId);
            }
        }

        public void SetDoorState(byte doorId, byte state)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetDoorState(doorId, state);
            }
        }

        public bool IsWindowOpened(byte windowId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsWindowOpened(windowId);
            }
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWindowOpened(windowId, state);
            }
        }

        public bool IsDaylightOn
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsDaylightOn;
                }
            }
        }

        public bool IsNightlightOn
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsNightlightOn;
                }
            }
        }

        public byte RoofState
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.RoofState;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.RoofState = value;
                }
            }
        }

        public bool IsFlamethrowerActive
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsFlamethrowerActive;
                }
            }
        }

        public float LightsMultiplier
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.LightsMultiplier;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.LightsMultiplier = value;
                }
            }
        }

        public string State
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.State;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.State = value;
                }
            }
        }

        public int EngineHealth
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.EngineHealth;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.EngineHealth = value;
                }
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.PetrolTankHealth;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.PetrolTankHealth = value;
                }
            }
        }

        public byte WheelsCount
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.WheelsCount;
                }
            }
        }

        public bool IsWheelBurst(byte wheelId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsWheelBurst(wheelId);
            }
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWheelBurst(wheelId, state);
            }
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.DoesWheelHasTire(wheelId);
            }
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWheelHasTire(wheelId, state);
            }
        }

        public bool IsWheelDetached(byte wheelId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsWheelDetached(wheelId);
            }
        }

        public void SetWheelDetached(byte wheelId, bool state)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWheelDetached(wheelId, state);
            }
        }

        public bool IsWheelOnFire(byte wheelId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsWheelOnFire(wheelId);
            }
        }

        public void SetWheelOnFire(byte wheelId, bool state)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWheelOnFire(wheelId, state);
            }
        }

        public float GetWheelHealth(byte wheelId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetWheelHealth(wheelId);
            }
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWheelHealth(wheelId, health);
            }
        }

        public void SetWheelFixed(byte wheelId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWheelFixed(wheelId);
            }
        }

        public byte RepairsCount
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.RepairsCount;
                }
            }
        }

        public uint BodyHealth
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.BodyHealth;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.BodyHealth = value;
                }
            }
        }

        public uint BodyAdditionalHealth
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.BodyAdditionalHealth;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.BodyAdditionalHealth = value;
                }
            }
        }

        public string HealthData
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.HealthData;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.HealthData = value;
                }
            }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetPartDamageLevel(partId);
            }
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetPartDamageLevel(partId, damage);
            }
        }

        public byte GetPartBulletHoles(byte partId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetPartBulletHoles(partId);
            }
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetPartBulletHoles(partId, shootsCount);
            }
        }

        public bool IsLightDamaged(byte lightId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsLightDamaged(lightId);
            }
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetLightDamaged(lightId, isDamaged);
            }
        }

        public bool IsWindowDamaged(byte windowId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsWindowDamaged(windowId);
            }
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetWindowDamaged(windowId, isDamaged);
            }
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return false;
                return BaseObject.IsSpecialLightDamaged(specialLightId);
            }
        }

        public void SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetSpecialLightDamaged(specialLightId, isDamaged);
            }
        }

        public bool HasArmoredWindows
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.HasArmoredWindows;
                }
            }
        }

        public float GetArmoredWindowHealth(byte windowId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetArmoredWindowHealth(windowId);
            }
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetArmoredWindowHealth(windowId, health);
            }
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetArmoredWindowShootCount(windowId);
            }
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetArmoredWindowShootCount(windowId, count);
            }
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.GetBumperDamageLevel(bumperId);
            }
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetPartBulletHoles(bumperId, damageLevel);
            }
        }

        public string DamageData
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.DamageData;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.DamageData = value;
                }
            }
        }

        public bool ManualEngineControl
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ManualEngineControl;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.ManualEngineControl = value;
                }
            }
        }

        public string ScriptData
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ScriptData;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.ScriptData = value;
                }
            }
        }

        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlockingNullable(() => BaseObject.Remove());
        }

        public void Repair()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.Repair();
            }
        }

        public Position Velocity
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Velocity;
                }
            }
        }

        public bool DriftMode
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.DriftMode;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.DriftMode = value;
                }
            }
        }

        public bool BoatAnchor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.BoatAnchor;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.BoatAnchor = value;
                }
            }
        }

        public bool SetSearchLight(bool state, IEntity spottedEntity)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.SetSearchLight(state, spottedEntity);
            }
        }

        public bool IsMissionTrain
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsMissionTrain;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.IsMissionTrain = value;
                }
            }
        }

        public sbyte TrainTrackId
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainTrackId;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainTrackId = value;
                }
            }
        }

        public IVehicle TrainEngine
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainEngine;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainEngine = value;
                }
            }
        }

        public sbyte TrainConfigIndex
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainConfigIndex;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainConfigIndex = value;
                }
            }
        }

        public float TrainDistanceFromEngine
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainDistanceFromEngine;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainDistanceFromEngine = value;
                }
            }
        }

        public bool IsTrainEngine
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsTrainEngine;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.IsTrainEngine = value;
                }
            }
        }

        public bool IsTrainCaboose
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsTrainCaboose;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.IsTrainCaboose = value;
                }
            }
        }

        public bool TrainDirection
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainDirection;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainDirection = value;
                }
            }
        }

        public bool TrainPassengerCarriages
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainPassengerCarriages;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainPassengerCarriages = value;
                }
            }
        }

        public bool TrainRenderDerailed
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainRenderDerailed;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainRenderDerailed = value;
                }
            }
        }

        public bool TrainForceDoorsOpen
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainForceDoorsOpen;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainForceDoorsOpen = value;
                }
            }
        }

        public float TrainCruiseSpeed
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainCruiseSpeed;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainCruiseSpeed = value;
                }
            }
        }

        public sbyte TrainCarriageConfigIndex
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainCarriageConfigIndex;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainCarriageConfigIndex = value;
                }
            }
        }

        public IVehicle TrainLinkedToBackward
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainLinkedToBackward;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainLinkedToBackward = value;
                }
            }
        }

        public IVehicle TrainLinkedToForward
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TrainLinkedToForward;
                }
            }
            set
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TrainLinkedToForward = value;
                }
            }
        }
    }
}