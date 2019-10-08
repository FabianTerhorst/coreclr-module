using AltV.Net.ColoredConsole;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static ColoredMessage ColoredMessage => new ColoredMessage();
        
        public static void LogColored(ColoredMessage message) => Server.LogColored(message.ToString());
    }
}