using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockServer : IServer
    {
        public IntPtr NativePointer { get; }

        private readonly IBaseBaseObjectPool baseBaseObjectPool;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        private readonly IBaseObjectPool<IVoiceChannel> voiceChannelPool;

        private readonly INativeResourcePool nativeResourcePool;

        public int NetTime => 0;

        public string RootDirectory => "";

        public string Branch => "";

        public string Version => "";

        public INativeResource Resource => new NativeResource(IntPtr.Zero, IntPtr.Zero);

        internal MockServer(IntPtr nativePointer, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            INativeResourcePool nativeResourcePool)
        {
            this.NativePointer = nativePointer;
            this.baseBaseObjectPool = baseBaseObjectPool;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.voiceChannelPool = voiceChannelPool;
            this.nativeResourcePool = nativeResourcePool;
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

        /*public void TriggerClientEvent(IPlayer player, string eventName, params MValueConst[] args)
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
            //Alt.Module.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, ref MValue args)
        {
            var mValueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetList(ref args, ref mValueArray);
            //Alt.Module.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
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
        }*/

        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            vehiclePool.Create(ptr, entityId, out var vehicle);
            vehicle.Position = pos;
            if (vehicle is MockVehicle mockVehicle)
            {
                mockVehicle.Position = pos;
                mockVehicle.Rotation = rotation;
                mockVehicle.Model = model;
            }
            Alt.Module.OnCreateVehicle(ptr, entityId);
            return vehicle;
        }

        public IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            id = entityId;
            Alt.Module.OnCreateVehicle(ptr, entityId);
            return ptr;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            var ptr = MockEntities.GetNextPtrNoId();
            checkpointPool.Create(ptr, out var checkpoint);
            if (checkpoint is MockCheckpoint mockCheckpoint)
            {
                mockCheckpoint.Position = pos;
                mockCheckpoint.CheckpointType = type;
                mockCheckpoint.Radius = radius;
                mockCheckpoint.Height = height;
                mockCheckpoint.Color = color;
            }
            Alt.Module.OnCreateCheckpoint(ptr);
            return checkpoint;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            var ptr = MockEntities.GetNextPtrNoId();
            blipPool.Create(ptr, out var blip);
            if (blip is MockBlip mockBlip)
            {
                mockBlip.Position = pos;
                mockBlip.BlipType = type;
            }
            Alt.Module.OnCreateBlip(ptr);
            return blip;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            var ptr = MockEntities.GetNextPtrNoId();
            blipPool.Create(ptr, out var blip);
            if (blip is MockBlip mockBlip)
            {
                mockBlip.BlipType = type;
                mockBlip.IsAttached = true;
                mockBlip.AttachedTo = entityAttach;
            }
            Alt.Module.OnCreateBlip(ptr);
            return blip;
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            var ptr = MockEntities.GetNextPtrNoId();
            voiceChannelPool.Create(ptr, out var voiceChannel);
            if (voiceChannel is MockVoiceChannel mockVoiceChannel)
            {
                mockVoiceChannel.IsSpatial = spatial;
                mockVoiceChannel.MaxDistance = maxDistance;
            }
            Alt.Module.OnCreateVoiceChannel(ptr);
            return voiceChannel;
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            throw new NotImplementedException();
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            throw new NotImplementedException();
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            throw new NotImplementedException();
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            throw new NotImplementedException();
        }

        public IColShape CreateColShapeRectangle(Position pos, Position pos2)
        {
            throw new NotImplementedException();
        }

        public void RemoveColShape(IColShape colShape)
        {
            throw new NotImplementedException();
        }

        public void RemoveBlip(IBlip blip)
        {
            Alt.Module.OnRemoveBlip(blip.NativePointer);
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            Alt.Module.OnRemoveCheckpoint(checkpoint.NativePointer); 
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Alt.Module.OnVehicleRemove(vehicle.NativePointer);
            Alt.Module.OnRemoveVehicle(vehicle.NativePointer);
        }

        public void RemoveVoiceChannel(IVoiceChannel channel)
        {
            Alt.Module.OnRemoveVoiceChannel(channel.NativePointer);
        }

        public INativeResource GetResource(string name)
        {
            return new NativeResource(IntPtr.Zero, IntPtr.Zero);
        }

        public INativeResource GetResource(IntPtr resourcePointer)
        {
            return new NativeResource(IntPtr.Zero, IntPtr.Zero);
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            return new List<IPlayer>();
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            return new List<IVehicle>();
        }

        public void CreateMValueVector3(out MValueConst mValue, Position value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueRgba(out MValueConst mValue, Rgba value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueByteArray(out MValueConst mValue, byte[] value)
        {
            throw new NotImplementedException();
        }

        public IEntity GetEntityById(ushort id)
        {
            throw new NotImplementedException();
        }

        public void StartResource(string name)
        {
            throw new NotImplementedException();
        }

        public void StopResource(string name)
        {
            throw new NotImplementedException();
        }

        public void RestartResource(string name)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueNil(out MValueConst mValue)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueBool(out MValueConst mValue, bool value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueInt(out MValueConst mValue, long value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueUInt(out MValueConst mValue, ulong value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueDouble(out MValueConst mValue, double value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueString(out MValueConst mValue, string value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueList(out MValueConst mValue, MValueConst[] val, ulong size)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueDict(out MValueConst mValue, string[] keys, MValueConst[] val, ulong size)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueCheckpoint(out MValueConst mValue, ICheckpoint value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueBlip(out MValueConst mValue, IBlip value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueVoiceChannel(out MValueConst mValue, IVoiceChannel value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValuePlayer(out MValueConst mValue, IPlayer value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueVehicle(out MValueConst mValue, IVehicle value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueFunction(out MValueConst mValue, IntPtr value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValue(out MValueConst mValue, object obj)
        {
            throw new NotImplementedException();
        }

        public void CreateMValues(MValueConst[] mValues, object[] objects)
        {
            throw new NotImplementedException();
        }

        public void TriggerServerEvent(string eventName, params MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerServerEvent(string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEvent(IPlayer player, string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height, Rgba color)
        {
            throw new NotImplementedException();
        }

        public IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z)
        {
            throw new NotImplementedException();
        }

        public void SetMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool HasMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public void GetMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void SetSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool HasSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public bool IsDebug { get; }
    }
}