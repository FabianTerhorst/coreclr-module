using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IEntityFactory<out TEntity> where TEntity : IEntity
    {
        TEntity Create(ICore core, IntPtr entityPointer, uint id);
    }
}