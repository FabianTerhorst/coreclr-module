using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioOutputWorld : AudioOutput, IAudioOutputWorld
{
    public static IntPtr GetAudioNativePointer(ICore core, IntPtr audioOutputWorldNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioWorldOutput_GetAudioOutputObject(audioOutputWorldNativePointer);
        }
    }
    public AudioOutputWorld(ICore core, IntPtr audioOutputWorldNativePointer, uint id) : base(core,
        GetAudioNativePointer(core, audioOutputWorldNativePointer), BaseObjectType.AudioOutputWorld, id)
    {
        AudioOutputWorldNativePointer = audioOutputWorldNativePointer;
    }

    public IntPtr AudioOutputWorldNativePointer { get; }

    public Position Position
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.AudioWorldOutput_GetPosition(AudioOutputWorldNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.AudioWorldOutput_SetPosition(AudioOutputWorldNativePointer, value);
            }
        }
    }

    public override IntPtr NativePointer => AudioOutputWorldNativePointer;
}