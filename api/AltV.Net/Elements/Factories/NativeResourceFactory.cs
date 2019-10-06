using System;

namespace AltV.Net.Elements.Factories
{
    public class NativeResourceFactory : INativeResourceFactory
    {
        public INativeResource Create(IntPtr resourcePointer)
        {
            return new NativeResource(resourcePointer);
        }
    }
}