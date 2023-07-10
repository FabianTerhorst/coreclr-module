using System.Runtime.InteropServices;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Data;

public class AudioCategory : IAudioCategory
{
    private readonly ICore core;
    private readonly string name;

    internal AudioCategory(ICore core, string name)
    {
        this.core = core;
        this.name = name;
    }

    public float Volume
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetVolume(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetVolume(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float DistanceRolloffScale
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetDistanceRolloffScale(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetDistanceRolloffScale(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float PlateauRolloffScale
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetPlateauRolloffScale(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetPlateauRolloffScale(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float OcclusionDamping
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetOcclusionDamping(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetOcclusionDamping(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float EnvironmentalFilterDamping
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetEnvironmentalFilterDamping(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetEnvironmentalFilterDamping(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float SourceReverbDamping
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetSourceReverbDamping(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetSourceReverbDamping(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float DistanceReverbDamping
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetDistanceReverbDamping(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetDistanceReverbDamping(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float InteriorReverbDamping
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetInteriorReverbDamping(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetInteriorReverbDamping(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float EnvironmentalLoudness
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetEnvironmentalLoudness(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetEnvironmentalLoudness(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float UnderwaterWetLevel
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetUnderwaterWetLevel(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetUnderwaterWetLevel(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public float StonedWetLevel
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetStonedWetLevel(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetStonedWetLevel(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public short Pitch
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetPitch(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetPitch(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }

    public short LowPassFilterCutoff
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetLowPassFilterCutoff(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetLowPassFilterCutoff(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }
    
    public short HighPassFilterCutoff
    {
        get
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var result = core.Library.Client.AudioCategory_GetHighPassFilterCutoff(namePtr);
                Marshal.FreeHGlobal(namePtr);
                return result;
            }
        }
        set
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                core.Library.Client.AudioCategory_SetHighPassFilterCutoff(namePtr, value);
                Marshal.FreeHGlobal(namePtr);
            }
        }
    }
    public void Reset()
    {
        unsafe
        {
            var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
            core.Library.Client.AudioCategory_Reset(namePtr);
            Marshal.FreeHGlobal(namePtr);
        }
    }
}