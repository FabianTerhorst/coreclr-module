using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockServer : IServer
    {
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
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void LogDebug(string message)
        {
            Console.WriteLine(message);
        }

        public void LogWarning(string message)
        {
            Console.WriteLine(message);
        }

        public void LogError(string message)
        {
            Console.WriteLine(message);
        }

        public void LogColored(string message)
        {
            Console.WriteLine(message);
        }

        public uint Hash(string hash)
        {
            throw new System.NotImplementedException();
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            Alt.Module.OnServerEvent(eventName, args);
        }

        private static MValue[] ConvertObjectsToMValues(object[] objects)
        {
            var length = objects.Length;
            var mValues = new MValue[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = MValue.CreateFromObject(objects[i]);
            }

            return mValues;
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, ConvertObjectsToMValues(args));
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            if (player == null)
            {
                foreach (var currPlayer in playerPool.GetAllEntities())
                {
                    currPlayer.Emit(eventName, args);
                }
            }
            else
            {
                player.PushEvent(eventName, args);
            }
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, ConvertObjectsToMValues(args));
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            var ptr = MockEntities.GetNextPtr();
            vehiclePool.Create(ptr, out var vehicle);
            vehicle.Position = pos;
            //TODO: apis missing for more properties from create
            MockEntities.Insert(vehicle);
            return vehicle;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            var ptr = MockEntities.GetNextPtr();
            checkpointPool.Create(ptr, out var checkpoint);
            if (checkpoint is MockCheckpoint mockCheckpoint)
            {
                mockCheckpoint.Position = pos;
                mockCheckpoint.CheckpointType = type;
                mockCheckpoint.Radius = radius;
                mockCheckpoint.Height = height;
                mockCheckpoint.Color = color;
            }

            MockEntities.Insert(checkpoint);
            return checkpoint;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            var ptr = MockEntities.GetNextPtr();
            blipPool.Create(ptr, out var blip);
            if (blip is MockBlip mockBlip)
            {
                mockBlip.Position = pos;
                mockBlip.BlipType = type;
            }

            MockEntities.Insert(blip);
            return blip;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            var ptr = MockEntities.GetNextPtr();
            blipPool.Create(ptr, out var blip);
            if (blip is MockBlip mockBlip)
            {
                mockBlip.BlipType = type;
                mockBlip.IsAttached = true;
                mockBlip.AttachedTo = entityAttach;
            }

            MockEntities.Insert(blip);
            return blip;
        }

        public void RemoveEntity(IEntity entity)
        {
            Alt.Module.OnEntityRemove(entity.NativePointer, entity.Type);
            MockEntities.Entities.Remove(entity.NativePointer);
        }
    }
}