namespace AltV.Net
{
    public static class AltTrace
    {
        public static void Start() => HostWrapper.StartTracing();

        public static void Stop() => HostWrapper.StopTracing();
    }
}