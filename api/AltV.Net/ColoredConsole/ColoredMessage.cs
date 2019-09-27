using System;
using System.Text;

namespace AltV.Net.ColoredConsole
{
    public struct ColoredMessage
    {
        private StringBuilder stringBuilder;

        private void CheckStringBuilder()
        {
            stringBuilder = new StringBuilder();
        }

        public static ColoredMessage operator +(ColoredMessage a, string b)
        {
            a.CheckStringBuilder();
            a.stringBuilder.Append(b);
            return a;
        }

        public static ColoredMessage operator +(ColoredMessage a, TextColor b)
        {
            a.CheckStringBuilder();
            switch (b)
            {
                case TextColor.Black:
                    a.stringBuilder.Append("~k~");
                    break;
                case TextColor.Red:
                    a.stringBuilder.Append("~r~");
                    break;
                case TextColor.Green:
                    a.stringBuilder.Append("~g~");
                    break;
                case TextColor.Blue:
                    a.stringBuilder.Append("~b~");
                    break;
                case TextColor.Yellow:
                    a.stringBuilder.Append("~y~");
                    break;
                case TextColor.Magenta:
                    a.stringBuilder.Append("~m~");
                    break;
                case TextColor.Cyan:
                    a.stringBuilder.Append("~c~");
                    break;
                case TextColor.White:
                    a.stringBuilder.Append("~w~");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(b), b, null);
            }

            return a;
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}