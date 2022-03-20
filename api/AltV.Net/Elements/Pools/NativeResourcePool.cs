using System;
using System.Collections.Generic;
using AltV.Net.CApi;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class NativeResourcePool : INativeResourcePool
    {
        private readonly Dictionary<IntPtr, INativeResource> resources = new ();

        private readonly INativeResourceFactory resourceFactory;

        public NativeResourcePool(INativeResourceFactory resourceFactory)
        {
            this.resourceFactory = resourceFactory;
        }

        public bool GetOrCreate(ICore core, IntPtr resourcePointer, out INativeResource resource)
        {
            if (resourcePointer == IntPtr.Zero)
            {
                resource = default;
                return false;
            }

            if (resources.TryGetValue(resourcePointer, out resource)) return true;

            resource = resourceFactory.Create(core, resourcePointer);
            resources[resourcePointer] = resource;

            return true;
        }
    }
}