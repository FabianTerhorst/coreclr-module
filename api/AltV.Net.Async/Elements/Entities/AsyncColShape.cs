using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncColShape<TColShape> : AsyncWorldObject<TColShape>, IColShape where TColShape : class, IColShape
    {
        public IntPtr ColShapeNativePointer => BaseObject.ColShapeNativePointer;
        
        public ColShapeType ColShapeType
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ColShapeType;
                }
            }
        }

        public bool IsPlayersOnly
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsPlayersOnly;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.IsPlayersOnly = value;
                }
            }
        }

        public AsyncColShape(TColShape colShape, IAsyncContext asyncContext) : base(colShape, asyncContext)
        {
        }

        public bool IsEntityIn(IEntity entity)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.IsEntityIn(entity);
            }
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsPlayerIn(IPlayer entity)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.IsPlayerIn(entity);
            }
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsVehicleIn(IVehicle entity)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.IsVehicleIn(entity);
            }
        }

        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlockingNullable(() => BaseObject.Remove());
        }
    }
}