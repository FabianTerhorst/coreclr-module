using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public interface IAsyncConvertible<TBaseObject>: IBaseObject where TBaseObject: class, IBaseObject
    {
        TBaseObject ToAsync(IAsyncContext asyncContext);

        bool TryToAsync(IAsyncContext asyncContext, out TBaseObject player)
        {
            if (!asyncContext.CreateRef(this, true))
            {
                player = default;
                return false;
            }

            player = ToAsync(asyncContext);
            return true;
        }

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