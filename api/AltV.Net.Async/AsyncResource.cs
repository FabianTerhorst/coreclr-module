using System;
using System.Runtime.Loader;
using AltV.Net.Async.Elements.Factories;
using AltV.Net.Async.Elements.Pools;
using AltV.Net.CApi;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public abstract class AsyncResource : Resource
    {
        private readonly AltVAsync altVAsync;
        private readonly bool forceAsync;

        public AsyncResource(bool forceAsyncBaseObjects = true) : this(new DefaultTickSchedulerFactory(), forceAsyncBaseObjects)
        {
        }

        public AsyncResource(ITickSchedulerFactory tickSchedulerFactory, bool forceAsyncBaseObjects = true)
        {
            altVAsync = new AltVAsync(tickSchedulerFactory);
            forceAsync = forceAsyncBaseObjects;
            if (!forceAsyncBaseObjects)
            {
                Alt.LogFast("Legacy async API is deprecated");
            }
        }

        public override void OnTick()
        {
            altVAsync.TickDelegate();
        }

        public override IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool)
        {
            return new AsyncBaseBaseObjectPool(playerPool, vehiclePool);
        }

        public override IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory)
        {
            return new AsyncPlayerPool(playerFactory, forceAsync);
        }

        public override IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory)
        {
            return new AsyncVehiclePool(vehicleFactory, forceAsync);
        }

        public override IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory)
        {
            return new AsyncBlipPool(blipFactory, forceAsync);
        }

        public override IBaseObjectPool<ICheckpoint> GetCheckpointPool(
            IBaseObjectFactory<ICheckpoint> checkpointFactory)
        {
            return new AsyncCheckpointPool(checkpointFactory, forceAsync);
        }

        public override IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(
            IBaseObjectFactory<IVoiceChannel> voiceChannelFactory)
        {
            return new AsyncVoiceChannelPool(voiceChannelFactory, forceAsync);
        }

        public override IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory)
        {
            return new AsyncColShapePool(colShapeFactory, forceAsync);
        }
        
        public override Core GetCore(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool)
        {
            return new AsyncCore(nativePointer, resourcePointer, assemblyLoadContext, library, baseBaseObjectPool, baseEntityPool, playerPool, vehiclePool, blipPool, checkpointPool, voiceChannelPool, colShapePool, nativeResourcePool);
        }

        public override IBaseObjectFactory<IBlip> GetBlipFactory()
        {
            return forceAsync ? new AsyncBlipFactory() : base.GetBlipFactory();
        }

        public override IBaseObjectFactory<ICheckpoint> GetCheckpointFactory()
        {
            return forceAsync ? new AsyncCheckpointFactory() : base.GetCheckpointFactory();
        }

        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return forceAsync ? new AsyncPlayerFactory() : base.GetPlayerFactory();
        }

        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return forceAsync ? new AsyncVehicleFactory() : base.GetVehicleFactory();
        }

        public override IBaseObjectFactory<IColShape> GetColShapeFactory()
        {
            return forceAsync ? new AsyncColShapeFactory() : base.GetColShapeFactory();
        }

        public override IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory()
        {
            return forceAsync ? new AsyncVoiceChannelFactory() : base.GetVoiceChannelFactory();
        }
    }
}