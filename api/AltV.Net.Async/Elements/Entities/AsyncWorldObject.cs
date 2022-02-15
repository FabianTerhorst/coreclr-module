using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use player in lock and sometimes not
    public class AsyncWorldObject<TWorld> : AsyncBaseObject<TWorld>, IWorldObject where TWorld : class, IWorldObject
    {
        public Position Position
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Position;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Position = value;
                }
            }
        }

        public int Dimension
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Dimension;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Dimension = value;
                }
            }
        }

        public AsyncWorldObject(TWorld worldObject, IAsyncContext asyncContext) : base(worldObject, asyncContext)
        {
        }
    }
}