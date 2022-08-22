using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;

namespace AltV.Net.Shared.Exceptions
{
    public class CannotConvertTypeException : Exception
    {
        public CannotConvertTypeException(MValueType from, string to) : base($"Cannot convert {from} to {to}")
        {
        }
        public CannotConvertTypeException(string from, string to) : base($"Cannot convert {from} to {to}")
        {
        }
    }
}