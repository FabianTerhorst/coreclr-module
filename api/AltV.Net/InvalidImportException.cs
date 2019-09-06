using System;

namespace AltV.Net
{
    public class InvalidImportException : Exception
    {
        internal InvalidImportException(string message)
            : base(message)
        {
        }
    }
}