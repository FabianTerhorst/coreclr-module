using System;
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

        public NativeLocalStorage(JSObject localStorage)
        {
            this.localStorage = localStorage;
            get = (Function) localStorage.GetObjectProperty("get");
        }

        public JSObject Get()
        {
            return (JSObject) get.Call(localStorage);
        }

        public void Delete(JSObject instance, string key)
        {
            instance.Invoke("delete", key);
        }

        public void DeleteAll(JSObject instance)
        {
            instance.Invoke("deleteAll",instance);
        }

        public object Get(JSObject instance, string key)
        {
            return instance.Invoke("get", key);
        }

        public void Save(JSObject instance)
        {
            instance.Invoke("save");
        }

        public void Set(JSObject instance, string key, object value)
        {
            instance.Invoke("set", key, value);
        }
    }
}