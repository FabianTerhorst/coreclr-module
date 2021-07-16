using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EntityFactoryAttribute : Attribute
    {
        private readonly BaseObjectType baseObjectType;
        
        public EntityFactoryAttribute(BaseObjectType baseObjectType)
        {
            this.baseObjectType = baseObjectType;
        }
    }
}