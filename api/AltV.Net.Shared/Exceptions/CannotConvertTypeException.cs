using AltV.Net.Elements.Args;

namespace AltV.Net.Shared.Exceptions
{
    public class CannotConvertTypeException : Exception
    {
        public CannotConvertTypeException(MValueConst.Type from, string to) : base($"Cannot convert {from} to {to}")
        {
        }
        public CannotConvertTypeException(string from, string to) : base($"Cannot convert {from} to {to}")
        {
        }
    }
}