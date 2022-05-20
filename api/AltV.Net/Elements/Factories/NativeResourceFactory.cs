using System;
using AltV.Net.CApi;
using AltV.Net.Native;

namespace AltV.Net.Elements.Factories
{
    public class NativeResourceFactory : INativeResourceFactory
    {
        public INativeResource Create(ICore core, IntPtr resourcePointer)
        {
            return new NativeResource(core, resourcePointer);
        }
    }
}