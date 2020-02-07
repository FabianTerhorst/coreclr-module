using System;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync
{
    public static class AltEntitySync
    {
        internal static IIdProvider<ulong> _idProvider;

        internal static EntitySyncServer _entitySyncServer;

        internal static void Init(long threadCount,
            Func<IClientRepository, NetworkLayer> createNetworkLayer,
            Func<SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            _idProvider = idProvider;
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
    }
}