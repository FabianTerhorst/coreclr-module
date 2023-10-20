using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using AltV.Net.Native;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    internal readonly struct WeaponModelInfoInternal
    {
        private readonly uint Hash;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string Name;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string ModelName;
        private readonly uint ModelHash;
        private readonly uint AmmoTypeHash;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string AmmoType;
        [MarshalAs(UnmanagedType.LPStr)]
        private readonly string AmmoModelName;
        private readonly uint AmmoModelHash;
        private readonly int DefaultMaxAmmoMp;
        private readonly int SkillAbove50MaxAmmoMp;
        private readonly int MaxSkillMaxAmmoMp;
        private readonly int BonusMaxAmmoMp;

        public WeaponModelInfo ToPublic()
        {
            return new WeaponModelInfo
            {
                Hash = Hash,
                Name = Name,
                ModelName = ModelName,
                ModelHash = ModelHash,
                AmmoTypeHash = AmmoTypeHash,
                AmmoType = AmmoType,
                AmmoModelName = AmmoModelName,
                AmmoModelHash = AmmoModelHash,
                DefaultMaxAmmoMp = DefaultMaxAmmoMp,
                SkillAbove50MaxAmmoMp = SkillAbove50MaxAmmoMp,
                MaxSkillMaxAmmoMp = MaxSkillMaxAmmoMp,
                BonusMaxAmmoMp = BonusMaxAmmoMp
            };
        }
    }

    public struct WeaponModelInfo
    {
        public uint Hash;
        public string Name;
        public string ModelName;
        public uint ModelHash;
        public uint AmmoTypeHash;
        public string AmmoType;
        public string AmmoModelName;
        public uint AmmoModelHash;
        public int DefaultMaxAmmoMp;
        public int SkillAbove50MaxAmmoMp;
        public int MaxSkillMaxAmmoMp;
        public int BonusMaxAmmoMp;
    }
}