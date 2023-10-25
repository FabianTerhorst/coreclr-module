using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IAudio : IBaseObject
    {
        IntPtr AudioNativePointer { get; }
        bool Looped { get; set; }
        float Volume { get; set; }
        string Source { get; set; }
        double CurrentTime { get; }
        double MaxTime { get; }
        bool IsPlaying { get; }
        void AddOutput(IAudioOutput audioOutput);
        void RemoveOutput(IAudioOutput audioOutput);
        AudioEntity[] GetOutputs();
        void Pause();
        void Play();
        void Reset();
        void Seek(double time);
    }
}