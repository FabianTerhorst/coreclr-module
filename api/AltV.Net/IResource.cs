using System;
using System.Runtime.Loader;
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
        IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool);

        IBaseBaseObjectPool GetBaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool);

        IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory);
        IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory);
        IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory);
        IBaseObjectPool<ICheckpoint> GetCheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointFactory);
        IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory);
        IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory);

        IEntityFactory<IPlayer> GetPlayerFactory();
        IEntityFactory<IVehicle> GetVehicleFactory();
        IBaseObjectFactory<IBlip> GetBlipFactory();
        IBaseObjectFactory<ICheckpoint> GetCheckpointFactory();
        IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory();
        IBaseObjectFactory<IColShape> GetColShapeFactory();

        Module GetModule(IServer server,
            AssemblyLoadContext assemblyLoadContext,
            NativeResource cSharpNativeResource,
            IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool);
    }
}