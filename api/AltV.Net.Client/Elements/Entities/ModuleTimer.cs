using System.Runtime.CompilerServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;

namespace AltV.Net.Client.Elements.Entities
{

    public class ModuleTimer : IModuleTimer
    {
        public long LastRun { get; private set; }
        public Action Callback { get; }
        public uint Interval { get; }
        public bool Once { get; }
        public string Location { get; }

        public ModuleTimer(Action callback, uint interval, bool once, [CallerFilePath] string file = "[unknown].cs", [CallerLineNumber] int line = 0)
        {
            LastRun = TimerPool.GetTime();
            Callback = callback;
            Interval = interval;
            Once = once;
            
            Location = line != 0 ? $"{file}:{line}" : file;
        }

        public bool Update(long curTime)
        {
            if (curTime - LastRun < Interval) return true;
            Callback();
            LastRun = curTime;

            return !Once;
        }
    }
}