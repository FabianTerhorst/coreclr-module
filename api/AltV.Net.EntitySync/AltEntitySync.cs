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

        public static void Init(long threadCount,
            Func<IClientRepository, NetworkLayer> createNetworkLayer,
            Func<SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            IdProvider = idProvider;
            _entitySyncServer =
                new EntitySyncServer(threadCount, createNetworkLayer, createSpatialPartition, idProvider);
        }

        public static void AddEntity(IEntity entity)
        {
            _entitySyncServer.AddEntity(entity);
        }

        public static void RemoveEntity(IEntity entity)
        {
            _entitySyncServer.RemoveEntity(entity);
        }

        public static IEntity CreateEntity(ulong type, Vector3 position, uint range)
        {
            return CreateEntity(type, position, range, new Dictionary<string, object>());
        }

        public static IEntity CreateEntity(ulong type, Vector3 position, uint range, IDictionary<string, object> data)
        {
            return _entitySyncServer.CreateEntity(type, position, range, data);
        }
    }
}