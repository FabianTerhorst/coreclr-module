using System;

namespace AltV.Net.Types;

public interface INative
{
    /// <summary>
    /// Get the internal entity pointer.
    ///
    /// WARNING: Do NOT use this.
    /// </summary>
    IntPtr NativePointer { get; }

    /// <summary>
    /// Get current entity existence
    ///
    /// WARNING: Do NOT use this.
    /// </summary>
    bool Exists { get; }
}