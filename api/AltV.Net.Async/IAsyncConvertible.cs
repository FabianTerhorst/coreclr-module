using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public interface IAsyncConvertible<TBaseObject>: IBaseObject where TBaseObject: class, IBaseObject
    {
        [Obsolete("Use new async API instead")]
        TBaseObject ToAsync(IAsyncContext asyncContext);

        [Obsolete("Use new async API instead")]
        bool TryToAsync(IAsyncContext asyncContext, out TBaseObject player)
        {
            player = ToAsync(asyncContext);
            return true;
        }

        [Obsolete("Use new async API instead")]
        TBaseObject ToAsync()
        {
            return ToAsync(null);
        }
    }

    /*public interface IAsyncConvertible<out TAsyncBaseObject, TBaseObject> : IBaseObject
        where TBaseObject : class, IBaseObject where TAsyncBaseObject : AsyncBaseObject<TBaseObject>
    {
        public TAsyncBaseObject ToAsync(IAsyncContext asyncContext);
    }*/
}