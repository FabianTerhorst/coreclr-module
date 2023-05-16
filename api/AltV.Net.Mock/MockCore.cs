using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Enums;
using AltV.Net.Shared.Events;

namespace AltV.Net.Mock
{
    public class MockCore : ICore
    {
        ISharedPoolManager ISharedCore.PoolManager => PoolManager;
        public IPoolManager PoolManager { get; }
        public EventStateManager EventStateManager { get; }
        ISharedNativeResource ISharedCore.Resource => Resource;
        public IReadOnlyCollection<IPed> GetAllPeds()
        {
            throw new NotImplementedException();
        }

        ISharedBaseObject ISharedCore.GetBaseObjectById(BaseObjectType type, uint id)
        {
            return GetBaseObjectById(type, id);
        }
        public IntPtr NativePointer { get; }
        public string SdkVersion { get; }
        public string CApiVersion { get; }

        public ILibrary Library { get; }
        public INativeResourcePool NativeResourcePool { get; }

        private readonly INativeResourcePool nativeResourcePool;

        public int NetTime => 0;

        public string RootDirectory => "";

        public string Branch => "";

        public string Version => "";

        public INativeResource Resource => new NativeResource(null, IntPtr.Zero);

        internal MockCore(IntPtr nativePointer, IPoolManager poolManager,
            INativeResourcePool nativeResourcePool)
        {
            this.NativePointer = nativePointer;
            this.PoolManager = poolManager;
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
        public bool IsMainThread()
        {
            return true;
        }

        public ulong HashPassword(string password)
        {
            throw new System.NotImplementedException();
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
            //Alt.CoreImpl.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, ref MValue args)
        {
            var mValueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetList(ref args, ref mValueArray);
            //Alt.CoreImpl.OnClientEvent(player?.NativePointer ?? IntPtr.Zero, eventName, ref mValueArray);
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

        public void TriggerClientEventForAll(string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForSome(IPlayer[] clients, string eventName, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForSome(IPlayer[] clients, string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForSome(IPlayer[] clients, string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliable(IPlayer player, string eventName, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliable(IPlayer player, string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliable(IPlayer player, string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForAll(string eventName, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForAll(string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForAll(string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            var vehicle = PoolManager.Vehicle.Create(this, ptr, entityId);
            vehicle.Position = pos;
            if (vehicle is MockVehicle mockVehicle)
            {
                mockVehicle.Position = pos;
                mockVehicle.Rotation = rotation;
                mockVehicle.Model = model;
            }
            return vehicle;
        }

        public IPed CreatePed(uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            var ped = PoolManager.Ped.Create(this, ptr, entityId);
            ped.Position = pos;
            if (ped is MockPed mockPed)
            {
                mockPed.Position = pos;
                mockPed.Rotation = rotation;
                mockPed.Model = model;
            }
            return ped;
        }

        public IntPtr CreateVehicleEntity(out uint id, uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            id = entityId;
            return ptr;
        }

        public IntPtr CreatePedEntity(out uint id, uint model, Position pos, Rotation rotation)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            id = entityId;
            return ptr;
        }

        public IReadOnlyCollection<IPlayer> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IVehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IBlip> GetAllBlips()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<ICheckpoint> GetAllCheckpoints()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IVirtualEntity> GetAllVirtualEntities()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IVirtualEntityGroup> GetAllVirtualEntityGroups()
        {
            throw new NotImplementedException();
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color, uint streamingDistance)
        {
            var ptr = MockEntities.GetNextPtr(out var id);
            var checkpoint = PoolManager.Checkpoint.Create(this, ptr, id);
            if (checkpoint is MockCheckpoint mockCheckpoint)
            {
                mockCheckpoint.Position = pos;
                mockCheckpoint.CheckpointType = type;
                mockCheckpoint.Radius = radius;
                mockCheckpoint.Height = height;
                mockCheckpoint.Color = color;
            }
            return checkpoint;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            var ptr = MockEntities.GetNextPtr(out var id);
            var blip = PoolManager.Blip.Create(this, ptr, id);
            if (blip is MockBlip mockBlip)
            {
                mockBlip.Position = pos;
                mockBlip.BlipType = type;
            }
            return blip;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            var ptr = MockEntities.GetNextPtr(out var id);
            var blip = PoolManager.Blip.Create(this, ptr, id);
            if (blip is MockBlip mockBlip)
            {
                mockBlip.BlipType = type;
                mockBlip.IsAttached = true;
                mockBlip.AttachedTo = entityAttach;
            }
            return blip;
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            var ptr = MockEntities.GetNextPtr(out var id);
            var voiceChannel = PoolManager.VoiceChannel.Create(this, ptr, id);
            if (voiceChannel is MockVoiceChannel mockVoiceChannel)
            {
                mockVoiceChannel.IsSpatial = spatial;
                mockVoiceChannel.MaxDistance = maxDistance;
            }
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

        public IColShape CreateColShapePolygon(float minZ, float maxZ, Vector2[] points)
        {
            throw new NotImplementedException();
        }

        public void RemoveColShape(IColShape colShape)
        {
            throw new NotImplementedException();
        }

        public void RemoveBlip(IBlip blip)
        {
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
        }

        public void RemoveVoiceChannel(IVoiceChannel channel)
        {
        }

        public INativeResource GetResource(string name)
        {
            return new NativeResource(null, IntPtr.Zero);
        }

        public INativeResource GetResource(IntPtr resourcePointer)
        {
            return new NativeResource(null, IntPtr.Zero);
        }

        public void CreateMValueVector3(out MValueConst mValue, Position value)
        {
            throw new NotImplementedException();
        }

        public void CreateMValueVector2(out MValueConst mValue, Vector2 value)
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

        public IBaseObject GetBaseObjectById(BaseObjectType type, uint id)
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

        public bool IsMValueConvertible(Type type)
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

        public void CreateMValueBaseObject(out MValueConst mValue, ISharedBaseObject value)
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

        public void TriggerClientEventForAll(IntPtr eventNamePtr, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForAll(string eventName, MValueConst[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForAll(IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForAll(string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }

        public void TriggerClientEventForAll(IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }

        public ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height, Rgba color, uint streamingDistance)
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
        public void TriggerLocalEvent(string eventName, MValueConst[] args)
        {
            throw new NotImplementedException();
        }
        public void TriggerLocalEvent(IntPtr eventNamePtr, MValueConst[] args)
        {
            throw new NotImplementedException();
        }
        public void TriggerLocalEvent(string eventName, IntPtr[] args)
        {
            throw new NotImplementedException();
        }
        public void TriggerLocalEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            throw new NotImplementedException();
        }
        public void TriggerLocalEvent(IntPtr eventNamePtr, params object[] args)
        {
            throw new NotImplementedException();
        }
        public void TriggerLocalEvent(string eventName, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void SetPassword(string password)
        {
            throw new NotImplementedException();
        }

        public VehicleModelInfo GetVehicleModelInfo(uint hash)
        {
            throw new NotImplementedException();
        }
        public PedModelInfo? GetPedModelInfo(uint hash)
        {
            throw new NotImplementedException();
        }

        public void StopServer()
        {
            throw new NotImplementedException();
        }

        public bool IsDebug { get; }

        public bool FileExists(string path)
        {
            throw new NotImplementedException();
        }

        public string FileRead(string path)
        {
            throw new NotImplementedException();
        }

        public byte[] FileReadBinary(string path)
        {
            throw new NotImplementedException();
        }
        public IConfig GetServerConfig()
        {
            throw new NotImplementedException();
        }

        public void SetWorldProfiler(bool state)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetRegisteredClientEvents()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetRegisteredServerEvents()
        {
            throw new NotImplementedException();
        }

        public IBaseObject[] GetClosestEntities(Position position, int range, int dimension, int limit, EntityType allowedTypes)
        {
            throw new NotImplementedException();
        }

        public IBaseObject[] GetEntitiesInDimension(int dimension, EntityType allowedTypes)
        {
            throw new NotImplementedException();
        }

        public IBaseObject[] GetEntitiesInRange(Position position, int range, int dimension, EntityType allowedTypes)
        {
            throw new NotImplementedException();
        }

        public IntPtr CreateVirtualEntityEntity(out uint id, IVirtualEntityGroup group, Position position, uint streamingDistance, Dictionary<string, object> data)
        {
            throw new NotImplementedException();
        }

        public IntPtr CreateVirtualEntityGroupEntity(out uint id, uint streamingDistance)
        {
            throw new NotImplementedException();
        }

        public IntPtr CreateMarkerEntity(out uint id, IPlayer player, MarkerType type, Position pos, Rgba color)
        {
            throw new NotImplementedException();
        }

        public IBaseObject GetBaseObject(BaseObjectType type, uint id)
        {
            throw new NotImplementedException();
        }

        public string PtrToStringUtf8AndFree(nint str, int size)
        {
            throw new NotImplementedException();
        }
        public void RegisterMValueAdapter<T>(IMValueAdapter<T> adapter)
        {
            throw new NotImplementedException();
        }
        public bool ToMValue(object obj, Type type, out MValueConst mValue)
        {
            throw new NotImplementedException();
        }
        public bool FromMValue(in MValueConst mValue, Type type, out object obj)
        {
            throw new NotImplementedException();
        }
        public bool MValueFromObject(object obj, Type type, out object result)
        {
            throw new NotImplementedException();
        }
    }
}