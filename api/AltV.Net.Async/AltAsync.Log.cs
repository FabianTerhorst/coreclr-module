using System;
using System.Text;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        private const string HourWithZero = "[";
        private const string HourWithoutZero = "[0";

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

            Console.WriteLine(message);
        }
    }
}