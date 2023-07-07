using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioFrontendOutput : AudioOutput, IAudioFrontendOutput
{
    public static IntPtr GetAudioNativePointer(ICore core, IntPtr audioFrontendOutputNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioFrontendOutput_GetAudioOutputObject(audioFrontendOutputNativePointer);
        }
    }
    public AudioFrontendOutput(ICore core, IntPtr audioFrontendOutputNativePointer, uint id) : base(core,
        GetAudioNativePointer(core, audioFrontendOutputNativePointer), BaseObjectType.AudioOutputFrontend, id)
    {
        AudioFrontendOutputNativePointer = audioFrontendOutputNativePointer;
    }

    public IntPtr AudioFrontendOutputNativePointer { get; }
    public override IntPtr NativePointer => AudioFrontendOutputNativePointer;
}