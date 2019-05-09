using System;
using System.Runtime.InteropServices;
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

        private readonly IBaseObjectPool<IVoiceChannel> voiceChannelPool;

        internal MockServer(IntPtr nativePointer, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool)
        {
            this.nativePointer = nativePointer;
            this.baseBaseObjectPool = baseBaseObjectPool;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.voiceChannelPool = voiceChannelPool;
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

        public void LogInfo(IntPtr message)
        {
            Console.WriteLine(Marshal.PtrToStringUTF8(message));
        }

        public void LogDebug(IntPtr message)
        {
            Console.WriteLine(Marshal.PtrToStringUTF8(message));
        }

        public void LogWarning(IntPtr message)
        {
            Console.WriteLine(Marshal.PtrToStringUTF8(message));
        }

        public void LogError(IntPtr message)
        {
            Console.WriteLine(Marshal.PtrToStringUTF8(message));
        }

        public void LogColored(IntPtr message)
        {
            Console.WriteLine(Marshal.PtrToStringUTF8(message));
        }

        public uint Hash(string hash)
        {
            throw new System.NotImplementedException();
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            var mValue = MValue.Nil;
            AltNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValue);
            var mValueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetList(ref mValue, ref mValueArray);
            Alt.Module.OnServerEvent(eventName, ref mValueArray);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, MValue.CreateFromObjects(args));
        }

        public void TriggerServerEvent(string eventName, ref MValue args)
        {
            var mValueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetList(ref args, ref mValueArray);
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
            AltNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValue);
            var mValueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetList(ref mValue, ref mValueArray);
            Alt.Module.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, ref MValue args)
        {
            var mValueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetList(ref args, ref mValueArray);
            Alt.Module.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, MValue.CreateFromObjects(args));
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params MValue[] args)
        {
            TriggerServerEvent(Marshal.PtrToStringUTF8(eventNamePtr), args);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params object[] args)
        {
            TriggerServerEvent(Marshal.PtrToStringUTF8(eventNamePtr), args);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, ref MValue args)
        {
            TriggerServerEvent(Marshal.PtrToStringUTF8(eventNamePtr), ref args);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params MValue[] args)
        {
            TriggerClientEvent(player, Marshal.PtrToStringUTF8(eventNamePtr), args);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args)
        {
            TriggerClientEvent(player, Marshal.PtrToStringUTF8(eventNamePtr), args);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, ref MValue args)
        {
            TriggerClientEvent(player, Marshal.PtrToStringUTF8(eventNamePtr), ref args);
        }

        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr();
            vehiclePool.Create(ptr, MockEntities.Id, out var vehicle);
            vehicle.Position = pos;
            //TODO: apis missing for more properties from create
            MockEntities.Insert(vehicle);
            return vehicle;
        }

        public IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr();
            id = MockEntities.Id;
            return ptr;
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

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            var ptr = MockEntities.GetNextPtr();
            voiceChannelPool.Create(ptr, out var voiceChannel);
            if (voiceChannel is MockVoiceChannel mockVoiceChannel)
            {
                mockVoiceChannel.IsSpatial = spatial;
                mockVoiceChannel.MaxDistance = maxDistance;
            }

            MockEntities.Insert(voiceChannel);
            return voiceChannel;
        }

        public void RemoveEntity(IEntity entity)
        {
            switch (entity.Type)
            {
                case BaseObjectType.Vehicle:
                    RemoveVehicle((IVehicle) entity);
                    break;
            }
        }

        public void RemoveBlip(IBlip blip)
        {
            Alt.Module.OnRemoveBlip(blip.NativePointer);
            MockEntities.Entities.Remove(blip.NativePointer);
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            Alt.Module.OnRemoveCheckpoint(checkpoint.NativePointer);
            MockEntities.Entities.Remove(checkpoint.NativePointer);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Alt.Module.OnRemoveVehicle(vehicle.NativePointer);
            MockEntities.Entities.Remove(vehicle.NativePointer);
        }

        public void RemoveVoiceChannel(IVoiceChannel channel)
        {
            Alt.Module.OnRemoveVoiceChannel(channel.NativePointer);
            MockEntities.Entities.Remove(channel.NativePointer);
        }

        public ServerNativeResource GetResource(string name)
        {
            return new ServerNativeResource(IntPtr.Zero);
        }
    }
}