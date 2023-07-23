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
    internal readonly struct VehicleModelInfoInternal
    {
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string Title;

        private readonly VehicleModelType Type;
        private readonly byte WheelsCount;

        [MarshalAs(UnmanagedType.I1)]
        private readonly bool HasArmoredWindows;

        private readonly byte PrimaryColor;
        private readonly byte SecondaryColor;
        private readonly byte PearlColor;
        private readonly byte WheelsColor;
        private readonly byte InteriorColor;
        private readonly byte DashboardColor;
        private readonly ushort Extras;
        private readonly ushort DefaultExtras;

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 2)]
        private readonly bool[] ModKits;

        [MarshalAs(UnmanagedType.I1)]
        private readonly bool HasAutoAttachTrailer;
        private readonly IntPtr BonesPtr;
        private readonly uint BonesSize;

        [MarshalAs(UnmanagedType.I1)]
        private readonly bool CanAttachCars;

        public VehicleModelInfo ToPublic()
        {
            var arr = new BoneInfo[BonesSize];
            var elSize = Marshal.SizeOf<BoneInfo>();
            for (var i = 0; i < BonesSize; i++)
            {
                arr[i] = Marshal.PtrToStructure<BoneInfo>(IntPtr.Add(BonesPtr, i * elSize));
            }

            return new VehicleModelInfo
            {
                Title = Title,
                Type = Type,
                WheelsCount = WheelsCount,
                HasArmoredWindows = HasArmoredWindows,
                PrimaryColor = PrimaryColor,
                SecondaryColor = SecondaryColor,
                PearlColor = PearlColor,
                WheelsColor = WheelsColor,
                InteriorColor = InteriorColor,
                DashboardColor = DashboardColor,
                Extras = Extras,
                DefaultExtras = DefaultExtras,
                ModKits = ModKits,
                HasAutoAttachTrailer = HasAutoAttachTrailer,
                Bones = arr,
                CanAttachCars = CanAttachCars
            };
        }
    }

    public struct VehicleModelInfo
    {
        public string Title;
        public VehicleModelType Type;

        public byte WheelsCount;
        public bool HasArmoredWindows;

        public byte PrimaryColor;
        public byte SecondaryColor;
        public byte PearlColor;
        public byte WheelsColor;
        public byte InteriorColor;
        public byte DashboardColor;
        public ushort Extras;
        public ushort DefaultExtras;
        public bool[] ModKits;
        public bool HasAutoAttachTrailer;
        public BoneInfo[] Bones;
        public bool CanAttachCars;

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