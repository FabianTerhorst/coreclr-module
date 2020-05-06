using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Exceptions;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        public delegate bool EventCallback(IntPtr eventPointer, IntPtr userData);

        public delegate void TickCallback(IntPtr userData);

        public delegate void CommandCallback(StringView cmd, StringViewArray args, IntPtr userData);

        public IntPtr NativePointer { get; }

        private readonly IBaseBaseObjectPool baseBaseObjectPool;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        private readonly IBaseObjectPool<IVoiceChannel> voiceChannelPool;

        private readonly IBaseObjectPool<IColShape> colShapePool;

        private readonly INativeResourcePool nativeResourcePool;

        public int NetTime => AltNative.Server.Server_GetNetTime(NativePointer);

        private string rootDirectory;

        public string RootDirectory
        {
            get
            {
                if (rootDirectory != null) return rootDirectory;
                var ptr = IntPtr.Zero;
                AltNative.Server.Server_GetRootDirectory(NativePointer, ref ptr);
                rootDirectory = Marshal.PtrToStringUTF8(ptr);

                return rootDirectory;
            }
        }

        public INativeResource Resource { get; }

        public Server(IntPtr nativePointer, INativeResource resource, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool)
        {
            NativePointer = nativePointer;
            this.baseBaseObjectPool = baseBaseObjectPool;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.voiceChannelPool = voiceChannelPool;
            this.colShapePool = colShapePool;
            this.nativeResourcePool = nativeResourcePool;
            Resource = resource;
        }

        public void LogInfo(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogInfo(NativePointer, messagePtr);
        }

        public void LogDebug(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogDebug(NativePointer, messagePtr);
        }

        public void LogWarning(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogWarning(NativePointer, messagePtr);
        }

        public void LogError(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogError(NativePointer, messagePtr);
        }

        public void LogColored(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogColored(NativePointer, messagePtr);
        }

        public void LogInfo(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogInfo(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogDebug(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogDebug(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogWarning(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogWarning(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogError(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogError(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogColored(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogColored(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public uint Hash(string stringToHash)
        {
            //return AltVNative.Server.Server_Hash(NativePointer, hash);
            if (string.IsNullOrEmpty(stringToHash)) return 0;

            var characters = Encoding.UTF8.GetBytes(stringToHash.ToLower());

            uint hash = 0;

            foreach (var c in characters)
            {
                hash += c;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }

        public void TriggerServerEvent(string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            AltNative.Server.Server_TriggerServerEvent(NativePointer, eventNamePtr, mValuePointers, size);
        }

        public void TriggerServerEvent(string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            AltNative.Server.Server_TriggerServerEvent(NativePointer, eventNamePtr, args, args.Length);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEvent(eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEvent(eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            AltNative.Server.Server_TriggerClientEvent(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                eventNamePtr,
                mValuePointers, args.Length);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEvent(player, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, IntPtr[] args)
        {
            AltNative.Server.Server_TriggerClientEvent(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                eventNamePtr, args, args.Length);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEvent(player, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEvent(player, eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEvent(player, eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            CheckIfCallIsValid();
            ushort id = default;
            var ptr = AltNative.Server.Server_CreateVehicle(NativePointer, model, pos, rotation, ref id);
            return vehiclePool.Get(ptr, out var vehicle) ? vehicle : null;
        }

        public ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height,
            Rgba color)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateCheckpoint(NativePointer, type, pos, radius, height, color);
            return checkpointPool.Get(ptr, out var checkpoint) ? checkpoint : null;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateBlip(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                type, pos);
            return blipPool.Get(ptr, out var blip) ? blip : null;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateBlipAttached(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, entityAttach.NativePointer);
            return blipPool.Get(ptr, out var blip) ? blip : null;
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateVoiceChannel(NativePointer,
                spatial, maxDistance);
            return voiceChannelPool.Get(ptr, out var voiceChannel) ? voiceChannel : null;
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateColShapeCylinder(NativePointer, pos, radius, height);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateColShapeSphere(NativePointer, pos, radius);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateColShapeCircle(NativePointer, pos, radius);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateColShapeCube(NativePointer, pos, pos2);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z)
        {
            CheckIfCallIsValid();
            var ptr = AltNative.Server.Server_CreateColShapeRectangle(NativePointer, x1, y1, x2, y2, z);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public void RemoveBlip(IBlip blip)
        {
            CheckIfCallIsValid();
            if (blip.Exists)
            {
                AltNative.Server.Server_DestroyBlip(NativePointer, blip.NativePointer);
            }
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            CheckIfCallIsValid();
            if (checkpoint.Exists)
            {
                AltNative.Server.Server_DestroyCheckpoint(NativePointer, checkpoint.NativePointer);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            CheckIfCallIsValid();
            if (vehicle.Exists)
            {
                AltNative.Server.Server_DestroyVehicle(NativePointer, vehicle.NativePointer);
            }
        }

        public void RemoveVoiceChannel(IVoiceChannel channel)
        {
            if (channel.Exists)
            {
                AltNative.Server.Server_DestroyVoiceChannel(NativePointer, channel.NativePointer);
            }
        }

        public void RemoveColShape(IColShape colShape)
        {
            CheckIfCallIsValid();
            if (colShape.Exists)
            {
                AltNative.Server.Server_DestroyColShape(NativePointer, colShape.NativePointer);
            }
        }

        public INativeResource GetResource(string name)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            var resourcePointer = AltNative.Server.Server_GetResource(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return !nativeResourcePool.GetOrCreate(NativePointer, resourcePointer, out var nativeResource)
                ? null
                : nativeResource;
        }

        public INativeResource GetResource(IntPtr resourcePointer)
        {
            return !nativeResourcePool.GetOrCreate(NativePointer, resourcePointer, out var nativeResource)
                ? null
                : nativeResource;
        }

        public IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation)
        {
            id = default;
            return AltNative.Server.Server_CreateVehicle(NativePointer, model, pos, rotation, ref id);
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            var playerCount = AltNative.Server.Server_GetPlayerCount(NativePointer);
            var pointers = new IntPtr[playerCount];
            AltNative.Server.Server_GetPlayers(NativePointer, pointers, playerCount);
            foreach (var playerPointer in pointers)
            {
                if (playerPool.GetOrCreate(playerPointer, out var vehicle))
                {
                    yield return vehicle;
                }
            }
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            var vehicleCount = AltNative.Server.Server_GetVehicleCount(NativePointer);
            var pointers = new IntPtr[vehicleCount];
            AltNative.Server.Server_GetVehicles(NativePointer, pointers, vehicleCount);
            foreach (var vehiclePointer in pointers)
            {
                if (vehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
                {
                    yield return vehicle;
                }
            }
        }

        public IEntity GetEntityById(ushort id)
        {
            var type = (byte) BaseObjectType.Undefined;
            var entityPointer = AltNative.Server.Server_GetEntityById(NativePointer, id, ref type);
            if (entityPointer == IntPtr.Zero) return null;
            switch (type)
            {
                case (byte) BaseObjectType.Player:
                    return playerPool.GetOrCreate(entityPointer, out var player) ? player : null;
                case (byte) BaseObjectType.Vehicle:
                    return vehiclePool.GetOrCreate(entityPointer, out var vehicle) ? vehicle : null;
                default:
                    return null;
            }
        }

        public void StartResource(string name)
        {
            var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            AltNative.Server.Server_StartResource(NativePointer, namePtr);
            Marshal.FreeHGlobal(namePtr);
        }

        public void StopResource(string name)
        {
            var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            AltNative.Server.Server_StopResource(NativePointer, namePtr);
            Marshal.FreeHGlobal(namePtr);
        }

        public void RestartResource(string name)
        {
            var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            AltNative.Server.Server_RestartResource(NativePointer, namePtr);
            Marshal.FreeHGlobal(namePtr);
        }
        
        public void GetMetaData(string key, out MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(AltNative.Server.Server_GetMetaData(NativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }

        public void SetMetaData(string key, object value)
        {
            CreateMValue(out var mValue, value);
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Server.Server_SetMetaData(NativePointer, stringPtr, mValue.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
            mValue.Dispose();
        }

        public bool HasMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var result = AltNative.Server.Server_HasMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result;
        }

        public void DeleteMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Server.Server_DeleteMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }
        
        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(AltNative.Server.Server_GetSyncedMetaData(NativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }

        public void SetSyncedMetaData(string key, object value)
        {
            CreateMValue(out var mValue, value);
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Server.Server_SetSyncedMetaData(NativePointer, stringPtr, mValue.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
            mValue.Dispose();
        }

        public bool HasSyncedMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var result = AltNative.Server.Server_HasSyncedMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result;
        }

        public void DeleteSyncedMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Server.Server_DeleteSyncedMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }

        public void CreateMValueNil(out MValueConst mValue)
        {
            mValue = new MValueConst(MValueConst.Type.Nil, AltNative.Server.Core_CreateMValueNil(NativePointer));
        }

        public void CreateMValueBool(out MValueConst mValue, bool value)
        {
            mValue = new MValueConst(MValueConst.Type.Bool,
                AltNative.Server.Core_CreateMValueBool(NativePointer, value));
        }

        public void CreateMValueInt(out MValueConst mValue, long value)
        {
            mValue = new MValueConst(MValueConst.Type.Int, AltNative.Server.Core_CreateMValueInt(NativePointer, value));
        }

        public void CreateMValueUInt(out MValueConst mValue, ulong value)
        {
            mValue = new MValueConst(MValueConst.Type.Uint,
                AltNative.Server.Core_CreateMValueUInt(NativePointer, value));
        }

        public void CreateMValueDouble(out MValueConst mValue, double value)
        {
            mValue = new MValueConst(MValueConst.Type.Double,
                AltNative.Server.Core_CreateMValueDouble(NativePointer, value));
        }

        public void CreateMValueString(out MValueConst mValue, string value)
        {
            var valuePtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
            mValue = new MValueConst(MValueConst.Type.String,
                AltNative.Server.Core_CreateMValueString(NativePointer, valuePtr));
            Marshal.FreeHGlobal(valuePtr);
        }

        public void CreateMValueList(out MValueConst mValue, MValueConst[] val, ulong size)
        {
            var pointers = new IntPtr[size];
            for (ulong i = 0; i < size; i++)
            {
                pointers[i] = val[i].nativePointer;
            }

            mValue = new MValueConst(MValueConst.Type.List,
                AltNative.Server.Core_CreateMValueList(NativePointer, pointers, size));
        }

        public void CreateMValueDict(out MValueConst mValue, string[] keys, MValueConst[] val, ulong size)
        {
            var pointers = new IntPtr[size];
            for (ulong i = 0; i < size; i++)
            {
                pointers[i] = val[i].nativePointer;
            }

            mValue = new MValueConst(MValueConst.Type.Dict,
                AltNative.Server.Core_CreateMValueDict(NativePointer, keys, pointers, size));
        }

        public void CreateMValueCheckpoint(out MValueConst mValue, ICheckpoint value)
        {
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValueCheckpoint(NativePointer, value.NativePointer));
        }

        public void CreateMValueBlip(out MValueConst mValue, IBlip value)
        {
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValueBlip(NativePointer, value.NativePointer));
        }

        public void CreateMValueVoiceChannel(out MValueConst mValue, IVoiceChannel value)
        {
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValueVoiceChannel(NativePointer, value.NativePointer));
        }

        public void CreateMValuePlayer(out MValueConst mValue, IPlayer value)
        {
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValuePlayer(NativePointer, value.NativePointer));
        }

        public void CreateMValueVehicle(out MValueConst mValue, IVehicle value)
        {
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValueVehicle(NativePointer, value.NativePointer));
        }

        public void CreateMValueFunction(out MValueConst mValue, IntPtr value)
        {
            mValue = new MValueConst(MValueConst.Type.Function,
                AltNative.Server.Core_CreateMValueFunction(NativePointer, value));
        }

        public void CreateMValueVector3(out MValueConst mValue, Position value)
        {
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValueVector3(NativePointer, value));
        }

        public void CreateMValueRgba(out MValueConst mValue, Rgba value)
        {
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValueRgba(NativePointer, value));
        }

        public void CreateMValueByteArray(out MValueConst mValue, byte[] value)
        {
            var size = value.Length;
            var dataPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(value, 0, dataPtr, size);
            mValue = new MValueConst(MValueConst.Type.Entity,
                AltNative.Server.Core_CreateMValueByteArray(NativePointer, (ulong) size, dataPtr));
            Marshal.FreeHGlobal(dataPtr);
        }

        public void CreateMValue(out MValueConst mValue, object obj)
        {
            if (obj == null)
            {
                mValue = MValueConst.Nil;
                return;
            }

            int i;

            string[] dictKeys;
            MValueConst[] dictValues;
            MValueWriter2 writer;

            switch (obj)
            {
                case IPlayer player:
                    CreateMValuePlayer(out mValue, player);
                    return;
                case IVehicle vehicle:
                    CreateMValueVehicle(out mValue, vehicle);
                    return;
                case IBlip blip:
                    CreateMValueBlip(out mValue, blip);
                    return;
                case ICheckpoint checkpoint:
                    CreateMValueCheckpoint(out mValue, checkpoint);
                    return;
                case bool value:
                    CreateMValueBool(out mValue, value);
                    return;
                case int value:
                    CreateMValueInt(out mValue, value);
                    return;
                case uint value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case long value:
                    CreateMValueInt(out mValue, value);
                    return;
                case ulong value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case double value:
                    CreateMValueDouble(out mValue, value);
                    return;
                case float value:
                    CreateMValueDouble(out mValue, value);
                    return;
                case string value:
                    CreateMValueString(out mValue, value);
                    return;
                case MValueConst value:
                    mValue = value;
                    return;
                case MValueConst[] value:
                    CreateMValueList(out mValue, value, (ulong) value.Length);
                    return;
                case Invoker value:
                    CreateMValueFunction(out mValue, value.NativePointer);
                    return;
                case MValueFunctionCallback value:
                    CreateMValueFunction(out mValue, Alt.Server.Resource.CSharpResourceImpl.CreateInvoker(value));
                    return;
                case Function function:
                    CreateMValueFunction(out mValue,
                        Alt.Server.Resource.CSharpResourceImpl.CreateInvoker(function.Call));
                    return;
                case byte[] byteArray:
                    CreateMValueByteArray(out mValue, byteArray);
                    return;
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            mValue = MValueConst.Nil;
                            return;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }

                    CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }

                    return;
                case ICollection collection:
                    var length = (ulong) collection.Count;
                    var listValues = new MValueConst[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        CreateMValue(out var elementMValue, value);
                        listValues[i++] = elementMValue;
                    }

                    CreateMValueList(out mValue, listValues, length);
                    for (ulong j = 0; j < length; j++)
                    {
                        listValues[j].Dispose();
                    }

                    return;
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }

                    CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }

                    return;
                case IWritable writable:
                    writer = new MValueWriter2();
                    writable.OnWrite(writer);
                    writer.ToMValue(out mValue);
                    return;
                case IMValueConvertible convertible:
                    writer = new MValueWriter2();
                    convertible.GetAdapter().ToMValue(obj, writer);
                    writer.ToMValue(out mValue);
                    return;
                case Position position:
                    CreateMValueVector3(out mValue, position);
                    return;
                case Rotation rotation:
                    CreateMValueVector3(out mValue, rotation);
                    return;
                case Rgba rgba:
                    CreateMValueRgba(out mValue, rgba);
                    return;
                case short value:
                    CreateMValueInt(out mValue, value);
                    return;
                case ushort value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case Vector3 position:
                    CreateMValueVector3(out mValue, position);
                    return;
                default:
                    Alt.Log("can't convert type:" + obj.GetType());
                    mValue = MValueConst.Nil;
                    return;
            }
        }

        public void CreateMValues(MValueConst[] mValues, object[] objects)
        {
            for (int i = 0, length = objects.Length; i < length; i++)
            {
                CreateMValue(out var mValue, objects[i]);
                mValues[i] = mValue;
            }
        }
        
        [Conditional("DEBUG")]
        public void CheckIfCallIsValid([CallerMemberName] string callerName = "")
        {
            if (Alt.Module.IsMainThread()) return;
            throw new IllegalThreadException(this, callerName);
        }
    }
}