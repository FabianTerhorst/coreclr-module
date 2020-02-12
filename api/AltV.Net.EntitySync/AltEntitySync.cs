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

        public static void Init(long threadCount, int syncRate,
            Func<IClientRepository, NetworkLayer> createNetworkLayer,
            Func<SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            IdProvider = idProvider;
            EntitySyncServer =
                new EntitySyncServer(threadCount, syncRate, createNetworkLayer, createSpatialPartition, idProvider);
        }

        public static void AddEntity(IEntity entity)
        {
            EntitySyncServer.AddEntity(entity);
        }

        public static void RemoveEntity(IEntity entity)
        {
            EntitySyncServer.RemoveEntity(entity);
        }

        public static bool TryGetEntity(ulong id, out IEntity entity)
        {
            return EntitySyncServer.TryGetEntity(id, out entity);
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

        public static void Stop()
        {
            EntitySyncServer.Stop();
        }
    }
}