using System;

namespace AltV.Net
{
    public interface INativeResourcePool
    {
        bool GetOrCreate(IntPtr resourcePointer, out INativeResource resource);
    }
}