using System;
using System.Collections.Generic;
using AltV.Net.NetworkingEntity.Elements.Entities;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    // TODO: We don't trigger stream out in entity remove because client can calculate that himself
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

        public static void Init()
        {
            Module = new NetworkingModule();
        }

        public static void Init(NetworkingModule networkingModule)
        {
            Module = networkingModule;
        }

        public static INetworkingEntity CreateEntity(Position position, int dimension, float range,
            IDictionary<string, object> data)
        {
            return CreateEntity(Module.IdProvider.GetNext(), position, dimension, range, data);
        }

        public static INetworkingEntity CreateEntity(ulong id, Position position, int dimension, float range,
            IDictionary<string, object> data)
        {
            var entity = new Entity.Entity {Position = position, Dimension = dimension, Range = range};
            foreach (var (key, value) in data)
            {
                entity.Data[key] = MValueUtils.ToMValue(value);
            }

            return Module.EntityPool.Create(id, Module.Streamer, entity);
        }

        public static void RemoveEntity(INetworkingEntity entity)
        {
            Module.EntityPool.Remove(entity);
        }

        public static INetworkingClient CreateClient()
        {
            return Module.ClientPool.Create(Module.TokenProvider.GetNext());
        }

        public static INetworkingClient CreateClient(string token)
        {
            return Module.ClientPool.Create(token);
        }

        public static void RemoveClient(INetworkingClient client)
        {
            Module.ClientPool.Remove(client);
        }
    }
}