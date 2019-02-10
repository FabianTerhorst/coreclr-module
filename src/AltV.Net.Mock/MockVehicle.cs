using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockVehicle: IVehicle
    {
        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public ushort Id { get; }
        public EntityType Type { get; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public ushort Dimension { get; set; }
        
        public MockVehicle(IntPtr nativePointer, ushort id)
        {
            NativePointer = nativePointer;
            Type = EntityType.Vehicle;
            Id = id;
            Exists = true;
        }
        
        public void SetPosition(float x, float y, float z)
        {
            
        }

        public void SetRotation(float roll, float pitch, float yaw)
        {
            
        }

        public void SetMetaData(string key, MValue value)
        {
            
        }

        public MValue GetMetaData(string key)
        {
            return MValue.Nil;
        }

        public void SetData(string key, object value)
        {
            
        }

        public bool GetData<T>(string key, out T result)
        {
            result = default;
            return false;
        }

        public bool Remove()
        {
            return false;
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