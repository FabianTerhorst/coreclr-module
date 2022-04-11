using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class TimerPool : ITimerPool
    {
        private uint lastId;
        private readonly Dictionary<uint, IModuleTimer> timers = new();

        public static long GetTime()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void Tick(string resourceName)
        {
            foreach (var (id, timer) in timers.ToArray())
            {
                var time = GetTime();
                if (!timer.Update(time)) Remove(id);

                var diff = GetTime() - time;
                if (diff > 10)
                {
                    Alt.LogWarning($"Timer at {resourceName} {timer.Location} was too long {diff}ms (>10 ms)");
                }
            }
        }

        public uint Add(IModuleTimer timer)
        {
            var id = lastId++;
            timers.Add(id, timer);
            return id;
        }
        
        public void Remove(uint id)
        {
            timers.Remove(id);
        }
    }
}