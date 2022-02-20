using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncCheckpoint<TCheckpoint> : AsyncColShape<TCheckpoint>, ICheckpoint where TCheckpoint: class, ICheckpoint
    {
        public byte CheckpointType
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.CheckpointType;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.CheckpointType = value;
                }
            }
        }

        public float Height
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Height;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Height = value;
                }
            }
        }

        public float Radius
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Radius;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Radius = value;
                }
            }
        }

        public Rgba Color
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Color;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Color = value;
                }
            }
        }

        public Position NextPosition
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.NextPosition;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.NextPosition = value;
                }
            }
        }

        public AsyncCheckpoint(TCheckpoint checkpoint, IAsyncContext asyncContext) : base(checkpoint, asyncContext)
        {
        }
    }
}