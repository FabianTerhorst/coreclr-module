namespace AltV.Net
{
    public static class AltTrace
    {
        public static void Start(string traceFileName) => HostWrapper.StartTracing(traceFileName);

        public static void Stop() => HostWrapper.StopTracing();
    }
}