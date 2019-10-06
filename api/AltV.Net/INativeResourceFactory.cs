using System;

namespace AltV.Net
{
    public interface INativeResourceFactory
    {
        INativeResource Create(IntPtr resourcePointer);
    }
}