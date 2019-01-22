using System;

namespace AltV.Net.Elements.Entities
{
    public class EntityDeletedException : Exception
    {
        internal EntityDeletedException(IEntity entity) : base($"This entity ({entity.Type.ToString()}: ID {entity.Id}) does not exist anymore!")
        {

        }

        internal EntityDeletedException(IEntity entity, string parameterName) : base($"Parameter {parameterName}: This entity ({entity.Type.ToString()}: ID {entity.Id}) does not exist anymore!")
        {

        }
    }
}