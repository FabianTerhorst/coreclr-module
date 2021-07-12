using System;
using AltV.Net.Native;

namespace AltV.Net
{
    public interface INativeResourcePool
    {
        bool GetOrCreate(ILibrary library, IntPtr corePointer, IntPtr resourcePointer, out INativeResource resource);
    }
}