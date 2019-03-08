using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Mock
{
    public class MockVehicle: MockEntity, IVehicle
    {   
        public MockVehicle(IntPtr nativePointer, ushort id): base(nativePointer, BaseObjectType.Vehicle, id)
        {
        }

        public IPlayer Driver { get; }
        public byte ModKit { get; set; }
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
        public Rgba TireSmokeColor { get; set; }
        public byte WheelType { get; }
        public byte WheelVariation { get; }
        public bool CustomTires { get; set; }
        public byte SpecialDarkness { get; set; }
        public uint NumberPlateIndex { get; set; }
        public string NumberPlateText { get; set; }
        public byte WindowTint { get; set; }
        public byte DirtLevel { get; set; }
        public Rgba NeonColor { get; set; }
        public byte ModKitsCount { get; }

        public bool IsTireSmokeColorCustom { get; }
        public bool IsNeonActive { get; }

        public byte GetMod(byte category)
        {
            return 0;
        }

        public byte GetModsCount(byte category)
        {
            return 0;
        }

        public bool SetMod(byte category, byte id)
        {
            return true;
        }

        public void SetWheels(byte type, byte variation)
        {
            
        }

        public bool IsExtraOn(byte extraId)
        {
            return false;
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back)
        {
            
        }

        public void SetNeonActive(bool left, bool right, bool top, bool back)
        {
            
        }
        
        //TODO: wip vehicle apis

        public bool EngineOn { get; set; }
        public bool IsHandbrakeActive { get; }
        public byte HeadlightColor { get; set; }
        public bool SirenActive { get; set; }
        public VehicleLockState LockState { get; set; }
        public byte GetDoorState(byte doorId)
        {
            throw new NotImplementedException();
        }

        public void SetDoorState(byte doorId, byte state)
        {
            throw new NotImplementedException();
        }

        public bool IsWindowOpened(byte windowId)
        {
            throw new NotImplementedException();
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            throw new NotImplementedException();
        }

        public bool IsDaylightOn { get; }
        public bool IsNightlightOn { get; }
        public bool RoofOpened { get; set; }
        public bool IsFlamethrowerActive { get; }
        public string State { get; set; }
        public int EngineHealth { get; set; }
        public int PetrolTankHealth { get; set; }
        public byte WheelsCount { get; }
        public bool IsWheelBurst(byte wheelId)
        {
            throw new NotImplementedException();
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            throw new NotImplementedException();
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            throw new NotImplementedException();
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            throw new NotImplementedException();
        }

        public float GetWheelHealth(byte wheelId)
        {
            throw new NotImplementedException();
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            throw new NotImplementedException();
        }

        public byte RepairsCount { get; }
        public uint BodyHealth { get; set; }
        public uint BodyAdditionalHealth { get; set; }
        public string HealthData { get; set; }
        public byte GetPartDamageLevel(byte partId)
        {
            throw new NotImplementedException();
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            throw new NotImplementedException();
        }

        public byte GetPartBulletHoles(byte partId)
        {
            throw new NotImplementedException();
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            throw new NotImplementedException();
        }

        public bool IsLightDamaged(byte lightId)
        {
            throw new NotImplementedException();
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            throw new NotImplementedException();
        }

        public bool IsWindowDamaged(byte windowId)
        {
            throw new NotImplementedException();
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            throw new NotImplementedException();
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            throw new NotImplementedException();
        }

        public void SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            throw new NotImplementedException();
        }

        public bool HasArmoredWindows { get; }
        public float GetArmoredWindowHealth(byte windowId)
        {
            throw new NotImplementedException();
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            throw new NotImplementedException();
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            throw new NotImplementedException();
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            throw new NotImplementedException();
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            throw new NotImplementedException();
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            throw new NotImplementedException();
        }

        public string DamageData { get; set; }
    }
}