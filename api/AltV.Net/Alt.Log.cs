using System;
using System.Text;

namespace AltV.Net
{
    public static partial class Alt
    {
        private const string HourWithZero = "[0";
        private const string HourWithoutZero = "[";

        private const string NumberWithZero = ":0";
        private const string NumberWithoutZero = ":";

        private const string Ending = "] ";

        public static void LogFast(string message)
        {
            var dateTimeNow = DateTime.Now;
            var hour = dateTimeNow.Hour;
            var minute = dateTimeNow.Minute;
            var second = dateTimeNow.Second;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(hour < 10 ? HourWithZero : HourWithoutZero);

            stringBuilder.Append(hour);

            stringBuilder.Append(minute < 10 ? NumberWithZero : NumberWithoutZero);

            stringBuilder.Append(minute);

            stringBuilder.Append(second < 10 ? NumberWithZero : NumberWithoutZero);

            stringBuilder.Append(second);
            stringBuilder.Append(Ending);

            stringBuilder.Append(message);

            Console.WriteLine(stringBuilder.ToString());
        }

        public static void LogInfo(string message)
        {
            Alt.Server.LogInfo(message);
        }
        
        public static void LogDebug(string message)
        {
            Alt.Server.LogDebug(message);
        }
        
        public static void LogWarning(string message)
        {
            Alt.Server.LogWarning(message);
        }
        
        public static void LogError(string message)
        {
            Alt.Server.LogError(message);
        }
    }
}
