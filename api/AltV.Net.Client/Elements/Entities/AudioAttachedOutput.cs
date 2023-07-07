using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioAttachedOutput : AudioOutput, IAudioAttachedOutput
{
    public static IntPtr GetAudioNativePointer(ICore core, IntPtr audioAttachedOutputNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioFrontendOutput_GetAudioOutputObject(audioAttachedOutputNativePointer);
        }
    }
    public AudioAttachedOutput(ICore core, IntPtr audioAttachedOutputNativePointer, uint id) : base(core,
        GetAudioNativePointer(core, audioAttachedOutputNativePointer), BaseObjectType.AudioOutputAttached, id)
    {
        AudioAttachedOutputNativePointer = audioAttachedOutputNativePointer;
    }

    public IntPtr AudioAttachedOutputNativePointer { get; }

    public IWorldObject Entity
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                BaseObjectType type = BaseObjectType.Audio;
                var entityPointer = Core.Library.Client.AudioAttachedOutput_GetEntity(AudioAttachedOutputNativePointer, &type);
                if (entityPointer == IntPtr.Zero) return null;
                return (IWorldObject)Core.PoolManager.Get(entityPointer, type);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.AudioAttachedOutput_SetEntity(AudioAttachedOutputNativePointer, value.WorldObjectNativePointer);
            }
        }
    }

    public override IntPtr NativePointer => AudioAttachedOutputNativePointer;
}