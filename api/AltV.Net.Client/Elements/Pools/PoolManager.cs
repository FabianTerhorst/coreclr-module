using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class PoolManager : IPoolManager
    {

        IReadOnlyEntityPool<ISharedPlayer> ISharedPoolManager.Player => Player;

        public IEntityPool<IVehicle> Vehicle { get; }
        public IEntityPool<IPed> Ped { get; }
        public IEntityPool<IObject> Object { get; }
        public IBaseObjectPool<IBlip> Blip { get; }
        public IBaseObjectPool<ICheckpoint> Checkpoint { get; }
        public IBaseObjectPool<IVirtualEntity> VirtualEntity { get; }
        public IBaseObjectPool<IVirtualEntityGroup> VirtualEntityGroup { get; }
        public IBaseObjectPool<IMarker> Marker { get; }
        public IBaseObjectPool<IRmlDocument> RmlDocument { get; }
        public IBaseObjectPool<IRmlElement> RmlElement { get; }
        public IBaseObjectPool<IAudio> Audio { get; }
        public IBaseObjectPool<IHttpClient> HttpClient { get; }
        public IBaseObjectPool<IWebSocketClient> WebSocketClient { get; }
        public IBaseObjectPool<IWebView> WebView { get; }

        public IPlayerPool Player { get; }

        IReadOnlyEntityPool<ISharedVehicle> ISharedPoolManager.Vehicle => Vehicle;

        IReadOnlyEntityPool<ISharedPed> ISharedPoolManager.Ped => Ped;

        IReadOnlyEntityPool<ISharedObject> ISharedPoolManager.Object => Object;

        IReadOnlyBaseObjectPool<ISharedBlip> ISharedPoolManager.Blip => Blip;

        IReadOnlyBaseObjectPool<ISharedCheckpoint> ISharedPoolManager.Checkpoint => Checkpoint;

        public IReadOnlyBaseObjectPool<ISharedColShape> ColShape { get; }
        IReadOnlyBaseObjectPool<ISharedVirtualEntity> ISharedPoolManager.VirtualEntity => VirtualEntity;

        IReadOnlyBaseObjectPool<ISharedVirtualEntityGroup> ISharedPoolManager.VirtualEntityGroup => VirtualEntityGroup;

        IReadOnlyBaseObjectPool<ISharedMarker> ISharedPoolManager.Marker => Marker;
        public PoolManager(
            IPlayerPool playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IPed> pedPool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IAudio> audioPool,
            IBaseObjectPool<IHttpClient> httpClientPool,
            IBaseObjectPool<IWebSocketClient> webSocketClientPool,
            IBaseObjectPool<IWebView> webViewPool,
            IBaseObjectPool<IRmlElement> rmlElementPool,
            IBaseObjectPool<IRmlDocument> rmlDocumentPool,
            IEntityPool<IObject> objectPool,
            IBaseObjectPool<IVirtualEntity> virtualEntitiyPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntitiyGroupPool

        )
        {
            this.Player = playerPool;
            this.Vehicle = vehiclePool;
            this.Ped = pedPool;
            this.Blip = blipPool;
            this.Checkpoint = checkpointPool;
            this.Audio = audioPool;
            this.HttpClient = httpClientPool;
            this.WebSocketClient = webSocketClientPool;
            this.WebView = webViewPool;
            this.RmlElement = rmlElementPool;
            this.RmlDocument = rmlDocumentPool;
            this.Object = objectPool;
            this.VirtualEntity = virtualEntitiyPool;
            this.VirtualEntityGroup = virtualEntitiyGroupPool;
        }

        public ISharedBaseObject GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId)
        {
            throw new NotImplementedException();
        }

        public ISharedBaseObject GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            throw new NotImplementedException();
        }

        public ISharedBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            throw new NotImplementedException();
        }

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId)
        {
            throw new NotImplementedException();
        }

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            throw new NotImplementedException();
        }

        IBaseObject IPoolManager.Get(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IBaseObject baseObject)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Player.Dispose();
            Vehicle.Dispose();
            Ped.Dispose();
            Blip.Dispose();
            Checkpoint.Dispose();
            Audio.Dispose();
            HttpClient.Dispose();
            WebSocketClient.Dispose();
            WebView.Dispose();
            RmlElement.Dispose();
            RmlDocument.Dispose();
            Object.Dispose();
            VirtualEntity.Dispose();
            VirtualEntityGroup.Dispose();
        }
    }
}