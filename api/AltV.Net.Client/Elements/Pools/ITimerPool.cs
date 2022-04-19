using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public interface ITimerPool
    {
        void Tick(string resourceName);
        uint Add(IModuleTimer timer);
        void Remove(uint id);
    }
}