using AltV.Net.Client.Elements.Enums;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IBaseObject
    {
        public IntPtr BaseObjectNativePointer { get; }
        BaseObjectType Type { get; }

        public void SetData<T>(string key, T value);
        public bool HasData(string key);
        public void DeleteData(string key);
        public bool GetData<T>(string key, out T? value);
        
        public void SetMetaData<T>(string key, T value);
        public bool HasMetaData(string key);
        public void DeleteMetaData(string key);
        public bool GetMetaData(string key, out int value);
        public bool GetMetaData(string key, out uint value);
        public bool GetMetaData(string key, out float value);
        public bool GetMetaData<T>(string key, out T? value);
        
        // todo
    }
}