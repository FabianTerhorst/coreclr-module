using System;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public class BaseObjectRemovedException : Exception
    {
        internal BaseObjectRemovedException(ISharedBaseObject baseObject) : base(
            $"BaseObject(Type: {baseObject.Type.ToString()}) got deleted.")
        {
        }

        public BaseObjectRemovedException(string message) : base(message)
        {
        }
    }
}