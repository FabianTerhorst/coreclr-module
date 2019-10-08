using System;
using System.Collections.Generic;

namespace AltV.Net.Elements.Pools
{
    public class NativeResourcePool : INativeResourcePool
    {
        private readonly Dictionary<IntPtr, INativeResource> resources = new Dictionary<IntPtr, INativeResource>();

        private readonly INativeResourceFactory resourceFactory;

        public NativeResourcePool(INativeResourceFactory resourceFactory)
        {
            this.resourceFactory = resourceFactory;
        }

        public bool GetOrCreate(IntPtr resourcePointer, out INativeResource resource)
        {
            if (resourcePointer == IntPtr.Zero)
            {
                resource = default;
                return false;
            }

            if (resources.TryGetValue(resourcePointer, out resource)) return true;

            resource = resourceFactory.Create(resourcePointer);
            resources[resourcePointer] = resource;

            return true;
        }
    }
}