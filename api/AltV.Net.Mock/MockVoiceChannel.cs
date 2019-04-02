using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVoiceChannel : IVoiceChannel
    {
        public MockVoiceChannel(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }

        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public BaseObjectType Type { get; }

        public void SetMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void RemovePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void MutePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void UnmutePlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool IsPlayerConnected(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool IsPlayerMuted(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool IsSpatial { set; get; }
        public float MaxDistance { set; get; }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void CheckIfEntityExists()
        {
        }
    }
}