using System;
using AltV.Net.CApi;
using AltV.Net.Native;

namespace AltV.Net.Elements.Factories
{
    public class NativeResourceFactory : INativeResourceFactory
    {
        public INativeResource Create(ILibrary library, IntPtr corePointer, IntPtr resourcePointer)
        {
            return new NativeResource(library, corePointer, resourcePointer);
        }
    }
}