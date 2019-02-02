using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IEntityPool
    {
        bool Get(IntPtr entityPointer, out IEntity entity);
        void Register(IEntity entity);
        void Remove(IEntity entity);
        void Remove(IntPtr entityPointer);
    }
}