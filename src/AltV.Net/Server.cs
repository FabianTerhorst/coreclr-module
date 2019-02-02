using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        private IntPtr NativePointer { get; }

        private IEntityPool EntityPool { get; }

        internal Server(IntPtr nativePointer, IEntityPool entityPool)
        {
            NativePointer = nativePointer;
            EntityPool = entityPool;
        }

        public void LogInfo(string message)
        {
            Alt.Server.Server_LogInfo(NativePointer, message);
        }

        public void LogDebug(string message)
        {
            Alt.Server.Server_LogDebug(NativePointer, message);
        }

        public void LogWarning(string message)
        {
            Alt.Server.Server_LogWarning(NativePointer, message);
        }

        public void LogError(string message)
        {
            Alt.Server.Server_LogError(NativePointer, message);
        }

        public void LogColored(string message)
        {
            Alt.Server.Server_LogColored(NativePointer, message);
        }

        public uint Hash(string hash)
        {
            return Alt.Server.Server_Hash(NativePointer, hash);
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            Alt.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            Alt.Server.Server_TriggerServerEvent(NativePointer, eventName, ref mValueList);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, ConvertObjectsToMValues(args));
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            Alt.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            Alt.Server.Server_TriggerClientEvent(NativePointer, player.NativePointer, eventName, ref mValueList);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, ConvertObjectsToMValues(args));
        }

        private static MValue[] ConvertObjectsToMValues(IEnumerable<object> objects)
        {
            var mValueArgs = new List<MValue>();
            foreach (var obj in objects)
            {
                switch (obj)
                {
                    case IntPtr entityPointer:
                        mValueArgs.Add(MValue.Create(entityPointer));
                        break;
                    case IEntity entity:
                        mValueArgs.Add(MValue.Create(entity.NativePointer));
                        break;
                    case bool value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case int value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case uint value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case long value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case ulong value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case double value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case string value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case MValue[] value:
                        mValueArgs.Add(MValue.Create(value));
                        break;
                    case Dictionary<string, object> value:
                        var dictMValues = new List<MValue>();
                        foreach (var dictValue in value.Values)
                        {
                            var dictMValue = MValue.CreateFromObject(dictValue);
                            if (!dictMValue.HasValue) continue;
                            dictMValues.Add(dictMValue.Value);
                        }

                        mValueArgs.Add(MValue.Create(dictMValues.ToArray(), value.Keys.ToArray()));
                        break;
                    case Invoker value:
                        mValueArgs.Add(MValue.CreateFunction(value));
                        break;
                    case MValue value:
                        mValueArgs.Add(value);
                        break;
                    case object[] value:
                        var mValue = MValue.CreateFromObject(value);
                        if (mValue.HasValue)
                        {
                            mValueArgs.Add(mValue.Value);
                        }

                        break;
                }
            }

            return mValueArgs.ToArray();
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            var vehicle = new Vehicle(Alt.Server.Server_CreateVehicle(NativePointer, model, pos, heading), EntityPool);
            EntityPool.Register(vehicle);
            return vehicle;
        }

        public void RemoveEntity(IEntity entity)
        {
            EntityPool.Remove(entity);
            Alt.Server.Server_RemoveEntity(NativePointer, entity.NativePointer);
        }
    }
}