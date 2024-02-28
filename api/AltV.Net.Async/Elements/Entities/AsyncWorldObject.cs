using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use player in lock and sometimes not
    public class AsyncWorldObject : AsyncBaseObject, IWorldObject
    {
        protected readonly IWorldObject WorldObject;
        public IntPtr WorldObjectNativePointer => WorldObject.WorldObjectNativePointer;
        public Position Position
        {
            get
            {
                lock (WorldObject)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(WorldObject)) return default;
                    return WorldObject.Position;
                }
            }
            set {
                lock (WorldObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(WorldObject)) return;
                    WorldObject.Position = value;
                }
            }
        }

        public int Dimension
        {
            get
            {
                lock (WorldObject)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(WorldObject)) return default;
                    return WorldObject.Dimension;
                }
            }
            set {
                lock (WorldObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(WorldObject)) return;
                    WorldObject.Dimension = value;
                }
            }
        }

        public AsyncWorldObject(IWorldObject worldObject, IAsyncContext asyncContext) : base(worldObject, asyncContext)
        {
            WorldObject = worldObject;
        }

        public void SetPosition((float X, float Y, float Z) position)
        {
            lock (WorldObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(WorldObject)) return;
                WorldObject.SetPosition(position);
            }
        }

        public void SetPosition(float x, float y, float z)
        {
            lock (WorldObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(WorldObject)) return;
                WorldObject.SetPosition(x, y, z);
            }
        }

        public (float X, float Y, float Z) GetPosition()
        {
            lock (WorldObject)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(WorldObject)) return default;
                return WorldObject.GetPosition();
            }
        }
    }
}