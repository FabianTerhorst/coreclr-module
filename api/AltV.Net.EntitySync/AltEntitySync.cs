using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.EntitySync.Events;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync
{
    public static class AltEntitySync
    {
        internal static IIdProvider<ulong> IdProvider;

        internal static EntitySyncServer EntitySyncServer;

        public static event EntityCreateDelegate OnEntityCreate
        {
            add => EntitySyncServer.EntityCreateCallbacks.AddLast(value);
            remove => EntitySyncServer.EntityCreateCallbacks.Remove(value);
        }

        public static event EntityRemoveDelegate OnEntityRemove
        {
            add => EntitySyncServer.EntityRemoveCallbacks.AddLast(value);
            remove => EntitySyncServer.EntityRemoveCallbacks.Remove(value);
        }

        public static void Init(ulong threadCount, int syncRate, bool netOwnerEvents,
            Func<ulong, IClientRepository, NetworkLayer> createNetworkLayer,
            Func<ulong, SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            Init(threadCount, syncRate, netOwnerEvents, createNetworkLayer, (entity, tc) => (entity.Id % tc),
                (entityId, entityType, tc) => (entityId % tc), createSpatialPartition,
                idProvider);
        }

        public static void Init(ulong threadCount, int syncRate, bool netOwnerEvents,
            Func<ulong, IClientRepository, NetworkLayer> createNetworkLayer,
            Func<IEntity, ulong, ulong> entityThreadId,
            Func<ulong, ulong, ulong, ulong> entityIdAndTypeThreadId,
            Func<ulong, SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            IdProvider = idProvider;
            EntitySyncServer =
                new EntitySyncServer(threadCount, syncRate, netOwnerEvents, createNetworkLayer, entityThreadId, entityIdAndTypeThreadId,
                    createSpatialPartition, idProvider);
        }

        public static void AddEntity(IEntity entity)
        {
            EntitySyncServer.AddEntity(entity);
        }

        public static void RemoveEntity(IEntity entity)
        {
            EntitySyncServer.RemoveEntity(entity);
        }

        public static bool TryGetEntity(ulong id, ulong type, out IEntity entity)
        {
            return EntitySyncServer.TryGetEntity(id, type, out entity);
        }

        public static List<IEntity> FindEntities(Vector3 position, int dimension)
        {
            return EntitySyncServer.FindEntities(position, dimension);
        }

        public static IEnumerable<IEntity> GetAllEntities()
        {
            return EntitySyncServer.GetAllEntities();
        }

        public static IEntity CreateEntity(ulong type, Vector3 position, int dimension, uint range)
        {
            return CreateEntity(type, position, dimension, range, new Dictionary<string, object>());
        }

        public static IEntity CreateEntity(ulong type, Vector3 position, int dimension, uint range,
            IDictionary<string, object> data)
        {
            return EntitySyncServer.CreateEntity(type, position, dimension, range, data);
        }
        
        public static IEntity CreateEntityWithOwnIdManagement(ulong id, ulong type, Vector3 position, int dimension, uint range,
            IDictionary<string, object> data)
        {
            return EntitySyncServer.CreateEntity(id, type, position, dimension, range, data);
        }

        public static void Stop()
        {
            EntitySyncServer.Stop();
        }
    }
}