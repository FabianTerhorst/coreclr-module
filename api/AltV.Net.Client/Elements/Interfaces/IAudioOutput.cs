using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IAudioOutput : IBaseObject
    {
        IntPtr AudioOutputNativePointer { get; }
        float Volume { get; set; }
        bool IsMuted { get; set; }

        uint Category { get; }
        IAudio Owner { get; }

        void AddFilter(IAudioFilter filter);
        void RemoveFilter();
        IAudioFilter? Filter { get; }
    }
}