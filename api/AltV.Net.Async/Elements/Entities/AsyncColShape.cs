using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncColShape<TColShape> : AsyncWorldObject<TColShape>, IColShape where TColShape: class, IColShape
    {
        public ColShapeType ColShapeType
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    return BaseObject.ColShapeType;
                }
            }
        }

        public bool IsPlayersOnly
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    return BaseObject.IsPlayersOnly;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.IsPlayersOnly = value);
            }
        }

        public AsyncColShape(TColShape colShape, IAsyncContext asyncContext):base(colShape, asyncContext)
        {
        }
        
        public bool IsEntityIn(IEntity entity)
        {
            lock (BaseObject)
            {
                return BaseObject.IsEntityIn(entity);
            }
        }

        public bool IsPlayerIn(IPlayer entity)
        {
            lock (BaseObject)
            {
                return BaseObject.IsPlayerIn(entity);
            }
        }

        public bool IsVehicleIn(IVehicle entity)
        {
            lock (BaseObject)
            {
                return BaseObject.IsVehicleIn(entity);
            }
        }

        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlocking(() => BaseObject.Remove());
        }
    }
}