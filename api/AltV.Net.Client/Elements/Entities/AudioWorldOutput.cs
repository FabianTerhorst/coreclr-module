using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioWorldOutput : AudioOutput, IAudioWorldOutput
{
    public static IntPtr GetAudioNativePointer(ICore core, IntPtr audioWorldOutputNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioWorldOutput_GetAudioOutputObject(audioWorldOutputNativePointer);
        }
    }
    public AudioWorldOutput(ICore core, IntPtr audioWorldOutputNativePointer, uint id) : base(core,
        GetAudioNativePointer(core, audioWorldOutputNativePointer), BaseObjectType.AudioOutputWorld, id)
    {
        AudioWorldOutputNativePointer = audioWorldOutputNativePointer;
    }

    public IntPtr AudioWorldOutputNativePointer { get; }

    public Position Position
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.AudioWorldOutput_GetPosition(AudioWorldOutputNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.AudioWorldOutput_SetPosition(AudioWorldOutputNativePointer, value);
            }
        }
    }

    public override IntPtr NativePointer => AudioWorldOutputNativePointer;
}