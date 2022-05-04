using Timer = System.Timers.Timer;

namespace AltV.Net.Client
{
    public class SafeTimer : Timer
    {
        public SafeTimer()
        {
            Alt.CoreImpl.RunningTimers.Add(this);
        }

        public SafeTimer(double interval) : base(interval)
        {
            Alt.CoreImpl.RunningTimers.Add(this);
        }

        protected override void Dispose(bool disposing)
        {
            Alt.CoreImpl.RunningTimers.Remove(this);
        }
    }
}