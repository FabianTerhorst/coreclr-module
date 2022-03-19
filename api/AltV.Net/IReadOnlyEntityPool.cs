using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net
{
    public interface IReadOnlyEntityPool<out TEntity> where TEntity : IEntity
    {
        TEntity Get(IntPtr entityPointer);

        TEntity GetOrCreate(ICore core, IntPtr entityPointer, ushort entityId);
        
        TEntity GetOrCreate(ICore core, IntPtr entityPointer);

        IReadOnlyCollection<TEntity> GetAllEntities();
    }
}