using System;
using AltV.Net.CApi;
using AltV.Net.Native;

namespace AltV.Net
{
    public interface INativeResourcePool
    {
        bool GetOrCreate(ICore core, IntPtr resourcePointer, out INativeResource resource);
    }
}