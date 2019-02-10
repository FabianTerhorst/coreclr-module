using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockServer : IServer
    {
        public static IServer Instance { get; private set; }

        private readonly IntPtr nativePointer;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IEntityPool<IBlip> blipPool;

        private readonly IEntityPool<ICheckpoint> checkpointPool;

        internal MockServer(IntPtr nativePointer, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            this.nativePointer = nativePointer;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            Instance = this;
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void LogDebug(string message)
        {
            throw new System.NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new System.NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new System.NotImplementedException();
        }

        public void LogColored(string message)
        {
            throw new System.NotImplementedException();
        }

        public uint Hash(string hash)
        {
            throw new System.NotImplementedException();
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            Alt.Module.OnServerEvent(eventName, args);
        }

        private static MValue[] ConvertObjectsToMValues(IEnumerable<object> objects)
        {
            return (from obj in objects
                select MValue.CreateFromObject(obj)
                into mValue
                where mValue.HasValue
                select mValue.Value).ToArray();
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, ConvertObjectsToMValues(args));
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            player.PushEvent(eventName, args);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, ConvertObjectsToMValues(args));
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            var ptr = MockEntities.GetNextPtr();
            vehiclePool.Create(ptr, out var vehicle);
            MockEntities.Insert(vehicle);
            return vehicle;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            throw new System.NotImplementedException();
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            throw new System.NotImplementedException();
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveEntity(IEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}