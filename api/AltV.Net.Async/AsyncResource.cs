using System;
using System.Runtime.Loader;
using AltV.Net.Async.Elements.Entities;
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

        public override IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory)
        {
            return new AsyncPlayerPool(playerFactory, forceAsync);
        }

        public override IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory)
        {
            return new AsyncVehiclePool(vehicleFactory, forceAsync);
        }

        public override IEntityPool<IPed> GetPedPool(IEntityFactory<IPed> pedFactory)
        {
            return new AsyncPedPool(pedFactory, forceAsync);
        }

        public override IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory)
        {
            return new AsyncBlipPool(blipFactory, forceAsync);
        }

        public override IBaseObjectPool<IVirtualEntity> GetVirtualEntityPool(IBaseObjectFactory<IVirtualEntity> virtualEntityFactory)
        {
            return new AsyncVirtualEntityPool(virtualEntityFactory, forceAsync);
        }

        public override IBaseObjectPool<IVirtualEntityGroup> GetVirtualEntityGroupPool(IBaseObjectFactory<IVirtualEntityGroup> virtualEntityGroupFactory)
        {
            return new AsyncVirtualEntityGroupPool(virtualEntityGroupFactory, forceAsync);
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

        public override IBaseObjectPool<IMarker> GetMarkerPool(IBaseObjectFactory<IMarker> factory)
        {
            return new AsyncMarkerPool(factory, forceAsync);
        }

        public override Core GetCore(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IPoolManager poolManager,
            INativeResourcePool nativeResourcePool)
        {
            return new AsyncCore(nativePointer, resourcePointer, assemblyLoadContext, library, poolManager, nativeResourcePool);
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

        public override IEntityFactory<IPed> GetPedFactory()
        {
            return forceAsync ? new AsyncPedFactory() : base.GetPedFactory();
        }

        public override IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory()
        {
            return forceAsync ? new AsyncVoiceChannelFactory() : base.GetVoiceChannelFactory();
        }

        public override IBaseObjectFactory<IVirtualEntity> GetVirtualEntityFactory()
        {
            return forceAsync ? new AsyncVirtualEntityFactory() : base.GetVirtualEntityFactory();
        }

        public override IBaseObjectFactory<IVirtualEntityGroup> GetVirtualEntityGroupFactory()
        {
            return forceAsync ? new AsyncVirtualEntityGroupFactory() : base.GetVirtualEntityGroupFactory();
        }

        public override IBaseObjectFactory<IMarker> GetMarkerFactory()
        {
            return forceAsync ? new AsyncMarkerFactory() : base.GetMarkerFactory();
        }
    }
}