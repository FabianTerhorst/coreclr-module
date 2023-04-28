using System.ComponentModel;
using AltV.Net.Client.Elements.Entities;
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
        public IBaseObjectPool<ITextLabel> TextLabel { get; }
        public IBaseObjectPool<ILocalVehicle> LocalVehicle { get; }
        public IBaseObjectPool<ILocalPed> LocalPed { get; }
        public IBaseObjectPool<IColShape> ColShape { get; }

        public IPlayerPool Player { get; }

        IReadOnlyEntityPool<ISharedVehicle> ISharedPoolManager.Vehicle => Vehicle;

        IReadOnlyEntityPool<ISharedPed> ISharedPoolManager.Ped => Ped;

        IReadOnlyEntityPool<ISharedObject> ISharedPoolManager.Object => Object;

        IReadOnlyBaseObjectPool<ISharedBlip> ISharedPoolManager.Blip => Blip;

        IReadOnlyBaseObjectPool<ISharedCheckpoint> ISharedPoolManager.Checkpoint => Checkpoint;
        IReadOnlyBaseObjectPool<ISharedVirtualEntity> ISharedPoolManager.VirtualEntity => VirtualEntity;

        IReadOnlyBaseObjectPool<ISharedVirtualEntityGroup> ISharedPoolManager.VirtualEntityGroup => VirtualEntityGroup;
        IReadOnlyBaseObjectPool<ISharedColShape> ISharedPoolManager.ColShape => ColShape;

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
            IBaseObjectPool<IVirtualEntityGroup> virtualEntitiyGroupPool,
            IBaseObjectPool<ITextLabel> textLabelPool,
            IBaseObjectPool<IColShape> colShapePool,
            IBaseObjectPool<ILocalVehicle> localVehiclePool,
            IBaseObjectPool<ILocalPed> localPedPool)
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
            TextLabel = textLabelPool;
            ColShape = colShapePool;
            LocalVehicle = localVehiclePool;
            LocalPed = localPedPool;
        }

        ISharedBaseObject ISharedPoolManager.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType,
            uint entityId) => GetOrCreate((ICore)core, entityPointer, baseObjectType, entityId);

        ISharedBaseObject ISharedPoolManager.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType) => GetOrCreate((ICore)core, entityPointer, baseObjectType);

        ISharedBaseObject ISharedPoolManager.Get(IntPtr entityPointer, BaseObjectType baseObjectType) => Get(entityPointer, baseObjectType);

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => Player.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Vehicle => Vehicle.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Blip => Blip.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Checkpoint => Checkpoint.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Audio => Audio.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.HttpClient => HttpClient.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.WebsocketClient => WebSocketClient.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Webview => WebView.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.RmlElement => RmlElement.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.RmlDocument => RmlDocument.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Object => Object.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Ped => Ped.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.VirtualEntity => VirtualEntity.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.TextLabel => TextLabel.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.ColShape => ColShape.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.LocalVehicle => LocalVehicle.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.LocalPed => LocalPed.GetOrCreate(core, entityPointer, entityId),
                _ => default
            };
        }

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => Player.GetOrCreate(core, entityPointer),
                BaseObjectType.Vehicle => Vehicle.GetOrCreate(core, entityPointer),
                BaseObjectType.Blip => Blip.GetOrCreate(core, entityPointer),
                BaseObjectType.Checkpoint => Checkpoint.GetOrCreate(core, entityPointer),
                BaseObjectType.Audio => Audio.GetOrCreate(core, entityPointer),
                BaseObjectType.HttpClient => HttpClient.GetOrCreate(core, entityPointer),
                BaseObjectType.WebsocketClient => WebSocketClient.GetOrCreate(core, entityPointer),
                BaseObjectType.Webview => WebView.GetOrCreate(core, entityPointer),
                BaseObjectType.RmlElement => RmlElement.GetOrCreate(core, entityPointer),
                BaseObjectType.RmlDocument => RmlDocument.GetOrCreate(core, entityPointer),
                BaseObjectType.Object => Object.GetOrCreate(core, entityPointer),
                BaseObjectType.Ped => Ped.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntity => VirtualEntity.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.GetOrCreate(core, entityPointer),
                BaseObjectType.TextLabel => TextLabel.GetOrCreate(core, entityPointer),
                BaseObjectType.ColShape => ColShape.GetOrCreate(core, entityPointer),
                BaseObjectType.LocalVehicle => LocalVehicle.GetOrCreate(core, entityPointer),
                BaseObjectType.LocalPed => LocalPed.GetOrCreate(core, entityPointer),
                _ => default
            };
        }

        public IBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.LocalPlayer => Player.Get(entityPointer),
                BaseObjectType.Player => Player.Get(entityPointer),
                BaseObjectType.Vehicle => Vehicle.Get(entityPointer),
                BaseObjectType.Blip => Blip.Get(entityPointer),
                BaseObjectType.Checkpoint => Checkpoint.Get(entityPointer),
                BaseObjectType.Audio => Audio.Get(entityPointer),
                BaseObjectType.HttpClient => HttpClient.Get(entityPointer),
                BaseObjectType.WebsocketClient => WebSocketClient.Get(entityPointer),
                BaseObjectType.Webview => WebView.Get(entityPointer),
                BaseObjectType.RmlElement => RmlElement.Get(entityPointer),
                BaseObjectType.RmlDocument => RmlDocument.Get(entityPointer),
                BaseObjectType.Object => Object.Get(entityPointer),
                BaseObjectType.Ped => Ped.Get(entityPointer),
                BaseObjectType.VirtualEntity => VirtualEntity.Get(entityPointer),
                BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.Get(entityPointer),
                BaseObjectType.TextLabel => TextLabel.Get(entityPointer),
                BaseObjectType.ColShape => ColShape.Get(entityPointer),
                BaseObjectType.LocalVehicle => LocalVehicle.Get(entityPointer),
                BaseObjectType.LocalPed => LocalPed.Get(entityPointer),
                _ => default
            };
        }

        public bool Remove(IBaseObject baseObject)
        {
            return Remove(baseObject.NativePointer, baseObject.Type);
        }

        public bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.LocalPlayer => Player.Remove(entityPointer),
                BaseObjectType.Player => Player.Remove(entityPointer),
                BaseObjectType.Vehicle => Vehicle.Remove(entityPointer),
                BaseObjectType.Blip => Blip.Remove(entityPointer),
                BaseObjectType.Checkpoint => Checkpoint.Remove(entityPointer),
                BaseObjectType.Audio => Audio.Remove(entityPointer),
                BaseObjectType.HttpClient => HttpClient.Remove(entityPointer),
                BaseObjectType.WebsocketClient => WebSocketClient.Remove(entityPointer),
                BaseObjectType.Webview => WebView.Remove(entityPointer),
                BaseObjectType.RmlElement => RmlElement.Remove(entityPointer),
                BaseObjectType.RmlDocument => RmlDocument.Remove(entityPointer),
                BaseObjectType.Object => Object.Remove(entityPointer),
                BaseObjectType.Ped => Ped.Remove(entityPointer),
                BaseObjectType.VirtualEntity => VirtualEntity.Remove(entityPointer),
                BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.Remove(entityPointer),
                BaseObjectType.TextLabel => TextLabel.Remove(entityPointer),
                BaseObjectType.ColShape => ColShape.Remove(entityPointer),
                BaseObjectType.LocalVehicle => LocalVehicle.Remove(entityPointer),
                BaseObjectType.LocalPed => LocalPed.Remove(entityPointer),
                _ => default
            };
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
            TextLabel.Dispose();
            ColShape.Dispose();
            LocalVehicle.Dispose();
            LocalPed.Dispose();
        }
    }
}