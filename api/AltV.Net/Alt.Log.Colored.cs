using AltV.Net.ColoredConsole;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void LogColored(ColoredMessage message) => Server.LogColored(message.ToString());
    }
}