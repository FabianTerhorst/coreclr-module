using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public class EntityPool
    {
        private readonly Dictionary<IntPtr, IEntity> entities = new Dictionary<IntPtr, IEntity>();
    }
}