using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncCheckpoint : AsyncColShape, ICheckpoint, IAsyncConvertible<ICheckpoint>
    {
        protected readonly ICheckpoint Checkpoint;
        public IntPtr CheckpointNativePointer => Checkpoint.CheckpointNativePointer;

        public byte CheckpointType
        {
            get
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                    return Checkpoint.CheckpointType;
                }
            }
            set {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                    Checkpoint.CheckpointType = value;
                }
            }
        }

        public float Height
        {
            get
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                    return Checkpoint.Height;
                }
            }
            set {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                    Checkpoint.Height = value;
                }
            }
        }

        public float Radius
        {
            get
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                    return Checkpoint.Radius;
                }
            }
            set {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                    Checkpoint.Radius = value;
                }
            }
        }

        public Rgba Color
        {
            get
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                    return Checkpoint.Color;
                }
            }
            set {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                    Checkpoint.Color = value;
                }
            }
        }

        public Position NextPosition
        {
            get
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                    return Checkpoint.NextPosition;
                }
            }
            set
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                    Checkpoint.NextPosition = value;
                }
            }
        }

        public bool Visible
        {
            get
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                    return Checkpoint.Visible;
                }
            }
            set
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                    Checkpoint.Visible = value;
                }
            }
        }

        public uint StreamingDistance
        {
            get
            {
                lock (Checkpoint)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                    return Checkpoint.StreamingDistance;
                }
            }
        }

        public AsyncCheckpoint(ICheckpoint checkpoint, IAsyncContext asyncContext) : base(checkpoint, asyncContext)
        {
            Checkpoint = checkpoint;
        }

        public AsyncCheckpoint(ICore core, IntPtr nativePointer, uint id) : this(new Checkpoint(core, nativePointer, id), null)
        {
        }

        [Obsolete("Use new async API instead")]
        public ICheckpoint ToAsync(IAsyncContext asyncContext)
        {
            return this;
        }
    }
}