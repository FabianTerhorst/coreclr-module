namespace AltV.Net.Client.Elements.Interfaces;

public interface IAudioOutputFrontend : IAudioOutput
{
    IntPtr AudioOutputFrontendNativePointer { get; }
}