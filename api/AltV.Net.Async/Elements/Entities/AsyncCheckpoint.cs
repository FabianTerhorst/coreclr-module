using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
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

        public void SetStreamSyncedMetaData(string key, object value)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                Checkpoint.SetStreamSyncedMetaData(key, value);
            }
        }

        public void SetStreamSyncedMetaData(Dictionary<string, object> metaData)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                Checkpoint.SetStreamSyncedMetaData(metaData);
            }
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                Checkpoint.SetStreamSyncedMetaData(key, value);
            }
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return;
                Checkpoint.DeleteStreamSyncedMetaData(key);
            }
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsNullable(Checkpoint)) return default;
                return Checkpoint.HasStreamSyncedMetaData(key);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Checkpoint))
                {
                    value = default;
                    return false;
                }

                return Checkpoint.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Checkpoint))
                {
                    value = default;
                    return false;
                }

                return Checkpoint.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Checkpoint))
                {
                    value = default;
                    return false;
                }

                return Checkpoint.GetStreamSyncedMetaData(key, out value);
            }
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Checkpoint))
                {
                    value = default;
                    return;
                }

                Checkpoint.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData<T>(string key, out T value)
        {
            lock (Checkpoint)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Checkpoint))
                {
                    value = default;
                    return false;
                }

                return Checkpoint.GetStreamSyncedMetaData(key, out value);
            }
        }
    }
}