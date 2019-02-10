using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVehicle: MockEntity, IVehicle
    {   
        public MockVehicle(IntPtr nativePointer, ushort id): base(nativePointer, EntityType.Vehicle, id)
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

        public byte GetModKitsCount()
        {
            return 0;
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
    }
}