using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class LocalStorage : ILocalStorage
    {
        public static ILocalStorage Get()
        {
            return new LocalStorage(Alt.LocalStorage.Get());
        }
        
        private readonly JSObject jsObject;

        private LocalStorage(JSObject jsObject)
        {
            this.jsObject = jsObject;
        }

        public void Delete(string key)
        {
            Alt.LocalStorage.Delete(jsObject, key);
        }

        public void DeleteAll(string key)
        {
            Alt.LocalStorage.DeleteAll(jsObject);
        }

        public object Get(string key)
        {
            return Alt.LocalStorage.Get(jsObject, key);
        }

        public void Save()
        {
            Alt.LocalStorage.Save(jsObject);
        }

        public void Set(string key, object value)
        {
            Alt.LocalStorage.Set(jsObject, key, value);
        }
    }
}