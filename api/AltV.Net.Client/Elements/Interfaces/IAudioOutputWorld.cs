using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces;

public interface IAudioOutputWorld : IAudioOutput
{
    IntPtr AudioOutputWorldNativePointer { get; }

    Position Position { get; set; }
}