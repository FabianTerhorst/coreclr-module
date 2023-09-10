namespace AltV.Net.Client.Elements.Interfaces;

public interface IAudioFrontendOutput : IAudioOutput
{
    IntPtr AudioFrontendOutputNativePointer { get; }
}