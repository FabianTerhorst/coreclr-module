using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncColShape : AsyncWorldObject, IColShape, IAsyncConvertible<IColShape>
    {
        protected readonly IColShape ColShape;
        public IntPtr ColShapeNativePointer => ColShape.ColShapeNativePointer;

        public ColShapeType ColShapeType
        {
            get
            {
                lock (ColShape)
                {
                    if (!AsyncContext.CheckIfExistsNullable(ColShape)) return default;
                    return ColShape.ColShapeType;
                }
            }
        }

        public bool IsPlayersOnly
        {
            get
            {
                lock (ColShape)
                {
                    if (!AsyncContext.CheckIfExistsNullable(ColShape)) return default;
                    return ColShape.IsPlayersOnly;
                }
            }
            set {
                lock (ColShape)
                {
                    if (!AsyncContext.CheckIfExistsNullable(ColShape)) return;
                    ColShape.IsPlayersOnly = value;
                }
            }
        }

        public AsyncColShape(IColShape colShape, IAsyncContext asyncContext) : base(colShape, asyncContext)
        {
            ColShape = colShape;
        }

        public AsyncColShape(ICore core, IntPtr nativePointer, uint id) : this(new ColShape(core, nativePointer, id), null)
        {
        }

        public bool IsEntityIdIn(ushort id)
        {
            lock (ColShape)
            {
                if (!AsyncContext.CheckIfExistsNullable(ColShape)) return default;
                return ColShape.IsEntityIdIn(id);
            }
        }

        public bool IsPointIn(Vector3 point)
        {
            lock (ColShape)
            {
                if (!AsyncContext.CheckIfExistsNullable(ColShape)) return default;
                return ColShape.IsPointIn(point);
            }
        }

        public bool IsEntityIn(ISharedEntity entity)
        {
            lock (ColShape)
            {
                if (!AsyncContext.CheckIfExistsNullable(ColShape)) return default;
                return ColShape.IsEntityIn(entity);
            }
        }

        public bool IsEntityIn(IEntity entity)
        {
            return IsEntityIn((ISharedEntity) entity);
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsPlayerIn(IPlayer entity)
        {
            lock (ColShape)
            {
                if (!AsyncContext.CheckIfExistsNullable(ColShape)) return default;
                return ColShape.IsPlayerIn(entity);
            }
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsVehicleIn(IVehicle entity)
        {
            lock (ColShape)
            {
                if (!AsyncContext.CheckIfExistsNullable(ColShape)) return default;
                return ColShape.IsVehicleIn(entity);
            }
        }
        [Obsolete("Use new async API instead")]
        public IColShape ToAsync(IAsyncContext asyncContext)
        {
            return this;
        }
    }
}