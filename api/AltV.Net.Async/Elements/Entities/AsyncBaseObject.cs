using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncBaseObject : IBaseObject, IInternalBaseObject
    {
        public IntPtr NativePointer => BaseObject.NativePointer;
        public IntPtr BaseObjectNativePointer => BaseObject.BaseObjectNativePointer;

        public ICore Core => BaseObject.Core;
        public bool Cached => BaseObject.Cached;
        ISharedCore ISharedBaseObject.Core => BaseObject.Core;

        public bool Exists
        {
            get
            {
                lock (BaseObject)
                {
                    return BaseObject.Exists;
                }
            }

            set
            {
                lock (BaseObject)
                {
                    if (BaseObject is IInternalBaseObject internalBaseObject)
                        internalBaseObject.Exists = value;
                }
            }
        }

        public BaseObjectType Type => BaseObject.Type;

        protected readonly IBaseObject BaseObject;

        protected readonly IAsyncContext AsyncContext;

        public AsyncBaseObject(IBaseObject baseObject, IAsyncContext asyncContext)
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
            AsyncContext?.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetMetaData(key, out result);
            }
        }

        public bool GetMetaData(string key, out int result)
        {
            AsyncContext?.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetMetaData(key, out result);
            }
        }

        public bool GetMetaData(string key, out uint result)
        {
            AsyncContext?.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetMetaData(key, out result);
            }
        }

        public bool GetMetaData(string key, out float result)
        {
            AsyncContext?.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(BaseObject))
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
                if (!AsyncContext.CheckIfExistsOrCachedNullable(BaseObject))
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

        public void SetCached(IntPtr pointer)
        {
            (BaseObject as IInternalBaseObject)!.SetCached(pointer);
        }

        public bool HasMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(BaseObject)) return default;
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
        public void CheckIfEntityExistsOrCached()
        {
            BaseObject.CheckIfEntityExistsOrCached();
        }

        public void OnDestroy()
        {
            BaseObject.OnDestroy();
        }

        public void Destroy()
        {
            AsyncContext.RunOnMainThreadBlockingNullable(() => BaseObject.Destroy());
        }
    }
}