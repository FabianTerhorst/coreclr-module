using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncBaseObject<TBase> : IBaseObject where TBase : class, IBaseObject
    {
        public IntPtr NativePointer => BaseObject.NativePointer;

        public bool Exists
        {
            get
            {
                lock (BaseObject)
                {
                    return BaseObject.Exists;
                }
            }
        }

        public BaseObjectType Type => BaseObject.Type;

        protected readonly TBase BaseObject;

        protected readonly IAsyncContext AsyncContext;

        public AsyncBaseObject(TBase baseObject, IAsyncContext asyncContext)
        {
            this.BaseObject = baseObject;
            this.AsyncContext = asyncContext;
        }

        public void SetMetaData(string key, object value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                this.BaseObject.SetMetaData(key, value);
            }
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetMetaData(key, out result);
            }
        }

        public void SetMetaData(string key, in MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                
                var @const = value;
                BaseObject.SetMetaData(key, in @const);
            }
        }

        public void GetMetaData(string key, out MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = MValueConst.Nil;
                    return;
                }

                BaseObject.GetMetaData(key, out value);
            }
        }

        public void SetData(string key, object value)
        {
            BaseObject.SetData(key, value);
        }

        public bool GetData<T>(string key, out T result)
        {
            return BaseObject.GetData(key, out result);
        }

        public bool HasData(string key)
        {
            return BaseObject.HasData(key);
        }

        public IEnumerable<string> GetAllDataKeys()
        {
            return BaseObject.GetAllDataKeys();
        }

        public void DeleteData(string key)
        {
            BaseObject.DeleteData(key);
        }

        public void ClearData()
        {
            BaseObject.ClearData();
        }

        public bool HasMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.HasMetaData(key);
            }
        }

        public void DeleteMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.DeleteMetaData(key);
            }
        }

        public void CheckIfEntityExists()
        {
            BaseObject.CheckIfEntityExists();
        }

        public void OnRemove()
        {
            BaseObject.OnRemove();
        }

        public bool AddRef()
        {
            return BaseObject.AddRef();
        }

        public bool RemoveRef()
        {
            return BaseObject.RemoveRef();
        }
    }
}