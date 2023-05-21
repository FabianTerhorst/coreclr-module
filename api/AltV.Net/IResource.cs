using System;
using System.Runtime.Loader;
using AltV.Net.CApi;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;

namespace AltV.Net
{
    //TODO: add SubResource module maybe to load sub resources dependency dlls or just for own server architecture
    public interface IResource
    {
        void OnStart(IntPtr serverPointer, IntPtr resourcePointer, string resourceName,
            string entryPoint);

        void OnStart();

        void OnStop();

        void OnTick();

        IPoolManager GetBaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,IEntityPool<IPed> pedPool, IEntityPool<INetworkObject> networkObjectPool,
            IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool,
            IBaseObjectPool<IVirtualEntity> virtualEntityPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool,
            IBaseObjectPool<IMarker> markerPool, IBaseObjectPool<IConnectionInfo> connectionInfoPool);

        IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory);
        IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory);
        IEntityPool<IPed> GetPedPool(IEntityFactory<IPed> pedFactory);
        IEntityPool<INetworkObject> GetNetworkObjectPool(IEntityFactory<INetworkObject> networkObjectFactory);
        IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory);
        IBaseObjectPool<ICheckpoint> GetCheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointFactory);
        IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory);
        IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory);
        INativeResourcePool GetNativeResourcePool(INativeResourceFactory nativeResourceFactory);
        IBaseObjectPool<IVirtualEntity> GetVirtualEntityPool(IBaseObjectFactory<IVirtualEntity> virtualEntityFactory);
        IBaseObjectPool<IVirtualEntityGroup> GetVirtualEntityGroupPool(IBaseObjectFactory<IVirtualEntityGroup> virtualEntityGroupFactory);
        IBaseObjectPool<IMarker> GetMarkerPool(IBaseObjectFactory<IMarker> markerFactory);
        IBaseObjectPool<IConnectionInfo> GetConnectionInfoPool(IBaseObjectFactory<IConnectionInfo> connectionInfoFactory);

        IEntityFactory<IPlayer> GetPlayerFactory();
        IEntityFactory<IVehicle> GetVehicleFactory();
        IEntityFactory<IPed> GetPedFactory();
        IEntityFactory<INetworkObject> GetNetworkObjectFactory();
        IBaseObjectFactory<IBlip> GetBlipFactory();
        IBaseObjectFactory<ICheckpoint> GetCheckpointFactory();
        IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory();
        IBaseObjectFactory<IColShape> GetColShapeFactory();
        INativeResourceFactory GetNativeResourceFactory();
        IBaseObjectFactory<IVirtualEntity> GetVirtualEntityFactory();
        IBaseObjectFactory<IVirtualEntityGroup> GetVirtualEntityGroupFactory();
        IBaseObjectFactory<IMarker> GetMarkerFactory();
        IBaseObjectFactory<IConnectionInfo> GetConnectionInfoFactory();
        ILibrary GetLibrary();

        Core GetCore(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IPoolManager poolManager,
            INativeResourcePool nativeResourcePool);

        IScript[] GetScripts();

        IModule[] GetModules();
    }
}