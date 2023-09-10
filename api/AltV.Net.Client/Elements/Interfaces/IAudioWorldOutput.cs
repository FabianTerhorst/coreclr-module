using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces;

public interface IAudioWorldOutput : IAudioOutput
{
    IntPtr AudioWorldOutputNativePointer { get; }

    Position Position { get; set; }
}