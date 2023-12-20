using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioOutputAttached : AudioOutput, IAudioOutputAttached
{
    public static IntPtr GetAudioNativePointer(ICore core, IntPtr audioOutputAttachedNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioAttachedOutput_GetAudioOutputObject(audioOutputAttachedNativePointer);
        }
    }
    public AudioOutputAttached(ICore core, IntPtr audioOutputAttachedNativePointer, uint id) : base(core,
        GetAudioNativePointer(core, audioOutputAttachedNativePointer), BaseObjectType.AudioOutputAttached, id)
    {
        AudioOutputAttachedNativePointer = audioOutputAttachedNativePointer;
    }

    public IntPtr AudioOutputAttachedNativePointer { get; }

    public IWorldObject Entity
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                BaseObjectType type = BaseObjectType.Audio;
                var entityPointer = Core.Library.Client.AudioAttachedOutput_GetEntity(AudioOutputAttachedNativePointer, &type);
                if (entityPointer == IntPtr.Zero) return null;
                return (IWorldObject)Core.PoolManager.Get(entityPointer, type);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.AudioAttachedOutput_SetEntity(AudioOutputAttachedNativePointer, value.WorldObjectNativePointer);
            }
        }
    }
}