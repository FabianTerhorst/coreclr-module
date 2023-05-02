using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVehicle : AsyncEntity, IVehicle, IAsyncConvertible<IVehicle>
    {
        protected readonly IVehicle Vehicle;
        public IntPtr VehicleNativePointer => Vehicle.VehicleNativePointer;

        public IPlayer Driver
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return null;
                    return Vehicle.Driver;
                }
            }
        }

        public bool IsDestroyed
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsDestroyed;
                }
            }
        }

        public byte ModKit
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.ModKit;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.ModKit = value;
                }
            }
        }

        public byte ModKitsCount
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.ModKitsCount;
                }
            }
        }

        public bool IsPrimaryColorRgb
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsPrimaryColorRgb;
                }
            }
        }

        public byte PrimaryColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.PrimaryColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.PrimaryColor = value;
                }
            }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.PrimaryColorRgb;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.PrimaryColorRgb = value;
                }
            }
        }

        public bool IsSecondaryColorRgb
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsSecondaryColorRgb;
                }
            }
        }

        public byte SecondaryColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.SecondaryColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.SecondaryColor = value;
                }
            }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.SecondaryColorRgb;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.SecondaryColorRgb = value;
                }
            }
        }

        public byte PearlColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.PearlColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.PearlColor = value;
                }
            }
        }

        public byte WheelColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.WheelColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.WheelColor = value;
                }
            }
        }

        public byte InteriorColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.InteriorColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.InteriorColor = value;
                }
            }
        }

        public byte DashboardColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.DashboardColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.DashboardColor = value;
                }
            }
        }

        public bool IsTireSmokeColorCustom
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsTireSmokeColorCustom;
                }
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TireSmokeColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TireSmokeColor = value;
                }
            }
        }

        public byte WheelType
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.WheelType;
                }
            }
        }

        public byte WheelVariation
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.WheelVariation;
                }
            }
        }

        public byte RearWheel
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.RearWheel;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.RearWheel = value;
                }
            }
        }

        public bool CustomTires
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.CustomTires;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.CustomTires = value;
                }
            }
        }

        public byte SpecialDarkness
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.SpecialDarkness;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.SpecialDarkness = value;
                }
            }
        }

        public uint NumberplateIndex
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.NumberplateIndex;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.NumberplateIndex = value;
                }
            }
        }

        public string NumberplateText
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.NumberplateText;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.NumberplateText = value;
                }
            }
        }

        public byte WindowTint
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.WindowTint;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.WindowTint = value;
                }
            }
        }

        public byte DirtLevel
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.DirtLevel;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.DirtLevel = value;
                }
            }
        }

        public Rgba NeonColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.NeonColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.NeonColor = value;
                }
            }
        }

        public byte Livery
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.Livery;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.Livery = value;
                }
            }
        }

        public byte LightState
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.LightState;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.LightState = value;
                }
            }
        }

        public byte RoofLivery
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.RoofLivery;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.RoofLivery = value;
                }
            }
        }

        public string AppearanceData
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.AppearanceData;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.AppearanceData = value;
                }
            }
        }

        public IVehicle Attached
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.Attached;
                }
            }
        }

        public IVehicle AttachedTo
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.AttachedTo;
                }
            }
        }

        public AsyncVehicle(IVehicle vehicle, IAsyncContext asyncContext) : base(vehicle, asyncContext)
        {
            Vehicle = vehicle;
        }

        public AsyncVehicle(ICore core, IntPtr nativePointer, uint id) : this(new Vehicle(core, nativePointer, id), null)
        {
        }

        public AsyncVehicle(ICore core, uint model, Position position, Rotation rotation) : this(new Vehicle(core, model, position, rotation), null)
        {
        }

        public byte GetMod(byte category)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetMod(category);
            }
        }

        public byte GetModsCount(byte category)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetModsCount(category);
            }
        }

        public bool SetMod(byte category, byte id)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.SetMod(category, id);
            }
        }

        public void SetWheels(byte type, byte variation)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWheels(type, variation);
            }
        }

        public bool IsExtraOn(byte extraId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return false;
                return Vehicle.IsExtraOn(extraId);
            }
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.ToggleExtra(extraId, state);
            }
        }

        public bool IsNeonActive
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsNeonActive;
                }
            }
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle))
                {
                    left = false;
                    right = false;
                    top = false;
                    back = false;
                    return;
                }

                Vehicle.GetNeonActive(ref left, ref right, ref top, ref back);
            }
        }

        public void SetNeonActive(bool left, bool right, bool top, bool back)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetNeonActive(left, right, top, back);
            }
        }

        public bool EngineOn
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.EngineOn;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.EngineOn = value;
                }
            }
        }

        public bool IsHandbrakeActive
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsHandbrakeActive;
                }
            }
        }

        public byte HeadlightColor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.HeadlightColor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.HeadlightColor = value;
                }
            }
        }

        public uint RadioStation
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.RadioStation;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.RadioStation = value;
                }
            }
        }

        public IPlayer TimedExplosionCulprit
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return null;
                    return Vehicle.TimedExplosionCulprit;
                }
            }
        }

        public uint TimedExplosionTime
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TimedExplosionTime;
                }
            }
        }

    public bool SirenActive
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.SirenActive;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.SirenActive = value;
                }
            }
        }

        public VehicleLockState LockState
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.LockState;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.LockState = value;
                }
            }
        }

        public byte GetDoorState(byte doorId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetDoorState(doorId);
            }
        }

        public void SetDoorState(byte doorId, byte state)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetDoorState(doorId, state);
            }
        }

        public bool IsWindowOpened(byte windowId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return false;
                return Vehicle.IsWindowOpened(windowId);
            }
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWindowOpened(windowId, state);
            }
        }

        public bool IsDaylightOn
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsDaylightOn;
                }
            }
        }

        public bool IsNightlightOn
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsNightlightOn;
                }
            }
        }

        public bool IsRoofClosed
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsRoofClosed;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.IsRoofClosed = value;
                }
            }
        }

        public bool IsFlamethrowerActive
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsFlamethrowerActive;
                }
            }
        }

        public float LightsMultiplier
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.LightsMultiplier;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.LightsMultiplier = value;
                }
            }
        }

        public string State
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.State;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.State = value;
                }
            }
        }

        public int EngineHealth
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.EngineHealth;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.EngineHealth = value;
                }
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.PetrolTankHealth;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.PetrolTankHealth = value;
                }
            }
        }

        public byte WheelsCount
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.WheelsCount;
                }
            }
        }

        public bool IsWheelBurst(byte wheelId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return false;
                return Vehicle.IsWheelBurst(wheelId);
            }
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWheelBurst(wheelId, state);
            }
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return false;
                return Vehicle.DoesWheelHasTire(wheelId);
            }
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWheelHasTire(wheelId, state);
            }
        }

        public bool IsWheelDetached(byte wheelId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return false;
                return Vehicle.IsWheelDetached(wheelId);
            }
        }

        public void SetWheelDetached(byte wheelId, bool state)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWheelDetached(wheelId, state);
            }
        }

        public bool IsWheelOnFire(byte wheelId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return false;
                return Vehicle.IsWheelOnFire(wheelId);
            }
        }

        public void SetWheelOnFire(byte wheelId, bool state)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWheelOnFire(wheelId, state);
            }
        }

        public float GetWheelHealth(byte wheelId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                return Vehicle.GetWheelHealth(wheelId);
            }
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWheelHealth(wheelId, health);
            }
        }

        public void SetWheelFixed(byte wheelId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWheelFixed(wheelId);
            }
        }

        public byte RepairsCount
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.RepairsCount;
                }
            }
        }

        public uint BodyHealth
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.BodyHealth;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.BodyHealth = value;
                }
            }
        }

        public uint BodyAdditionalHealth
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.BodyAdditionalHealth;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.BodyAdditionalHealth = value;
                }
            }
        }

        public string HealthData
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.HealthData;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.HealthData = value;
                }
            }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetPartDamageLevel(partId);
            }
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetPartDamageLevel(partId, damage);
            }
        }

        public byte GetPartBulletHoles(byte partId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetPartBulletHoles(partId);
            }
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetPartBulletHoles(partId, shootsCount);
            }
        }

        public bool IsLightDamaged(byte lightId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return false;
                return Vehicle.IsLightDamaged(lightId);
            }
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetLightDamaged(lightId, isDamaged);
            }
        }

        public bool IsWindowDamaged(byte windowId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return false;
                return Vehicle.IsWindowDamaged(windowId);
            }
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWindowDamaged(windowId, isDamaged);
            }
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return false;
                return Vehicle.IsSpecialLightDamaged(specialLightId);
            }
        }

        public void SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetSpecialLightDamaged(specialLightId, isDamaged);
            }
        }

        public bool HasArmoredWindows
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.HasArmoredWindows;
                }
            }
        }

        public bool TimedExplosion
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TimedExplosion;
                }
            }
        }

        public float GetArmoredWindowHealth(byte windowId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetArmoredWindowHealth(windowId);
            }
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetArmoredWindowHealth(windowId, health);
            }
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetArmoredWindowShootCount(windowId);
            }
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetArmoredWindowShootCount(windowId, count);
            }
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetBumperDamageLevel(bumperId);
            }
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetBumperDamageLevel(bumperId, damageLevel);
            }
        }

        public string DamageData
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.DamageData;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.DamageData = value;
                }
            }
        }

        public bool ManualEngineControl
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.ManualEngineControl;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.ManualEngineControl = value;
                }
            }
        }

        public string ScriptData
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.ScriptData;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.ScriptData = value;
                }
            }
        }

        public void Repair()
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.Repair();
            }
        }

        public void SetTimedExplosion(bool state, IPlayer culprit, uint time)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetTimedExplosion(state, culprit, time);
            }
        }

        public Position Velocity
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.Velocity;
                }
            }
        }

        public bool DriftMode
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.DriftMode;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.DriftMode = value;
                }
            }
        }

        public bool BoatAnchor
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.BoatAnchor;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.BoatAnchor = value;
                }
            }
        }

        public bool SetSearchLight(bool state, IEntity spottedEntity)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.SetSearchLight(state, spottedEntity);
            }
        }

        public bool IsMissionTrain
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsMissionTrain;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.IsMissionTrain = value;
                }
            }
        }

        public sbyte TrainTrackId
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainTrackId;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainTrackId = value;
                }
            }
        }

        public IVehicle TrainEngine
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainEngine;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainEngine = value;
                }
            }
        }

        public sbyte TrainConfigIndex
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainConfigIndex;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainConfigIndex = value;
                }
            }
        }

        public float TrainDistanceFromEngine
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainDistanceFromEngine;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainDistanceFromEngine = value;
                }
            }
        }

        public bool IsTrainEngine
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsTrainEngine;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.IsTrainEngine = value;
                }
            }
        }

        public bool IsTrainCaboose
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsTrainCaboose;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.IsTrainCaboose = value;
                }
            }
        }

        public bool TrainDirection
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainDirection;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainDirection = value;
                }
            }
        }

        public bool TrainPassengerCarriages
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainPassengerCarriages;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainPassengerCarriages = value;
                }
            }
        }

        public bool TrainRenderDerailed
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainRenderDerailed;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainRenderDerailed = value;
                }
            }
        }

        public bool TrainForceDoorsOpen
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainForceDoorsOpen;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainForceDoorsOpen = value;
                }
            }
        }

        public float TrainCruiseSpeed
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainCruiseSpeed;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainCruiseSpeed = value;
                }
            }
        }

        public sbyte TrainCarriageConfigIndex
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainCarriageConfigIndex;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainCarriageConfigIndex = value;
                }
            }
        }

        public IVehicle TrainLinkedToBackward
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainLinkedToBackward;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainLinkedToBackward = value;
                }
            }
        }

        public IVehicle TrainLinkedToForward
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.TrainLinkedToForward;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.TrainLinkedToForward = value;
                }
            }
        }

        public uint CounterMeasureCount
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.CounterMeasureCount;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.CounterMeasureCount = value;
                }
            }
        }

        public bool HybridExtraActive
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.HybridExtraActive;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.HybridExtraActive = value;
                }
            }
        }

        public byte HybridExtraState
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.HybridExtraState;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.HybridExtraState = value;
                }
            }
        }

        public float RocketRefuelSpeed
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.RocketRefuelSpeed;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.RocketRefuelSpeed = value;
                }
            }
        }

        public float ScriptMaxSpeed
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.ScriptMaxSpeed;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.ScriptMaxSpeed = value;
                }
            }
        }

        public bool IsTowingDisabled
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.IsTowingDisabled;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.IsTowingDisabled = value;
                }
            }
        }

        public void SetWeaponCapacity(byte index, int capacity)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                Vehicle.SetWeaponCapacity(index, capacity);
            }
        }

        public int GetWeaponCapacity(byte index)
        {
            lock (Vehicle)
            {
                if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return default;
                return Vehicle.GetWeaponCapacity(index);
            }
        }

        public Quaternion Quaternion
        {
            get
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Vehicle)) return default;
                    return Vehicle.Quaternion;
                }
            }
            set
            {
                lock (Vehicle)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Vehicle)) return;
                    Vehicle.Quaternion = value;
                }
            }
        }

        [Obsolete("Use new async API instead")]
        public IVehicle ToAsync(IAsyncContext asyncContext)
        {
            return this;
        }
    }
}