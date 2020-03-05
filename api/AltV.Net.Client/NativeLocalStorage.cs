using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    internal class NativeLocalStorage
    {
        private readonly JSObject localStorage;

        private readonly Function get;

        private readonly Function localStorageDelete;

        private readonly Function localStorageDeleteAll;

        private readonly Function localStorageGet;

        private readonly Function localStorageSave;

        private readonly Function localStorageSet;

        public NativeLocalStorage(JSObject alt)
        {
            localStorage = (JSObject) alt.GetObjectProperty("LocalStorage");
            get = (Function) localStorage.GetObjectProperty("get");

            var prototype = (JSObject) localStorage.GetObjectProperty("prototype");
            localStorageDelete = (Function) prototype.GetObjectProperty("delete");
            localStorageDeleteAll = (Function) prototype.GetObjectProperty("deleteAll");
            localStorageGet = (Function) prototype.GetObjectProperty("get");
            localStorageSave = (Function) prototype.GetObjectProperty("save");
            localStorageSet = (Function) prototype.GetObjectProperty("set");
        }

        public JSObject Get()
        {
            return (JSObject) get.Call(localStorage);
        }

        public void Delete(JSObject instance, string key)
        {
            localStorageDelete.Call(instance, key);
        }

        public void DeleteAll(JSObject instance)
        {
            localStorageDeleteAll.Call(instance);
        }

        public object Get(JSObject instance, string key)
        {
            return localStorageGet.Call(instance, key);
        }

        public void Save(JSObject instance)
        {
            localStorageSave.Call(instance);
        }

        public void Set(JSObject instance, string key, object value)
        {
            localStorageSet.Call(instance, key, value);
        }
    }
}