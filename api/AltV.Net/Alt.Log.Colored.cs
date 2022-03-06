using AltV.Net.ColoredConsole;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void LogColored(ColoredMessage message) => Core.LogColored(message.ToString());
    }
}