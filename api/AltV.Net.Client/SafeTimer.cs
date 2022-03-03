using Timer = System.Timers.Timer;

namespace AltV.Net.Client
{
    public class SafeTimer : Timer
    {
        public SafeTimer()
        {
            Alt.Module.RunningTimers.Add(this);
        }
        
        public SafeTimer(double interval) : base(interval)
        {
            Alt.Module.RunningTimers.Add(this);
        }

        protected override void Dispose(bool disposing)
        {
            Alt.Module.RunningTimers.Remove(this);
        }
    }
}