using System;
using System.Collections.Generic;
using AltV.Net.NetworkingEntity.Elements.Entities;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    // TODO: We don't trigger stream out in entity remove because client can calculate that himself

    //TODO: make streaming handler depending on entity if streamed to all players or only the players that are in range
    //TODO: so that server calculates stream in, out for entities that shouldn't be send to all players that aren't in range
    //TODO: that information does only the server need because it will send the entity to the client when in range with all data or snapshot cache

    //TODO: make it possible to set if server should even be notified when enter stream in ,out like we know no data will ever change so no need to spam server with that entity
    public static class AltNetworking
    {
        internal static NetworkingModule Module;

        public static Action<INetworkingEntity, INetworkingClient> OnEntityStreamIn
        {
            set => Module.Server.StreamingHandler.EntityStreamInHandler += value;
        }

        public static Action<INetworkingEntity, INetworkingClient> OnEntityStreamOut
        {
            set => Module.Server.StreamingHandler.EntityStreamOutHandler += value;
        }

        /// <summary>
        /// Configure networking entity module
        /// </summary>
        /// <param name="options"></param>
        public static void Configure(Action<NetworkingEntityModuleOptions> options)
        {
            var defaultOptions = new NetworkingEntityModuleOptions();
            options(defaultOptions);
            Init(defaultOptions.Build());
        }

        /// <summary>
        /// Init module manually, only use when you know what you are doing
        /// </summary>
        /// <param name="networkingModule"></param>
        public static void Init(NetworkingModule networkingModule)
        {
            Module = networkingModule;
        }

        public static INetworkingEntity CreateEntity(Position position, int dimension, float range,
            IDictionary<string, object> data, StreamingType streamingType = StreamingType.Default)
        {
            return CreateEntity(Module.IdProvider.GetNext(), position, dimension, range, data, streamingType);
        }

        public static INetworkingEntity CreateEntity(ulong id, Position position, int dimension, float range,
            IDictionary<string, object> data,
            StreamingType streamingType = StreamingType.Default)
        {
            var entity = new Entity.Entity {Position = position, Dimension = dimension, Range = range};
            if (streamingType != StreamingType.DataStreaming)
            {
                foreach (var (key, value) in data)
                {
                    entity.Data[key] = MValueUtils.ToMValue(value);
                }
            }

            var networkingEntity = Module.EntityPool.Create(id, Module.Streamer, entity, streamingType);

            if (streamingType != StreamingType.DataStreaming) return networkingEntity;
            foreach (var (key, value) in data)
            {
                networkingEntity.SetData(key, value);
            }

            return networkingEntity;
        }

        public static void RemoveEntity(INetworkingEntity entity)
        {
            Module.EntityPool.Remove(entity);
        }

        public static INetworkingClient CreateClient()
        {
            return Module.ClientPool.Create(Module.TokenProvider.GetNext(), Module.Streamer);
        }

        public static INetworkingClient CreateClient(string token)
        {
            return Module.ClientPool.Create(token, Module.Streamer);
        }

        public static void RemoveClient(INetworkingClient client)
        {
            Module.ClientPool.Remove(client);
        }
    }
}