using System;
using System.Runtime.Loader;
using AltV.Net.CApi;
using AltV.Net.Elements.Entities;

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

        //TODO: default implementation in c# 8.0
        IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool, IEntityPool<IPed> pedPool);

        IBaseBaseObjectPool GetBaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool,
            IBaseObjectPool<IVirtualEntity> virtualEntityPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool);

        IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory);
        IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory);
        IEntityPool<IPed> GetPedPool(IEntityFactory<IPed> pedFactory);
        IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory);
        IBaseObjectPool<ICheckpoint> GetCheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointFactory);
        IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory);
        IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory);
        INativeResourcePool GetNativeResourcePool(INativeResourceFactory nativeResourceFactory);
        IBaseObjectPool<IVirtualEntity> GetVirtualEntityPool(IBaseObjectFactory<IVirtualEntity> virtualEntityFactory);
        IBaseObjectPool<IVirtualEntityGroup> GetVirtualEntityGroupPool(IBaseObjectFactory<IVirtualEntityGroup> virtualEntityGroupFactory);

        IEntityFactory<IPlayer> GetPlayerFactory();
        IEntityFactory<IVehicle> GetVehicleFactory();
        IEntityFactory<IPed> GetPedFactory();
        IBaseObjectFactory<IBlip> GetBlipFactory();
        IBaseObjectFactory<ICheckpoint> GetCheckpointFactory();
        IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory();
        IBaseObjectFactory<IColShape> GetColShapeFactory();
        INativeResourceFactory GetNativeResourceFactory();
        IBaseObjectFactory<IVirtualEntity> GetVirtualEntityFactory();
        IBaseObjectFactory<IVirtualEntityGroup> GetVirtualEntityGroupFactory();
        ILibrary GetLibrary();

        Core GetCore(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IPed> pedPool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool);

        IScript[] GetScripts();

        IModule[] GetModules();
    }
}