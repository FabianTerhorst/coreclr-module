using System;

namespace AltV.Net.Elements.Entities
{
    public class BaseObjectRemovedException : Exception
    {
        internal BaseObjectRemovedException(IBaseObject baseObject) : base(
            $"BaseObject(Type: {baseObject.Type.ToString()}) got deleted.")
        {
        }

        public BaseObjectRemovedException(string message) : base(message)
        {
        }
    }
}