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
        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;
        private readonly IBaseObjectPool<IAudio> audioPool;
        private readonly IBaseObjectPool<IHttpClient> httpClientPool;
        private readonly IBaseObjectPool<IWebSocketClient> webSocketClientPool;
        private readonly IBaseObjectPool<IWebView> webViewPool;
        private readonly IBaseObjectPool<IRmlElement> rmlElementPool;
        private readonly IBaseObjectPool<IRmlDocument> rmlDocumentPool;
        private readonly IEntityPool<IObject> objectPool;
        private readonly IEntityPool<IPed> pedPool;
        private readonly IBaseObjectPool<IVirtualEntity> virtualEntitiyPool;
        private readonly IBaseObjectPool<IVirtualEntityGroup> virtualEntitiyGroupPool;

        public BaseBaseObjectPool(
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IAudio> audioPool,
            IBaseObjectPool<IHttpClient> httpClientPool,
            IBaseObjectPool<IWebSocketClient> webSocketClientPool,
            IBaseObjectPool<IWebView> webViewPool,
            IBaseObjectPool<IRmlElement> rmlElementPool,
            IBaseObjectPool<IRmlDocument> rmlDocumentPool,
            IEntityPool<IObject> objectPool,
            IEntityPool<IPed> pedPool,
            IBaseObjectPool<IVirtualEntity> virtualEntitiyPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntitiyGroupPool

        )
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.audioPool = audioPool;
            this.httpClientPool = httpClientPool;
            this.webSocketClientPool = webSocketClientPool;
            this.webViewPool = webViewPool;
            this.rmlElementPool = rmlElementPool;
            this.rmlDocumentPool = rmlDocumentPool;
            this.objectPool = objectPool;
            this.pedPool = pedPool;
            this.virtualEntitiyPool = virtualEntitiyPool;
            this.virtualEntitiyGroupPool = virtualEntitiyGroupPool;
        }

        public IBaseObject? Get(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.LocalPlayer => playerPool.Get(entityPointer),
                BaseObjectType.Player => playerPool.Get(entityPointer),
                BaseObjectType.Vehicle => vehiclePool.Get(entityPointer),
                BaseObjectType.Blip => blipPool.Get(entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.Get(entityPointer),
                BaseObjectType.Audio => audioPool.Get(entityPointer),
                BaseObjectType.HttpClient => httpClientPool.Get(entityPointer),
                BaseObjectType.WebsocketClient => webSocketClientPool.Get(entityPointer),
                BaseObjectType.Webview => webViewPool.Get(entityPointer),
                BaseObjectType.RmlElement => rmlElementPool.Get(entityPointer),
                BaseObjectType.RmlDocument => rmlDocumentPool.Get(entityPointer),
                BaseObjectType.Object => objectPool.Get(entityPointer),
                BaseObjectType.Ped => pedPool.Get(entityPointer),
                BaseObjectType.VirtualEntity => virtualEntitiyPool.Get(entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntitiyGroupPool.Get(entityPointer),
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
                BaseObjectType.Blip => blipPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Audio => audioPool.GetOrCreate(core, entityPointer),
                BaseObjectType.HttpClient => httpClientPool.GetOrCreate(core, entityPointer),
                BaseObjectType.WebsocketClient => webSocketClientPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Webview => webViewPool.GetOrCreate(core, entityPointer),
                BaseObjectType.RmlElement => rmlElementPool.GetOrCreate(core, entityPointer),
                BaseObjectType.RmlDocument => rmlDocumentPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Object => objectPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Ped => pedPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntity => virtualEntitiyPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntitiyGroupPool.GetOrCreate(core, entityPointer),
                _ => default
            };
        }
        ISharedBaseObject IReadOnlyBaseBaseObjectPool.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType) => GetOrCreate((ICore) core, entityPointer, baseObjectType);

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Vehicle => vehiclePool.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Blip => blipPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Audio => audioPool.GetOrCreate(core, entityPointer),
                BaseObjectType.HttpClient => httpClientPool.GetOrCreate(core, entityPointer),
                BaseObjectType.WebsocketClient => webSocketClientPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Webview => webViewPool.GetOrCreate(core, entityPointer),
                BaseObjectType.RmlElement => rmlElementPool.GetOrCreate(core, entityPointer),
                BaseObjectType.RmlDocument => rmlDocumentPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Object => objectPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Ped => pedPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntity => virtualEntitiyPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntitiyGroupPool.GetOrCreate(core, entityPointer),
                _ => default
            };
        }
        ISharedBaseObject IReadOnlyBaseBaseObjectPool.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId) => GetOrCreate((ICore) core, entityPointer, baseObjectType, entityId);

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
                BaseObjectType.Blip => blipPool.Remove(entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.Remove(entityPointer),
                BaseObjectType.Audio => audioPool.Remove(entityPointer),
                BaseObjectType.HttpClient => httpClientPool.Remove(entityPointer),
                BaseObjectType.WebsocketClient => webSocketClientPool.Remove(entityPointer),
                BaseObjectType.Webview => webViewPool.Remove(entityPointer),
                BaseObjectType.RmlElement => rmlElementPool.Remove(entityPointer),
                BaseObjectType.RmlDocument => rmlDocumentPool.Remove(entityPointer),
                BaseObjectType.Object => objectPool.Remove(entityPointer),
                BaseObjectType.Ped => pedPool.Remove(entityPointer),
                BaseObjectType.VirtualEntity => virtualEntitiyPool.Remove(entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntitiyGroupPool.Remove(entityPointer),
                _ => false
            };
        }
    }
}