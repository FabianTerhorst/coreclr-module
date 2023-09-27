using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces;

public interface IAudioOutputAttached : IAudioOutput
{
    IntPtr AudioOutputAttachedNativePointer { get; }

    IWorldObject Entity { get; set; }
}