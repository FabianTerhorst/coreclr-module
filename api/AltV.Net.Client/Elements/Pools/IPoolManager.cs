using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;

namespace AltV.Net.Client.Elements.Pools
{
    /// <summary>
    /// This pool decides which entity pool to use depending on the entity type
    /// </summary>
    public interface IPoolManager : ISharedPoolManager
    {
        new IPlayerPool Player { get; }
        new IEntityPool<IVehicle> Vehicle { get; }
        new IEntityPool<IPed> Ped { get; }
        new IEntityPool<IObject> Object { get; }

        new IBaseObjectPool<IBlip> Blip { get; }
        new IBaseObjectPool<ICheckpoint> Checkpoint { get; }
        new IBaseObjectPool<IVirtualEntity> VirtualEntity { get; }
        new IBaseObjectPool<IVirtualEntityGroup> VirtualEntityGroup { get; }
        new IBaseObjectPool<IMarker> Marker { get; }
        new IBaseObjectPool<IColShape> ColShape { get; }
        IBaseObjectPool<IRmlDocument> RmlDocument { get; }
        IBaseObjectPool<IRmlElement> RmlElement { get; }
        IBaseObjectPool<IAudio> Audio { get; }
        IBaseObjectPool<IHttpClient> HttpClient { get; }
        IBaseObjectPool<IWebSocketClient> WebSocketClient { get; }
        IBaseObjectPool<IWebView> WebView { get; }
        IBaseObjectPool<ITextLabel> TextLabel {get;}
        IBaseObjectPool<ILocalVehicle> LocalVehicle {get;}
        IBaseObjectPool<ILocalPed> LocalPed {get;}

        IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId);
        IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType);
        new IBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType);
        bool Remove(IBaseObject baseObject);
        bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}