using System;

namespace AltV.Net.Elements.Entities
{
    public class BaseObjectDeletedException : Exception
    {
        internal BaseObjectDeletedException(IBaseObject baseObject) : base(
            $"BaseObject(Type: {baseObject.Type.ToString()}) got deleted.")
        {
        }
    }
}