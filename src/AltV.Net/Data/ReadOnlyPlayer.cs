using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ReadOnlyPlayer : IPlayer
    {
        public static ReadOnlyPlayer Empty;
        
        public ushort Id { get; }
        public EntityType Type { get; }
        private readonly Position position;
        private readonly Rotation rotation;
        private readonly ushort dimension;

        public IntPtr NativePointer => IntPtr.Zero;
        public bool Exists => false;

        public Position Position
        {
            get => position;
            set { }
        }

        public Rotation Rotation
        {
            get => rotation;
            set { }
        }

        public ushort Dimension
        {
            get => dimension;
            set { }
        }

        public void SetPosition(float x, float y, float z) => throw new NotImplementedException();

        public void SetRotation(float roll, float pitch, float yaw) => throw new NotImplementedException();

        public void SetMetaData(string key, MValue value) => throw new NotImplementedException();

        public MValue GetMetaData(string key) => throw new NotImplementedException();

        public void SetData(string key, object value) => throw new NotImplementedException();

        public bool GetData<T>(string key, out T result) => throw new NotImplementedException();

        public bool Remove() => throw new NotImplementedException();

        public void Call(string eventName, params object[] args) => throw new NotImplementedException();

        public ReadOnlyPlayer Copy() => throw new NotImplementedException();
    }
}