using System;
using System.Text;

namespace AltV.Net.ColoredConsole
{
    public class ColoredMessage
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        internal ColoredMessage()
        {
        }

        public static ColoredMessage operator +(ColoredMessage a, string b)
        {
            a.stringBuilder.Append(b);
            return a;
        }

        public static ColoredMessage operator +(ColoredMessage a, TextColor b)
        {
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