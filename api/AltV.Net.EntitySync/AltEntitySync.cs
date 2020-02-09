using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync
{
    public static class AltEntitySync
    {
        internal static IIdProvider<ulong> IdProvider;

        private static EntitySyncServer _entitySyncServer;

        public static void Init(long threadCount, int syncRate,
            Func<IClientRepository, NetworkLayer> createNetworkLayer,
            Func<SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            IdProvider = idProvider;
            _entitySyncServer =
                new EntitySyncServer(threadCount, syncRate, createNetworkLayer, createSpatialPartition, idProvider);
        }

        public static void AddEntity(IEntity entity)
        {
            _entitySyncServer.AddEntity(entity);
        }

        public static void RemoveEntity(IEntity entity)
        {
            _entitySyncServer.RemoveEntity(entity);
        }

        public static bool TryGetEntity(ulong id, out IEntity entity)
        {
            return _entitySyncServer.TryGetEntity(id, out entity);
        }

        public static IEnumerable<IEntity> GetAllEntities()
        {
            return _entitySyncServer.GetAllEntities();
        }

        public static IEntity CreateEntity(ulong type, Vector3 position, int dimension, uint range)
        {
            return CreateEntity(type, position, dimension, range, new Dictionary<string, object>());
        }

        public static IEntity CreateEntity(ulong type, Vector3 position, int dimension, uint range,
            IDictionary<string, object> data)
        {
            return _entitySyncServer.CreateEntity(type, position, dimension, range, data);
        }
    }
}