using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockServer : IServer
    {
        private readonly IntPtr nativePointer;

        private readonly IBaseBaseObjectPool baseBaseObjectPool;
        
        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        internal MockServer(IntPtr nativePointer, IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool)
        {
            this.nativePointer = nativePointer;
            this.baseBaseObjectPool = baseBaseObjectPool;
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
            var mValue = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValue);
            var mValueArray = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetList(ref mValue, ref mValueArray);
            Alt.Module.OnServerEvent(eventName, ref mValueArray);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, MValue.CreateFromObjects(args));
        }

        public void TriggerServerEvent(string eventName, ref MValue args)
        {
            var mValueArray = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetList(ref args, ref mValueArray);
            Alt.Module.OnServerEvent(eventName, ref mValueArray);
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

            var mValue = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValue);
            var mValueArray = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetList(ref mValue, ref mValueArray);
            Alt.Module.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, ref MValue args)
        {
            var mValueArray = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetList(ref args, ref mValueArray);
            Alt.Module.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, MValue.CreateFromObjects(args));
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            var ptr = MockEntities.GetNextPtr();
            vehiclePool.Create(ptr, MockEntities.Id, out var vehicle);
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

        public void RemoveBlip(IBlip blip)
        {
            Alt.Module.OnEntityRemove(blip.NativePointer, blip.Type);
            MockEntities.Entities.Remove(blip.NativePointer);
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            Alt.Module.OnEntityRemove(checkpoint.NativePointer, checkpoint.Type);
            MockEntities.Entities.Remove(checkpoint.NativePointer);
        }

        void IServer.RemoveVehicle(IVehicle vehicle)
        {
            Alt.Module.OnEntityRemove(vehicle.NativePointer, vehicle.Type);
            MockEntities.Entities.Remove(vehicle.NativePointer);
        }

        public ServerNativeResource GetResource(string name)
        {
            return new ServerNativeResource(IntPtr.Zero);
        }
    }
}