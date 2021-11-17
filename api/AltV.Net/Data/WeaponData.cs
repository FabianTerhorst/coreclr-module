using AltV.Net.Native;
using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct WeaponDataInternal
    {
        public static WeaponDataInternal Empty = new(0, 0, 0, UIntArray.Nil);

        public uint ComponentsCount;
        public uint Hash;
        public byte TintIndex;
        public UIntArray Components;

        internal static readonly int Size = Marshal.SizeOf<WeaponDataInternal>();

        public WeaponDataInternal(uint hash, byte tintIndex, uint componentsCount, UIntArray components)
        {
            ComponentsCount = componentsCount;
            Hash = hash;
            TintIndex = tintIndex;
            Components = components;
        }

        public uint[] GetComponents()
        {
            var value = Components.data;
            var values = new uint[ComponentsCount];
            var buffer = new byte[4];

            for (var i = 0; i < values.Length; i++)
            {
                values[i] = UIntArray.ReadUInt32(buffer, value);
                value += UIntArray.UInt32Size;
            }

            return values;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponData : IEquatable<WeaponData>
    {
        public static WeaponData Empty = new(0, 0, Array.Empty<uint>());

        public uint Hash;
        public byte TintIndex;
        public uint[] Components;

        public WeaponData(uint hash, byte tintIndex, uint[] components)
        {
            Hash = hash;
            TintIndex = tintIndex;
            Components = components;
        }
        public override string ToString()
        {
            return $"WeaponData(hash: {Hash}, tintIndex: {TintIndex}, components: {Components.Length})";
        }

        public override bool Equals(object obj)
        {
            return obj is WeaponData other && Equals(other);
        }

        public bool Equals(WeaponData other)
        {
            return Hash.Equals(other.Hash) && TintIndex.Equals(other.TintIndex) && Components.Equals(other.Components);
        }

        public override int GetHashCode() => HashCode.Combine(Hash.GetHashCode(), TintIndex.GetHashCode(), Components.GetHashCode());
    }
}
