using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioOutput : BaseObject, IAudioOutput
{
    public static IntPtr GetBaseObjectNativePointer(ICore core, IntPtr audioFilterNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioOutput_GetBaseObject(audioFilterNativePointer);
        }
    }

    public AudioOutput(ICore core, IntPtr audioOutputNativePointer, uint id) : base(core, GetBaseObjectNativePointer(core, audioOutputNativePointer), BaseObjectType.AudioOutput, id)
    {
        AudioOutputNativePointer = audioOutputNativePointer;
    }

    public AudioOutput(ICore core, IntPtr audioOutputNativePointer, BaseObjectType type, uint id) : base(core, GetBaseObjectNativePointer(core, audioOutputNativePointer), type, id)
    {
        AudioOutputNativePointer = audioOutputNativePointer;
    }

    public IntPtr AudioOutputNativePointer { get; }

    public float Volume
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.AudioOutput_GetVolume(AudioOutputNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.AudioOutput_SetVolume(AudioOutputNativePointer, value);
            }
        }
    }

    public bool IsMuted
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.AudioOutput_IsMuted(AudioOutputNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.AudioOutput_SetMuted(AudioOutputNativePointer, value ? (byte)1 : (byte)0);
            }
        }
    }

    public uint Category
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.AudioOutput_GetCategory(AudioOutputNativePointer);
            }
        }
    }

    public IAudio Owner
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var entityPointer = Core.Library.Client.AudioOutput_GetOwner(AudioOutputNativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Core.PoolManager.Audio.Get(entityPointer);
            }
        }
    }

    public void AddFilter(IAudioFilter filter)
    {
        unsafe
        {
            CheckIfEntityExists();
            Core.Library.Client.AudioOutput_AddFilter(AudioOutputNativePointer, filter.AudioFilterNativePointer);
        }
    }

    public void RemoveFilter()
    {
        unsafe
        {
            CheckIfEntityExists();
            Core.Library.Client.AudioOutput_RemoveFilter(AudioOutputNativePointer);
        }
    }

    public IAudioFilter Filter
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                var entityPointer = Core.Library.Client.AudioOutput_GetFilter(AudioOutputNativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Core.PoolManager.AudioFilter.Get(entityPointer);
            }
        }
    }
}