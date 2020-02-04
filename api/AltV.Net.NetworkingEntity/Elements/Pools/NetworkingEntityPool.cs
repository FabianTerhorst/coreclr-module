using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.NetworkingEntity.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Factories;
using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity.Elements.Pools
{
    public class NetworkingEntityPool : INetworkingEntityPool
    {
        private readonly IDictionary<ulong, INetworkingEntity> entities = new Dictionary<ulong, INetworkingEntity>();

        public IDictionary<ulong, INetworkingEntity> Entities => entities;

        private readonly IIdProvider<ulong> idProvider;

        private readonly INetworkingEntityFactory factory;

        public NetworkingEntityPool(IIdProvider<ulong> idProvider, INetworkingEntityFactory factory)
        {
            this.idProvider = idProvider;
            this.factory = factory;
        }

        public INetworkingEntity Create(IEntityStreamer entityStreamer, Entity.Entity streamedEntity) =>
            Create(idProvider.GetNext(), entityStreamer, streamedEntity);

        public INetworkingEntity Create(ulong id, IEntityStreamer entityStreamer, Entity.Entity streamedEntity,
            StreamingType streamingType = StreamingType.Default)
        {
            streamedEntity.Id = id;
            var entity = factory.Create(entityStreamer, streamedEntity, streamingType);
            Add(entity);
            return entity;
        }

        public bool Add(INetworkingEntity entity)
        {
            lock (entities)
            {
                if (entities.TryAdd(entity.Id, entity))
                {
                    OnAdd(entity);
                    return true;
                }
            }

            return false;
        }

        public Task Remove(INetworkingEntity entity) => Remove(entity.Id);

        public async Task Remove(ulong id)
        {
            INetworkingEntity removedEntity;
            lock (entities)
            {
                if (!entities.Remove(id, out removedEntity))
                {
                    return;
                }
            }

            if (removedEntity is IInternalNetworkingEntity internalNetworkingEntity)
            {
                lock (internalNetworkingEntity)
                {
                    internalNetworkingEntity.Exists = false;
                }
            }

            await OnRemove(removedEntity);
        }

        public bool TryGet(ulong id, out INetworkingEntity entity)
        {
            lock (entities)
            {
                return entities.TryGetValue(id, out entity);
            }
        }

        public virtual void OnAdd(INetworkingEntity entity)
        {
            AltNetworking.Module.Streamer.CreateEntity(entity);
        }

        public virtual async Task OnRemove(INetworkingEntity entity)
        {
            try
            {
                await AltNetworking.Module.Streamer.RemoveEntity(entity);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                idProvider.Free(entity.Id);
            }
        }
    }
}