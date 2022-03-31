using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class BaseBaseObjectPool : IBaseBaseObjectPool
    {
        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;
        private readonly IBaseObjectPool<IBlip> blipPool;
        private readonly IBaseObjectPool<IWebView> webViewPool;

        public BaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool, IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<IWebView> webViewPool)
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.webViewPool = webViewPool;
        }

        public IBaseObject? Get(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.Get(entityPointer),
                BaseObjectType.Vehicle => vehiclePool.Get(entityPointer),
                BaseObjectType.Webview => webViewPool.Get(entityPointer),
                BaseObjectType.Blip => blipPool.Get(entityPointer),
                _ => default
            };
        }

        ISharedBaseObject IReadOnlyBaseBaseObjectPool.Get(IntPtr entityPointer, BaseObjectType baseObjectType) => Get(entityPointer, baseObjectType);

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Vehicle => vehiclePool.GetOrCreate(core, entityPointer),
                _ => default
            };
        }

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Vehicle => vehiclePool.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Webview => webViewPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Blip => blipPool.GetOrCreate(core, entityPointer),
                _ => default
            };
        }

        public bool Remove(IBaseObject entity)
        {
            return Remove(entity.NativePointer, entity.Type);
        }

        public bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.Remove(entityPointer),
                BaseObjectType.Vehicle => vehiclePool.Remove(entityPointer),
                _ => false
            };
        }
    }
}