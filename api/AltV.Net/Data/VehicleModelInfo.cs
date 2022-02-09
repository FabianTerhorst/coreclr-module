using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using AltV.Net.Native;

namespace AltV.Net.Data
{
    public enum VehicleModelType : byte
    {
        INVALID,
        PED,
        AUTOMOBILE,
        PLANE,
        TRAILER,
        QUAD_BIKE,
        SUBMARINE_CAR,
        AMPHIBIOUS_AUTOMOBILE,
        AMPHIBIOUS_QUAD_BIKE,
        HELI,
        BLIMP,
        AUTOGYRO,
        BIKE,
        BMX,
        BOAT,
        TRAIN,
        SUBMARINE,
        OBJECT
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct VehicleModelInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Title;
        
        public readonly VehicleModelType Type;
        public readonly byte WheelsCount;
        
        [MarshalAs(UnmanagedType.I1)]
        public readonly bool HasArmoredWindows;
        
        public readonly byte PrimaryColor;
        public readonly byte SecondaryColor;
        public readonly byte PearlColor;
        public readonly byte WheelsColor;
        public readonly byte InteriorColor;
        public readonly byte DashboardColor;
        public readonly ushort Extras;
        public readonly ushort DefaultExtras;
        
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 2)] 
        public readonly bool[] ModKits;
    
        public bool HasExtra(byte extraId)
        {
            return (this.Extras & (1ul << extraId)) != 0;
        }
        
        public bool HasDefaultExtra(byte extraId)
        {
            return (this.DefaultExtras & (1ul << extraId)) != 0;
        }
    }
}