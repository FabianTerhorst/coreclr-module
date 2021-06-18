namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static void OffServer(string eventName, Function function) =>
            Module.OffServer(eventName, function);

        public static void OffClient(string eventName, Function function) =>
            Module.OffClient(eventName, function);
    }
}