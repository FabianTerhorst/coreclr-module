using System;

namespace AltV.Net
{
    public static class AltTrace
    {
        public static event Action<long> OnTraceFileSizeChange
        {
            add
            {
                lock (HostWrapper.OnTraceFileSizeChangeEventHandlers)
                {
                    HostWrapper.OnTraceFileSizeChangeEventHandlers.Add(value);
                }
            }
            remove
            {
                lock (HostWrapper.OnTraceFileSizeChangeEventHandlers)
                {
                    HostWrapper.OnTraceFileSizeChangeEventHandlers.Remove(value);
                }
            }
        }

        public static void Start(string traceFileName) => HostWrapper.StartTracing(traceFileName);

        public static void Stop() => HostWrapper.StopTracing();
    }
}