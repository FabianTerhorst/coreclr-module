using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVehicle<TVehicle> : AsyncEntity<TVehicle>, IVehicle where TVehicle : class, IVehicle
    {
        public IPlayer Driver
        {
            get
            {
                AsyncContext.RunAll();
                IPlayer driver = default;
                AsyncContext.RunOnMainThreadBlocking(() => driver = BaseObject.Driver);
                return driver;
            }
        }

        public bool IsDestroyed
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsDestroyed;
                }
            }
        }

        public byte ModKit
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ModKit;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.ModKit = value); }
        }

        public byte ModKitsCount
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ModKitsCount;
                }
            }
        }

        public bool IsPrimaryColorRgb
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsPrimaryColorRgb;
                }
            }
        }

        public byte PrimaryColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.PrimaryColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.PrimaryColor = value); }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.PrimaryColorRgb;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.PrimaryColorRgb = value); }
        }

        public bool IsSecondaryColorRgb
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsSecondaryColorRgb;
                }
            }
        }

        public byte SecondaryColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.SecondaryColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.SecondaryColor = value); }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.SecondaryColorRgb;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.SecondaryColorRgb = value); }
        }

        public byte PearlColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.PearlColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.PearlColor = value); }
        }

        public byte WheelColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.WheelColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.WheelColor = value); }
        }

        public byte InteriorColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.InteriorColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.InteriorColor = value); }
        }

        public byte DashboardColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.DashboardColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.DashboardColor = value); }
        }

        public bool IsTireSmokeColorCustom
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsTireSmokeColorCustom;
                }
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TireSmokeColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TireSmokeColor = value); }
        }

        public byte WheelType
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.WheelType;
                }
            }
        }

        public byte WheelVariation
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.WheelVariation;
                }
            }
        }

        public byte RearWheel
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.RearWheel;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.RearWheel = value); }
        }

        public bool CustomTires
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.CustomTires;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.CustomTires = value); }
        }

        public byte SpecialDarkness
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.SpecialDarkness;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.SpecialDarkness = value); }
        }

        public uint NumberplateIndex
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.NumberplateIndex;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.NumberplateIndex = value); }
        }

        public string NumberplateText
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.NumberplateText;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.NumberplateText = value); }
        }

        public byte WindowTint
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.WindowTint;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.WindowTint = value); }
        }

        public byte DirtLevel
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.DirtLevel;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.DirtLevel = value); }
        }

        public Rgba NeonColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.NeonColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.NeonColor = value); }
        }

        public byte Livery
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Livery;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Livery = value); }
        }

        public byte RoofLivery
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.RoofLivery;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.RoofLivery = value); }
        }

        public string AppearanceData
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.AppearanceData;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.AppearanceData = value); }
        }

        public IVehicle Attached
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Attached;
                }
            }
        }

        public IVehicle AttachedTo
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.AttachedTo;
                }
            }
        }

        public AsyncVehicle(TVehicle vehicle, IAsyncContext asyncContext) : base(vehicle, asyncContext)
        {
        }

        public byte GetMod(byte category)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetMod(category);
            }
        }

        public byte GetModsCount(byte category)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetModsCount(category);
            }
        }

        public bool SetMod(byte category, byte id)
        {
            var result = false;
            AsyncContext.Enqueue(() => result = BaseObject.SetMod(category, id));
            return result;
        }

        public void SetWheels(byte type, byte variation)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWheels(type, variation));
        }

        public bool IsExtraOn(byte extraId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsExtraOn(extraId);
            }
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            AsyncContext.Enqueue(() => BaseObject.ToggleExtra(extraId, state));
        }

        public bool IsNeonActive
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsNeonActive;
                }
            }
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
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
            AsyncContext.Enqueue(() => BaseObject.SetNeonActive(left, right, top, back));
        }

        public bool EngineOn
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.EngineOn;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.EngineOn = value); }
        }

        public bool IsHandbrakeActive
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsHandbrakeActive;
                }
            }
        }

        public byte HeadlightColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HeadlightColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.HeadlightColor = value); }
        }

        public uint RadioStation
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.RadioStation;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.RadioStation = value); }
        }

        public bool SirenActive
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.SirenActive;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.SirenActive = value); }
        }

        public VehicleLockState LockState
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.LockState;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.LockState = value); }
        }

        public byte GetDoorState(byte doorId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetDoorState(doorId);
            }
        }

        public void SetDoorState(byte doorId, byte state)
        {
            AsyncContext.Enqueue(() => BaseObject.SetDoorState(doorId, state));
        }

        public bool IsWindowOpened(byte windowId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsWindowOpened(windowId);
            }
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWindowOpened(windowId, state));
        }

        public bool IsDaylightOn
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsDaylightOn;
                }
            }
        }

        public bool IsNightlightOn
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsNightlightOn;
                }
            }
        }

        public byte RoofState
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.RoofState;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.RoofState = value); }
        }

        public bool IsFlamethrowerActive
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsFlamethrowerActive;
                }
            }
        }

        public float LightsMultiplier
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.LightsMultiplier;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.LightsMultiplier = value); }
        }

        public string State
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.State;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.State = value); }
        }

        public int EngineHealth
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.EngineHealth;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.EngineHealth = value); }
        }

        public int PetrolTankHealth
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.PetrolTankHealth;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.PetrolTankHealth = value); }
        }

        public byte WheelsCount
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.WheelsCount;
                }
            }
        }

        public bool IsWheelBurst(byte wheelId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsWheelBurst(wheelId);
            }
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWheelBurst(wheelId, state));
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.DoesWheelHasTire(wheelId);
            }
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWheelHasTire(wheelId, state));
        }

        public bool IsWheelDetached(byte wheelId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsWheelDetached(wheelId);
            }
        }

        public void SetWheelDetached(byte wheelId, bool state)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWheelDetached(wheelId, state));
        }

        public bool IsWheelOnFire(byte wheelId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsWheelOnFire(wheelId);
            }
        }

        public void SetWheelOnFire(byte wheelId, bool state)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWheelOnFire(wheelId, state));
        }

        public float GetWheelHealth(byte wheelId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetWheelHealth(wheelId);
            }
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWheelHealth(wheelId, health));
        }

        public void SetWheelFixed(byte wheelId)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWheelFixed(wheelId));
        }

        public byte RepairsCount
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.RepairsCount;
                }
            }
        }

        public uint BodyHealth
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.BodyHealth;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.BodyHealth = value); }
        }

        public uint BodyAdditionalHealth
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.BodyAdditionalHealth;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.BodyAdditionalHealth = value); }
        }

        public string HealthData
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HealthData;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.HealthData = value); }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetPartDamageLevel(partId);
            }
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            AsyncContext.Enqueue(() => BaseObject.SetPartDamageLevel(partId, damage));
        }

        public byte GetPartBulletHoles(byte partId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetPartBulletHoles(partId);
            }
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            AsyncContext.Enqueue(() => BaseObject.SetPartBulletHoles(partId, shootsCount));
        }

        public bool IsLightDamaged(byte lightId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsLightDamaged(lightId);
            }
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            AsyncContext.Enqueue(() => BaseObject.SetLightDamaged(lightId, isDamaged));
        }

        public bool IsWindowDamaged(byte windowId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsWindowDamaged(windowId);
            }
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            AsyncContext.Enqueue(() => BaseObject.SetWindowDamaged(windowId, isDamaged));
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return false;
                return BaseObject.IsSpecialLightDamaged(specialLightId);
            }
        }

        public void SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            AsyncContext.Enqueue(() => BaseObject.SetSpecialLightDamaged(specialLightId, isDamaged));
        }

        public bool HasArmoredWindows
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HasArmoredWindows;
                }
            }
        }

        public float GetArmoredWindowHealth(byte windowId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetArmoredWindowHealth(windowId);
            }
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            AsyncContext.Enqueue(() => BaseObject.SetArmoredWindowHealth(windowId, health));
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetArmoredWindowShootCount(windowId);
            }
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            AsyncContext.Enqueue(() => BaseObject.SetArmoredWindowShootCount(windowId, count));
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.GetBumperDamageLevel(bumperId);
            }
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            AsyncContext.Enqueue(() => BaseObject.SetPartBulletHoles(bumperId, damageLevel));
        }

        public string DamageData
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.DamageData;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.DamageData = value); }
        }

        public bool ManualEngineControl
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ManualEngineControl;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.ManualEngineControl = value); }
        }

        public string ScriptData
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ScriptData;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.ScriptData = value); }
        }

        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlocking(() => BaseObject.Remove());
        }

        public void Repair()
        {
            AsyncContext.Enqueue(() => BaseObject.Repair());
        }

        public Position Velocity
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Velocity;
                }
            }
        }

        public bool DriftMode
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.DriftMode;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.DriftMode = value); }
        }
        
        public bool SetSearchLight(bool state, IEntity spottedEntity)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.SetSearchLight(state, spottedEntity);
            }
        }
        
        public bool IsMissionTrain
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsMissionTrain;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.IsMissionTrain = value); }
        }

        public sbyte TrainTrackId
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainTrackId;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainTrackId = value); }
        }

        public IVehicle TrainEngine
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainEngine;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainEngine = value); }
        }

        public sbyte TrainConfigIndex
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainConfigIndex;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainConfigIndex = value); }
        }

        public float TrainDistanceFromEngine
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainDistanceFromEngine;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainDistanceFromEngine = value); }
        }

        public bool IsTrainEngine
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsTrainEngine;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.IsTrainEngine = value); }
        }

        public bool IsTrainCaboose
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsTrainCaboose;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.IsTrainCaboose = value); }
        }

        public bool TrainDirection
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainDirection;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainDirection = value); }
        }

        public bool TrainPassengerCarriages
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainPassengerCarriages;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainPassengerCarriages = value); }
        }

        public bool TrainRenderDerailed
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainRenderDerailed;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainRenderDerailed = value); }
        }

        public bool TrainForceDoorsOpen
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainForceDoorsOpen;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainForceDoorsOpen = value); }
        }

        public float TrainCruiseSpeed
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainCruiseSpeed;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainCruiseSpeed = value); }
        }

        public sbyte TrainCarriageConfigIndex
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainCarriageConfigIndex;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainCarriageConfigIndex = value); }
        }

        public IVehicle TrainLinkedToBackward
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainLinkedToBackward;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainLinkedToBackward = value); }
        }

        public IVehicle TrainLinkedToForward
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TrainLinkedToForward;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TrainLinkedToForward = value); }
        }
    }
}