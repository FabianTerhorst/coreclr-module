using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class AudioFilter : BaseObject, IAudioFilter
{
    public static IntPtr GetBaseObjectNativePointer(ICore core, IntPtr audioFilterNativePointer)
    {
        unsafe
        {
            return core.Library.Client.AudioFilter_GetBaseObject(audioFilterNativePointer);
        }
    }

    public AudioFilter(ICore core, IntPtr audioFilterNativePointer, uint id) : base(core, GetBaseObjectNativePointer(core, audioFilterNativePointer), BaseObjectType.AudioFilter, id)
    {
        AudioFilterNativePointer = audioFilterNativePointer;
    }

    public IntPtr AudioFilterNativePointer { get; }
    public override IntPtr NativePointer => AudioFilterNativePointer;

    public uint Hash
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.AudioFilter_GetHash(AudioFilterNativePointer);
            }
        }
    }

    public uint AudCategory
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.AudioFilter_GetAudCategory(AudioFilterNativePointer);
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.AudioFilter_SetAudCategory(AudioFilterNativePointer, value);
            }
        }
    }

    public uint AddRotateEffect(float fRate, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddRotateEffect(AudioFilterNativePointer, fRate, priority);
        }
    }

    public uint AddVolumeEffect(float fVolume, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddVolumeEffect(AudioFilterNativePointer, fVolume, priority);
        }
    }

    public uint AddPeakeqEffect(int lBand, float fBandwidth, float fQ, float fCenter, float fGain, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddPeakeqEffect(AudioFilterNativePointer, lBand, fBandwidth, fQ, fCenter, fGain, priority);
        }
    }

    public uint AddDampEffect(float fTarget, float fQuiet, float fRate, float fGain, float fDelay, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddDampEffect(AudioFilterNativePointer, fTarget, fQuiet, fRate, fGain, fDelay, priority);
        }
    }

    public uint AddAutowahEffect(float fDryMix, float fWetMix, float fFeedback, float fRate, float fRange, float fFreq,
        int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddAutowahEffect(AudioFilterNativePointer, fDryMix, fWetMix, fFeedback, fRate, fRange, fFreq, priority);
        }
    }

    public uint AddPhaserEffect(float fDryMix, float fWetMix, float fFeedback, float fRate, float fRange, float fFreq,
        int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddPhaserEffect(AudioFilterNativePointer, fDryMix, fWetMix, fFeedback, fRate, fRange, fFreq, priority);
        }
    }

    public uint AddChorusEffect(float fDryMix, float fWetMix, float fFeedback, float fMinSweep, float fMaxSweep, float fRate,
        int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddChorusEffect(AudioFilterNativePointer, fDryMix, fWetMix, fFeedback, fMinSweep, fMaxSweep, fRate, priority);
        }
    }

    public uint AddDistortionEffect(float fDrive, float fDryMix, float fWetMix, float fFeedback, float fVolume, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddDistortionEffect(AudioFilterNativePointer, fDrive, fDryMix, fWetMix, fFeedback, fVolume, priority);
        }
    }

    public uint AddCompressor2Effect(float fGain, float fThreshold, float fRatio, float fAttack, float fRelease, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddCompressor2Effect(AudioFilterNativePointer, fGain, fThreshold, fRatio, fAttack, fRelease, priority);
        }
    }

    public uint AddBqfEffect(int lFilter, float fCenter, float fGain, float fBandwidth, float fQ, float fS, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddBqfEffect(AudioFilterNativePointer, lFilter, fCenter, fGain, fBandwidth, fQ, fS, priority);
        }
    }

    public uint AddEcho4Effect(float fDryMix, float fWetMix, float fFeedback, float fDelay, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddEcho4Effect(AudioFilterNativePointer, fDryMix, fWetMix, fFeedback, fDelay, priority);
        }
    }

    public uint AddPitchshiftEffect(float fPitchShift, float fSemitones, long lFFTsize, long lOsamp, int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddPitchshiftEffect(AudioFilterNativePointer, fPitchShift, fSemitones, lFFTsize, lOsamp, priority);
        }
    }

    public uint AddFreeverbEffect(float fDryMix, float fWetMix, float fRoomSize, float fDamp, float fWidth, uint lMode,
        int priority)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_AddFreeverbEffect(AudioFilterNativePointer, fDryMix, fWetMix, fRoomSize, fDamp, fWidth, lMode, priority);
        }
    }

    public bool RemoveEffect(uint effect)
    {
        unsafe
        {
            CheckIfEntityExists();
            return Core.Library.Client.AudioFilter_RemoveEffect(AudioFilterNativePointer, effect) == 1;
        }
    }
}