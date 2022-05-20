using System;
using AltV.Net.CApi;
using AltV.Net.Native;

namespace AltV.Net
{
    public interface INativeResourceFactory
    {
        INativeResource Create(ICore core, IntPtr resourcePointer);
    }
}