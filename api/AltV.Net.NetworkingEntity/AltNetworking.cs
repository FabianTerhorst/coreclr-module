using System;
using AltV.Net.Elements.Entities;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    public static class AltNetworking
    {
        private static StreamingServer _streamingServer;
        
        public static Action<Entity.Entity, IPlayer> OnEntityStreamIn
        {
            set => _streamingServer.EntityStreamInHandler += value;
        }

        public static Action<Entity.Entity, IPlayer> OnEntityStreamOut
        {
            set => _streamingServer.EntityStreamOutHandler += value;
        }

        public static void Init()
        {
            _streamingServer = new StreamingServer();
        }

        public static void Create(Entity.Entity entity)
        {
            _streamingServer?.CreateEntity(entity);
        }

        public static void Delete(ulong id)
        {
            _streamingServer?.DeleteEntity(id);
        }

        public static void UpdatePosition(ulong id, Position position)
        {
            _streamingServer?.UpdateEntityPosition(id, position);
        }

        public static void UpdateData(ulong id, string key, MValue value)
        {
            _streamingServer?.UpdateEntityData(id, key, value);
        }
    }
}