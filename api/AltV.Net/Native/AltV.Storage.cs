using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    //TODO: test if structs gets cleaned up on deconstructor in cpp
    internal static class StorageUtils
    {
        internal static IntPtr StructToPtr(object obj)
        {
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
            Marshal.StructureToPtr(obj, ptr, false);
            return ptr;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BoolStorage
    {
        public static IntPtr Create(bool value)
        {
            return StorageUtils.StructToPtr(new BoolStorage(value));
        }

        public bool value;
        private uint refCount;

        public BoolStorage(bool value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EntityStorage
    {
        public IntPtr value;
        private uint refCount;

        public EntityStorage(IntPtr value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IntStorage
    {
        public long value;
        private uint refCount;

        public IntStorage(long value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UIntStorage
    {
        public ulong value;
        private uint refCount;

        public UIntStorage(ulong value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DoubleStorage
    {
        public double value;
        private uint refCount;

        public DoubleStorage(double value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StringStorage
    {
        public StringView value;
        public uint refCount;

        public StringStorage(StringView value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FunctionStorage
    {
        public MValue.Function value;
        private uint refCount;

        public FunctionStorage(MValue.Function value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MValueArrayStorage
    {
        public MValueArray value;
        internal uint refCount;

        public MValueArrayStorage(MValueArray value)
        {
            refCount = 1;
            this.value = value;
        }
    }
}