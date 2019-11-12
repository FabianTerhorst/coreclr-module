using System;

namespace AltV.Net
{
    public interface INativeResourcePool
    {
        bool GetOrCreate(IntPtr corePointer, IntPtr resourcePointer, out INativeResource resource);
    }
}