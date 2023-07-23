namespace AltV.Net.Client.Elements.Interfaces;

public interface IAudioFilter : IBaseObject
{
    IntPtr AudioFilterNativePointer { get; }
    uint Hash { get; }
    uint AudCategory { get; set; }

    uint AddRotateEffect(float fRate, int priority);
    uint AddVolumeEffect(float fVolume, int priority);
    uint AddPeakeqEffect(int lBand, float fBandwidth, float fQ, float fCenter, float fGain, int priority);
    uint AddDampEffect(float fTarget, float fQuiet, float fRate, float fGain, float fDelay, int priority);
    uint AddAutowahEffect(float fDryMix, float fWetMix, float fFeedback, float fRate, float fRange, float fFreq, int priority);
    uint AddPhaserEffect(float fDryMix, float fWetMix, float fFeedback, float fRate, float fRange, float fFreq, int priority);
    uint AddChorusEffect(float fDryMix, float fWetMix, float fFeedback, float fMinSweep, float fMaxSweep, float fRate, int priority);
    uint AddDistortionEffect(float fDrive, float fDryMix, float fWetMix, float fFeedback, float fVolume, int priority);
    uint AddCompressor2Effect(float fGain, float fThreshold, float fRatio, float fAttack, float fRelease, int priority);
    uint AddBqfEffect(int lFilter, float fCenter, float fGain, float fBandwidth, float fQ, float fS, int priority);
    uint AddEcho4Effect(float fDryMix, float fWetMix, float fFeedback, float fDelay, int priority);
    uint AddPitchshiftEffect(float fPitchShift, float fSemitones, long lFFTsize, long lOsamp, int priority);
    uint AddFreeverbEffect(float fDryMix, float fWetMix, float fRoomSize, float fDamp, float fWidth, uint lMode, int priority);

    bool RemoveEffect(uint effect);
}