using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use player in lock and sometimes not
    public class AsyncWorldObject<TWorld> : AsyncBaseObject<TWorld>, IWorldObject where TWorld: class, IWorldObject
    {
        public Position Position
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Position;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Position = value);
            }
        }
        public int Dimension
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Dimension;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Dimension = value);
            }
        }
        
        public AsyncWorldObject(TWorld worldObject, IAsyncContext asyncContext):base(worldObject, asyncContext)
        {
        }
    }
}