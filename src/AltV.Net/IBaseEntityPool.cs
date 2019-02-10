using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IBaseEntityPool
    {
        bool GetOrCreate(IntPtr entityPointer, out IEntity entity);
        bool Remove(IEntity entity);
        bool Remove(IntPtr entityPointer);
    }
}