using System;

namespace AltV.Net.Elements.Factories
{
    public class NativeResourceFactory : INativeResourceFactory
    {
        public INativeResource Create(IntPtr corePointer, IntPtr resourcePointer)
        {
            return new NativeResource(corePointer, resourcePointer);
        }
    }
}