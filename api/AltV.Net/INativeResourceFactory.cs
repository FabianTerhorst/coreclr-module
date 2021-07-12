using System;
using AltV.Net.Native;

namespace AltV.Net
{
    public interface INativeResourceFactory
    {
        INativeResource Create(ILibrary library, IntPtr corePointer, IntPtr resourcePointer);
    }
}