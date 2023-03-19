using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using AltV.Net.Native;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PedBoneInfo
    {
        public ushort Id;
        public ushort Index;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Name;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal readonly struct PedModelInfoInternal
    {
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string Name;
        private readonly uint Hash;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string Type;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string DlcName;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string DefaultUnarmedWeapon;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string MovementClipSet;
        private readonly IntPtr BonesPtr;
        private readonly uint BonesSize;

        public PedModelInfo ToPublic()
        {
            var arr = new PedBoneInfo[BonesSize];
            var elSize = Marshal.SizeOf<PedBoneInfo>();
            for (var i = 0; i < BonesSize; i++)
            {
                arr[i] = Marshal.PtrToStructure<PedBoneInfo>(IntPtr.Add(BonesPtr, i * elSize));
            }

            return new PedModelInfo
            {
                Name = Name,
                Type = Type,
                DlcName = DlcName,
                DefaultUnarmedWeapon = DefaultUnarmedWeapon,
                MovementClipSet = MovementClipSet,
                Hash = Hash,
                Bones = arr
            };
        }
    }

    public struct PedModelInfo
    {
        public string Name;
        public string Type;
        public string DlcName;
        public string DefaultUnarmedWeapon;
        public string MovementClipSet;
        public uint Hash;
        public PedBoneInfo[] Bones;
    }
}