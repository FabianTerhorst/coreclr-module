using System;
using System.Net;
using System.Runtime.Loader;
using AltV.Net.CApi;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net
{
    public abstract class Resource : IResource
    {
        public abstract void OnStart();

        public abstract void OnStop();

        public virtual void OnTick()
        {
        }

        public void OnStart(IntPtr serverPointer, IntPtr resourcePointer, string resourceName, string entryPoint)
        {
            OnStart();
        }

        public virtual IPoolManager GetBaseBaseObjectPool(IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool, IEntityPool<IPed> pedPool, IEntityPool<INetworkObject> networkObjectPool, IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool, IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool, IBaseObjectPool<IVirtualEntity> virtualEntityPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool,
            IBaseObjectPool<IMarker> markerPool, IBaseObjectPool<IConnectionInfo> connectionInfoPool)
        {
            return new PoolManager(playerPool, vehiclePool, pedPool, networkObjectPool, blipPool, checkpointPool, voiceChannelPool,
                colShapePool, virtualEntityPool, virtualEntityGroupPool, markerPool, connectionInfoPool);
        }

        public virtual IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory)
        {
            return new PlayerPool(playerFactory);
        }

        public virtual IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory)
        {
            return new VehiclePool(vehicleFactory);
        }

        public virtual IEntityPool<IPed> GetPedPool(IEntityFactory<IPed> pedFactory)
        {
            return new PedPool(pedFactory);
        }

        public IEntityPool<INetworkObject> GetNetworkObjectPool(IEntityFactory<INetworkObject> networkObjectFactory)
        {
            return new NetworkObjectPool(networkObjectFactory);
        }

        public virtual IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory)
        {
            return new BlipPool(blipFactory);
        }

        public virtual IBaseObjectPool<ICheckpoint> GetCheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointFactory)
        {
            return new CheckpointPool(checkpointFactory);
        }

        public virtual IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(
            IBaseObjectFactory<IVoiceChannel> voiceChannelFactory)
        {
            return new VoiceChannelPool(voiceChannelFactory);
        }

        public virtual IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory)
        {
            return new ColShapePool(colShapeFactory);
        }

        public virtual INativeResourcePool GetNativeResourcePool(INativeResourceFactory nativeResourceFactory)
        {
            return new NativeResourcePool(nativeResourceFactory);
        }

        public virtual IBaseObjectPool<IVirtualEntity> GetVirtualEntityPool(IBaseObjectFactory<IVirtualEntity> virtualEntityFactory)
        {
            return new VirtualEntityPool(virtualEntityFactory);
        }

        public virtual IBaseObjectPool<IVirtualEntityGroup> GetVirtualEntityGroupPool(IBaseObjectFactory<IVirtualEntityGroup> virtualEntityGroupFactory)
        {
            return new VirtualEntityGroupPool(virtualEntityGroupFactory);
        }

        public virtual IBaseObjectPool<IMarker> GetMarkerPool(IBaseObjectFactory<IMarker> markerFactory)
        {
            return new MarkerPool(markerFactory);
        }

        public IBaseObjectPool<IConnectionInfo> GetConnectionInfoPool(IBaseObjectFactory<IConnectionInfo> connectionInfoFactory)
        {
            return new ConnectionInfoPool(connectionInfoFactory);
        }

        public virtual IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return null;
        }

        public virtual IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return null;
        }

        public virtual IEntityFactory<IPed> GetPedFactory()
        {
            return null;
        }

        public virtual IEntityFactory<INetworkObject> GetNetworkObjectFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<IBlip> GetBlipFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<ICheckpoint> GetCheckpointFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<IColShape> GetColShapeFactory()
        {
            return null;
        }

        public virtual INativeResourceFactory GetNativeResourceFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<IVirtualEntity> GetVirtualEntityFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<IVirtualEntityGroup> GetVirtualEntityGroupFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<IMarker> GetMarkerFactory()
        {
            return null;
        }

        public virtual IBaseObjectFactory<IConnectionInfo> GetConnectionInfoFactory()
        {
            return null;
        }

        public ILibrary GetLibrary()
        {
            return null;
        }

        public virtual Core GetCore(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IPoolManager poolManager,
            INativeResourcePool nativeResourcePool)
        {
            return new Core(nativePointer, resourcePointer, assemblyLoadContext, library, poolManager, nativeResourcePool);
        }

        public IScript[] GetScripts()
        {
            return null;
        }

        public IModule[] GetModules()
        {
            return null;
        }
    }
}