using System;

namespace AltV.Net
{
    public class CloudIDRequestException : Exception
    {
        internal CloudIDRequestException(string message)
            : base(message)
        {
        }
    }
}