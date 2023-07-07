using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces;

public interface IAudioAttachedOutput : IAudioOutput
{
    IntPtr AudioAttachedOutputNativePointer { get; }

    IWorldObject Entity { get; set; }
}