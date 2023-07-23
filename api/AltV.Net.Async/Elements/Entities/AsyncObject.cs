using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Object = AltV.Net.Elements.Entities.Object;

namespace AltV.Net.Async.Elements.Entities;

public class AsyncObject : AsyncEntity, IObject, IAsyncConvertible<IObject>
{
    protected readonly IObject Object;
    public IntPtr ObjectNativePointer => Object.ObjectNativePointer;

    public AsyncObject(IObject @object, IAsyncContext asyncContext) : base(@object, asyncContext)
    {
        Object = @object;
    }

    public AsyncObject(ICore core, IntPtr nativePointer, uint id) : this(new Object(core, nativePointer, id),
        null)
    {
    }

    public byte Alpha
    {
        get
        {
            lock (Object)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Object)) return default;
                return Object.Alpha;
            }
        }
        set
        {
            lock (Object)
            {
                if (!AsyncContext.CheckIfExistsNullable(Object)) return;
                Object.Alpha = value;
            }
        }
    }

    public ushort LodDistance
    {
        get
        {
            lock (Object)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Object)) return default;
                return Object.LodDistance;
            }
        }
        set
        {
            lock (Object)
            {
                if (!AsyncContext.CheckIfExistsNullable(Object)) return;
                Object.LodDistance = value;
            }
        }
    }

    public void PlaceOnGroundProperly()
    {
        lock (Object)
        {
            if (!AsyncContext.CheckIfExistsNullable(Object)) return;
            Object.PlaceOnGroundProperly();
        }
    }

    public void ActivatePhysics()
    {
        lock (Object)
        {
            if (!AsyncContext.CheckIfExistsNullable(Object)) return;
            Object.ActivatePhysics();
        }
    }

    public byte TextureVariation
    {
        get
        {
            lock (Object)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Object)) return default;
                return Object.TextureVariation;
            }
        }
        set
        {
            lock (Object)
            {
                if (!AsyncContext.CheckIfExistsNullable(Object)) return;
                Object.TextureVariation = value;
            }
        }
    }

    [Obsolete("Use new async API instead")]
    public IObject ToAsync(IAsyncContext asyncContext)
    {
        return this;
    }
}