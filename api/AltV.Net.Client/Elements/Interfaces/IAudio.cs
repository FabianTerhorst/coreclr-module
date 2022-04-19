using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IAudio : IBaseObject
    {
        IntPtr AudioNativePointer { get; }
        uint AudioCategory { get; set; }
        bool Looped { get; set; }
        float Volume { get; set; }
        string Source { get; set; }
        double CurrentTime { get; }
        bool FrontendPlay { get; }
        double MaxTime { get; }
        bool Playing { get; }
        void AddOutput(uint scriptId);
        void AddOutput(IEntity entity);
        void RemoveOutput(uint scriptId);
        void RemoveOutput(IEntity entity);
        AudioEntity[] GetOutputs();
        void Pause();
        void Play();
        void Reset();
        void Seek(double time);
    }
}