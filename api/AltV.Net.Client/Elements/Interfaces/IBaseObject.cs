namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IBaseObject
    {
        public IntPtr BaseObjectNativePointer { get; }
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