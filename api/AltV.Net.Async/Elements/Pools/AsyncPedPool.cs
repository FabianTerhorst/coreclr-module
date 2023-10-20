using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools;

public class AsyncPedPool : AsyncEntityPool<IPed>
{
    public AsyncPedPool(IEntityFactory<IPed> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
    {
    }

    public override uint GetId(IntPtr entityPointer)
    {
        return AltAsync.Do(() => Ped.GetId(entityPointer)).Result;
    }

    public override void ForEach(IBaseObjectCallback<IPed> baseObjectCallback)
    {
        foreach (var entity in GetAllEntities())
        {
            if (!entity.Exists) continue;
            baseObjectCallback.OnBaseObject(entity);
        }
    }

    public override async Task ForEach(IAsyncBaseObjectCallback<IPed> asyncBaseObjectCallback)
    {
        foreach (var entity in GetAllEntities())
        {
            if (!entity.Exists) continue;
            await asyncBaseObjectCallback.OnBaseObject(entity);
        }
    }
}