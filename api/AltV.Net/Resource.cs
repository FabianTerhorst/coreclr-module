using System;
using System.Runtime.Loader;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
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

        public virtual IBaseBaseObjectPool GetBaseBaseObjectPool(IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool, IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool, IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool)
        {
            return new BaseBaseObjectPool(playerPool, vehiclePool, blipPool, checkpointPool, voiceChannelPool,
                colShapePool);
        }

        public virtual IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool)
        {
            return new BaseEntityPool(playerPool, vehiclePool);
        }

        public virtual IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory)
        {
            return new PlayerPool(playerFactory);
        }

        public virtual IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory)
        {
            return new VehiclePool(vehicleFactory);
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
        
        public virtual IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new PlayerFactory();
        }

        public virtual IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactory();
        }

        public virtual IBaseObjectFactory<IBlip> GetBlipFactory()
        {
            return new BlipFactory();
        }

        public virtual IBaseObjectFactory<ICheckpoint> GetCheckpointFactory()
        {
            return new CheckpointFactory();
        }

        public virtual IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory()
        {
            return new VoiceChannelFactory();
        }
        
        public virtual IBaseObjectFactory<IColShape> GetColShapeFactory()
        {
            return new ColShapeFactory();
        }

        public virtual INativeResourceFactory GetNativeResourceFactory()
        {
            return new NativeResourceFactory();
        }

        public virtual Module GetModule(IServer server, 
            AssemblyLoadContext assemblyLoadContext,
            INativeResource cSharpNativeResource,
            IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool, IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool)
        {
            return new Module(server, assemblyLoadContext, cSharpNativeResource, baseBaseObjectPool, baseEntityPool, playerPool, vehiclePool,
                blipPool, checkpointPool, voiceChannelPool, colShapePool, nativeResourcePool);
        }
    }
}