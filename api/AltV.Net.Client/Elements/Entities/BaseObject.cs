using System.Collections.Generic;
using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class BaseObject : IBaseObject
    {
        protected readonly JSObject jsObject;
        
        private readonly IDictionary<string, object> data = new Dictionary<string, object>();

        public int Type => (int) jsObject.GetObjectProperty("type");
        public bool Exists => (bool) jsObject.GetObjectProperty("valid");
        
        public BaseObject(JSObject jsObject)
        {
            this.jsObject = jsObject;
        }
        
        // Overwritten in WebView
        public virtual void Remove()
        {
            jsObject.Invoke("remove");
        }

        public void SetData(string key, object value)
        {
            data[key] = value;
        }

        public bool TryGetData<T>(string key, out T value)
        {
            if (data.TryGetValue(key, out var dataValue))
            {
                if (dataValue is T dataTValue)
                {
                    value = dataTValue;
                    return true;
                }
            }

            value = default;
            return false;
        }
        
        public void SetMetaData(string key, object value)
        {
            jsObject.Invoke("setMeta", key, value);
        }
        
        public bool TryGetMetaData<T>(string key, out T value)
        {
            var dataValue = jsObject.Invoke("getMeta", key);
            if (dataValue is T dataTValue)
            {
                value = dataTValue;
                return true;
            }

            value = default;
            return false;
        }
    }
}