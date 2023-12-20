using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioOutputFrontend : AudioOutput, IAudioOutputFrontend
{
    public static IntPtr GetAudioNativePointer(ICore core, IntPtr audioOutputFrontendNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioFrontendOutput_GetAudioOutputObject(audioOutputFrontendNativePointer);
        }
    }
    public AudioOutputFrontend(ICore core, IntPtr audioOutputFrontendNativePointer, uint id) : base(core,
        GetAudioNativePointer(core, audioOutputFrontendNativePointer), BaseObjectType.AudioOutputFrontend, id)
    {
        AudioOutputFrontendNativePointer = audioOutputFrontendNativePointer;
    }

    public IntPtr AudioOutputFrontendNativePointer { get; }
    public override IntPtr NativePointer => AudioOutputFrontendNativePointer;
}