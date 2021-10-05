using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncVehicle : AsyncEntity<IVehicle>, IVehicle
    {
        public IPlayer Driver { get; }
        public bool IsDestroyed { get; }
        public byte ModKit { get; set; }
        public byte ModKitsCount { get; }
        public bool IsPrimaryColorRgb { get; }
        public byte PrimaryColor { get; set; }
        public Rgba PrimaryColorRgb { get; set; }
        public bool IsSecondaryColorRgb { get; }
        public byte SecondaryColor { get; set; }
        public Rgba SecondaryColorRgb { get; set; }
        public byte PearlColor { get; set; }
        public byte WheelColor { get; set; }
        public byte InteriorColor { get; set; }
        public byte DashboardColor { get; set; }
        public bool IsTireSmokeColorCustom { get; }
        public Rgba TireSmokeColor { get; set; }
        public byte WheelType { get; }
        public byte WheelVariation { get; }
        public byte RearWheel { get; set; }
        public bool CustomTires { get; set; }
        public byte SpecialDarkness { get; set; }
        public uint NumberplateIndex { get; set; }
        public string NumberplateText { get; set; }
        public byte WindowTint { get; set; }
        public byte DirtLevel { get; set; }
        public Rgba NeonColor { get; set; }
        public byte Livery { get; set; }
        public byte RoofLivery { get; set; }
        public string AppearanceData { get; set; }
        public IVehicle Attached { get; }
        public IVehicle AttachedTo { get; }
        
        public AsyncVehicle(IVehicle vehicle, IAsyncContext asyncContext):base(vehicle, asyncContext)
        {
        }
        
        public byte GetMod(byte category)
        {
            throw new System.NotImplementedException();
        }

        public byte GetModsCount(byte category)
        {
            throw new System.NotImplementedException();
        }

        public bool SetMod(byte category, byte id)
        {
            throw new System.NotImplementedException();
        }

        public void SetWheels(byte type, byte variation)
        {
            throw new System.NotImplementedException();
        }

        public bool IsExtraOn(byte extraId)
        {
            throw new System.NotImplementedException();
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            throw new System.NotImplementedException();
        }

        public bool IsNeonActive { get; }
        public void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back)
        {
            throw new System.NotImplementedException();
        }

        public void SetNeonActive(bool left, bool right, bool top, bool back)
        {
            throw new System.NotImplementedException();
        }

        public bool EngineOn { get; set; }
        public bool IsHandbrakeActive { get; }
        public byte HeadlightColor { get; set; }
        public uint RadioStation { get; set; }
        public bool SirenActive { get; set; }
        public VehicleLockState LockState { get; set; }
        public byte GetDoorState(byte doorId)
        {
            throw new System.NotImplementedException();
        }

        public void SetDoorState(byte doorId, byte state)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWindowOpened(byte windowId)
        {
            throw new System.NotImplementedException();
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            throw new System.NotImplementedException();
        }

        public bool IsDaylightOn { get; }
        public bool IsNightlightOn { get; }
        public byte RoofState { get; set; }
        public bool IsFlamethrowerActive { get; }
        public float LightsMultiplier { get; set; }
        public string State { get; set; }
        public int EngineHealth { get; set; }
        public int PetrolTankHealth { get; set; }
        public byte WheelsCount { get; }
        public bool IsWheelBurst(byte wheelId)
        {
            throw new System.NotImplementedException();
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            throw new System.NotImplementedException();
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            throw new System.NotImplementedException();
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWheelDetached(byte wheelId)
        {
            throw new System.NotImplementedException();
        }

        public void SetWheelDetached(byte wheelId, bool state)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWheelOnFire(byte wheelId)
        {
            throw new System.NotImplementedException();
        }

        public void SetWheelOnFire(byte wheelId, bool state)
        {
            throw new System.NotImplementedException();
        }

        public float GetWheelHealth(byte wheelId)
        {
            throw new System.NotImplementedException();
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            throw new System.NotImplementedException();
        }

        public void SetWheelFixed(byte wheelId)
        {
            throw new System.NotImplementedException();
        }

        public byte RepairsCount { get; }
        public uint BodyHealth { get; set; }
        public uint BodyAdditionalHealth { get; set; }
        public string HealthData { get; set; }
        public byte GetPartDamageLevel(byte partId)
        {
            throw new System.NotImplementedException();
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            throw new System.NotImplementedException();
        }

        public byte GetPartBulletHoles(byte partId)
        {
            throw new System.NotImplementedException();
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            throw new System.NotImplementedException();
        }

        public bool IsLightDamaged(byte lightId)
        {
            throw new System.NotImplementedException();
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            throw new System.NotImplementedException();
        }

        public bool IsWindowDamaged(byte windowId)
        {
            throw new System.NotImplementedException();
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            throw new System.NotImplementedException();
        }

        public void SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            throw new System.NotImplementedException();
        }

        public bool HasArmoredWindows { get; }
        public float GetArmoredWindowHealth(byte windowId)
        {
            throw new System.NotImplementedException();
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            throw new System.NotImplementedException();
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            throw new System.NotImplementedException();
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            throw new System.NotImplementedException();
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            throw new System.NotImplementedException();
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            throw new System.NotImplementedException();
        }

        public string DamageData { get; set; }
        public bool ManualEngineControl { get; set; }
        public string ScriptData { get; set; }
        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Repair()
        {
            throw new System.NotImplementedException();
        }
    }
}