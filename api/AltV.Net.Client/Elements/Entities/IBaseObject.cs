using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IBaseObject
    {
        JSObject NativeObject { get; }
        
        int Type { get; }
        
        bool Exists { get; }

        //TODO: not for players, and only client not for most entities
        void Remove();

        void SetData(string key, object value);

        bool TryGetData<T>(string key, out T value);
        
        void SetMetaData(string key, object value);

        bool TryGetMetaData<T>(string key, out T value);
    }
}