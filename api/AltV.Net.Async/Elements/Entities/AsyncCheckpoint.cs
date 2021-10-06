using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncCheckpoint : AsyncColShape<ICheckpoint>, ICheckpoint
    {
        public byte CheckpointType
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.CheckpointType;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.CheckpointType = value);
            }
        }

        public float Height
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Height;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Height = value);
            }
        }

        public float Radius
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Radius;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Radius = value);
            }
        }

        public Rgba Color
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Color;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Color = value);
            }
        }

        public Position NextPosition
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.NextPosition;
                }
            }
            set
            {
                AsyncContext.Enqueue(() => BaseObject.NextPosition = value);
            }
        }

        public AsyncCheckpoint(ICheckpoint checkpoint, IAsyncContext asyncContext):base(checkpoint, asyncContext)
        {
        }
    }
}