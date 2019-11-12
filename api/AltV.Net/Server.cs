using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        public delegate bool EventCallback(IntPtr eventPointer, IntPtr userData);

        public delegate void TickCallback(IntPtr userData);

        public delegate void CommandCallback(StringView cmd, StringViewArray args, IntPtr userData);

        public readonly IntPtr NativePointer;

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

        public void TriggerServerEvent(string eventName, params MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params MValueConst[] args)
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

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params MValueConst[] args)
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

        public void TriggerClientEvent(IPlayer player, string eventName, params MValueConst[] args)
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
            ushort id = default;
            var ptr = AltNative.Server.Server_CreateVehicle(NativePointer, model, pos, rotation, ref id);
            return vehiclePool.Get(ptr, out var vehicle) ? vehicle : null;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            var ptr = AltNative.Server.Server_CreateCheckpoint(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, pos, radius, height, color);
            return checkpointPool.Get(ptr, out var checkpoint) ? checkpoint : null;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            var ptr = AltNative.Server.Server_CreateBlip(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                type, pos);
            return blipPool.Get(ptr, out var blip) ? blip : null;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            var ptr = AltNative.Server.Server_CreateBlipAttached(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, entityAttach.NativePointer);
            return blipPool.Get(ptr, out var blip) ? blip : null;
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            var ptr = AltNative.Server.Server_CreateVoiceChannel(NativePointer,
                spatial, maxDistance);
            return voiceChannelPool.Get(ptr, out var voiceChannel) ? voiceChannel : null;
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            var ptr = AltNative.Server.Server_CreateColShapeCylinder(NativePointer, pos, radius, height);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            var ptr = AltNative.Server.Server_CreateColShapeSphere(NativePointer, pos, radius);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            var ptr = AltNative.Server.Server_CreateColShapeCircle(NativePointer, pos, radius);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            var ptr = AltNative.Server.Server_CreateColShapeCube(NativePointer, pos, pos2);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeRectangle(Position pos, Position pos2)
        {
            var ptr = AltNative.Server.Server_CreateColShapeRectangle(NativePointer, pos, pos2);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public void RemoveBlip(IBlip blip)
        {
            if (blip.Exists)
            {
                AltNative.Server.Server_DestroyBlip(NativePointer, blip.NativePointer);
            }
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            if (checkpoint.Exists)
            {
                AltNative.Server.Server_DestroyCheckpoint(NativePointer, checkpoint.NativePointer);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
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

        public void CreateMValueNil(out MValueConst mValue)
        {
            mValue = new MValueConst(MValueConst.Type.NIL, AltNative.Server.Core_CreateMValueNil(NativePointer));
        }

        public void CreateMValueBool(out MValueConst mValue, bool value)
        {
            mValue = new MValueConst(MValueConst.Type.BOOL,
                AltNative.Server.Core_CreateMValueBool(NativePointer, value));
        }

        public void CreateMValueInt(out MValueConst mValue, long value)
        {
            mValue = new MValueConst(MValueConst.Type.INT, AltNative.Server.Core_CreateMValueInt(NativePointer, value));
        }

        public void CreateMValueUInt(out MValueConst mValue, ulong value)
        {
            mValue = new MValueConst(MValueConst.Type.UINT,
                AltNative.Server.Core_CreateMValueUInt(NativePointer, value));
        }

        public void CreateMValueDouble(out MValueConst mValue, double value)
        {
            mValue = new MValueConst(MValueConst.Type.DOUBLE,
                AltNative.Server.Core_CreateMValueDouble(NativePointer, value));
        }

        public void CreateMValueString(out MValueConst mValue, string value)
        {
            var valuePtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
            mValue = new MValueConst(MValueConst.Type.STRING,
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

            mValue = new MValueConst(MValueConst.Type.LIST,
                AltNative.Server.Core_CreateMValueList(NativePointer, pointers, size));
        }

        public void CreateMValueDict(out MValueConst mValue, string[] keys, MValueConst[] val, ulong size)
        {
            var pointers = new IntPtr[size];
            for (ulong i = 0; i < size; i++)
            {
                pointers[i] = val[i].nativePointer;
            }

            mValue = new MValueConst(MValueConst.Type.DICT,
                AltNative.Server.Core_CreateMValueDict(NativePointer, keys, pointers, size));
        }

        public void CreateMValueCheckpoint(out MValueConst mValue, ICheckpoint value)
        {
            mValue = new MValueConst(MValueConst.Type.ENTITY,
                AltNative.Server.Core_CreateMValueCheckpoint(NativePointer, value.NativePointer));
        }

        public void CreateMValueBlip(out MValueConst mValue, IBlip value)
        {
            mValue = new MValueConst(MValueConst.Type.ENTITY,
                AltNative.Server.Core_CreateMValueBlip(NativePointer, value.NativePointer));
        }

        public void CreateMValueVoiceChannel(out MValueConst mValue, IVoiceChannel value)
        {
            mValue = new MValueConst(MValueConst.Type.ENTITY,
                AltNative.Server.Core_CreateMValueVoiceChannel(NativePointer, value.NativePointer));
        }

        public void CreateMValuePlayer(out MValueConst mValue, IPlayer value)
        {
            mValue = new MValueConst(MValueConst.Type.ENTITY,
                AltNative.Server.Core_CreateMValuePlayer(NativePointer, value.NativePointer));
        }

        public void CreateMValueVehicle(out MValueConst mValue, IVehicle value)
        {
            mValue = new MValueConst(MValueConst.Type.ENTITY,
                AltNative.Server.Core_CreateMValueVehicle(NativePointer, value.NativePointer));
        }

        public void CreateMValueFunction(out MValueConst mValue, IntPtr value)
        {
            mValue = new MValueConst(MValueConst.Type.FUNCTION,
                AltNative.Server.Core_CreateMValueFunction(NativePointer, value));
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
                case Net.Function function:
                    CreateMValueFunction(out mValue,
                        Alt.Server.Resource.CSharpResourceImpl.CreateInvoker(function.call));
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
                    var posValues = new MValueConst[3];
                    MValueConst positionMValue;
                    CreateMValueDouble(out positionMValue, position.X);
                    posValues[0] = positionMValue;
                    CreateMValueDouble(out positionMValue, position.Y);
                    posValues[1] = positionMValue;
                    CreateMValueDouble(out positionMValue, position.Z);
                    posValues[2] = positionMValue;
                    var posKeys = new string[3];
                    posKeys[0] = "x";
                    posKeys[1] = "y";
                    posKeys[2] = "z";
                    CreateMValueDict(out mValue, posKeys, posValues, 3);
                    for (int j = 0, dictLength = posValues.Length; j < dictLength; j++)
                    {
                        posValues[j].Dispose();
                    }

                    return;
                case Rotation rotation:
                    var rotValues = new MValueConst[3];
                    MValueConst rotationMValue;
                    CreateMValueDouble(out rotationMValue, rotation.Roll);
                    rotValues[0] = rotationMValue;
                    CreateMValueDouble(out rotationMValue, rotation.Pitch);
                    rotValues[1] = rotationMValue;
                    CreateMValueDouble(out rotationMValue, rotation.Yaw);
                    rotValues[2] = rotationMValue;
                    var rotKeys = new string[3];
                    rotKeys[0] = "roll";
                    rotKeys[1] = "pitch";
                    rotKeys[2] = "yaw";
                    CreateMValueDict(out mValue, rotKeys, rotValues, 3);
                    for (int j = 0, dictLength = rotValues.Length; j < dictLength; j++)
                    {
                        rotValues[j].Dispose();
                    }

                    return;
                case short value:
                    CreateMValueInt(out mValue, value);
                    return;
                case ushort value:
                    CreateMValueUInt(out mValue, value);
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
    }
}