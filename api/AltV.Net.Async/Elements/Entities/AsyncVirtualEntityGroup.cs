using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities;

public class AsyncVirtualEntityGroup : AsyncBaseObject, IVirtualEntityGroup, IAsyncConvertible<IVirtualEntityGroup>
{
    protected readonly IVirtualEntityGroup VirtualEntityGroup;
    public IntPtr VirtualEntityGroupNativePointer => VirtualEntityGroup.VirtualEntityGroupNativePointer;
    public AsyncVirtualEntityGroup(IVirtualEntityGroup virtualEntityGroup, IAsyncContext asyncContext) : base(virtualEntityGroup, asyncContext)
    {
        VirtualEntityGroup = virtualEntityGroup;
    }

    public AsyncVirtualEntityGroup(ICore core, IntPtr nativePointer, uint id) : this(new VirtualEntityGroup(core, nativePointer, id), null)
    {
    }

    public AsyncVirtualEntityGroup(ICore core, uint streamingDistance) : this(new VirtualEntityGroup(core, streamingDistance), null)
    {
    }

    public uint Id => VirtualEntityGroup.Id;
    public uint StreamingRangeLimit
    {
        get
        {
            lock (VirtualEntityGroup)
            {
                if (!AsyncContext.CheckIfExistsNullable(VirtualEntityGroup)) return default;
                return VirtualEntityGroup.StreamingRangeLimit;
            }
        }
    }

    [Obsolete("Use new async API instead")]
    public IVirtualEntityGroup ToAsync(IAsyncContext asyncContext)
    {
        return this;
    }
}