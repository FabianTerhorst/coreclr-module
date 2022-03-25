namespace AltV.Net
{
    public partial class Alt
    {
        public static void OffServer(string eventName, Function function) =>
            Core.OffServer(eventName, function);

        public static void OffClient(string eventName, Function function) =>
            Core.OffClient(eventName, function);
    }
}