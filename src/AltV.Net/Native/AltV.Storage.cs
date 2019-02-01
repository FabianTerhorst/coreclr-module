using System;
using System.Runtime.InteropServices;

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

        private uint refCount;
        public bool value;

        public BoolStorage(bool value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EntityStorage
    {
        private uint refCount;
        public IntPtr value;

        public EntityStorage(IntPtr value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IntStorage
    {
        private uint refCount;
        public long value;

        public IntStorage(long value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UIntStorage
    {
        private uint refCount;
        public ulong value;

        public UIntStorage(ulong value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DoubleStorage
    {
        private uint refCount;
        public double value;

        public DoubleStorage(double value)
        {
            refCount = 1;
            this.value = value;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StringStorage
    {
        private uint refCount;
        public IntPtr value;

        public StringStorage(IntPtr value)
        {
            refCount = 1;
            this.value = value;
        }

        public StringStorage(string value) : this(Marshal.StringToHGlobalAnsi(value))
        {
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FunctionStorage
    {
        private uint refCount;
        public MValue.Function value;

        public FunctionStorage(MValue.Function value)
        {
            refCount = 1;
            this.value = value;
        }
    }
}