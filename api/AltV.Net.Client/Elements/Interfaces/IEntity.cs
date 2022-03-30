using System.Numerics;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IEntity : IWorldObject
    {
        public IntPtr EntityNativePointer { get; }
        public ushort Id { get; }
        public bool Exists { get; }
        public uint Model { get; }
        IPlayer? NetOwner { get; }
        int ScriptID { get; }
        bool Spawned { get; }
        Rotation Rotation { get; }

        public bool HasStreamSyncedMetaData(string key);
        public bool GetStreamSyncedMetaData(string key, out int value);
        public bool GetStreamSyncedMetaData(string key, out uint value);
        public bool GetStreamSyncedMetaData(string key, out float value);
        public bool GetStreamSyncedMetaData<T>(string key, out T? value);
        
        public bool HasSyncedMetaData(string key);
        public bool GetSyncedMetaData(string key, out int value);
        public bool GetSyncedMetaData(string key, out uint value);
        public bool GetSyncedMetaData(string key, out float value);
        public bool GetSyncedMetaData<T>(string key, out T? value);
    }
}