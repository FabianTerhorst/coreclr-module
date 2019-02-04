using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IEntityPool
    {
        bool Get(IntPtr entityPointer, out IEntity entity);
        void Register(IEntity entity);
        bool Remove(IEntity entity);
        bool Remove(IntPtr entityPointer);
    }
}