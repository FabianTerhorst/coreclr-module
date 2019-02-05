using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        public static Server Instance { get; private set; }

        private IntPtr NativePointer { get; }

        internal IEntityPool EntityPool { get; }

        internal Server(IntPtr nativePointer, IEntityPool entityPool)
        {
            NativePointer = nativePointer;
            EntityPool = entityPool;
            Instance = this;
        }

        public void LogInfo(string message)
        {
            AltVNative.Server.Server_LogInfo(NativePointer, message);
        }

        public void LogDebug(string message)
        {
            AltVNative.Server.Server_LogDebug(NativePointer, message);
        }

        public void LogWarning(string message)
        {
            AltVNative.Server.Server_LogWarning(NativePointer, message);
        }

        public void LogError(string message)
        {
            AltVNative.Server.Server_LogError(NativePointer, message);
        }

        public void LogColored(string message)
        {
            AltVNative.Server.Server_LogColored(NativePointer, message);
        }

        public uint Hash(string hash)
        {
            return AltVNative.Server.Server_Hash(NativePointer, hash);
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerServerEvent(NativePointer, eventName, ref mValueList);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, ConvertObjectsToMValues(args));
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerClientEvent(NativePointer, player.NativePointer, eventName, ref mValueList);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, ConvertObjectsToMValues(args));
        }

        private static MValue[] ConvertObjectsToMValues(IEnumerable<object> objects)
        {
            return (from obj in objects
                select MValue.CreateFromObject(obj)
                into mValue
                where mValue.HasValue
                select mValue.Value).ToArray();
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            var vehicle = new Vehicle(AltVNative.Server.Server_CreateVehicle(NativePointer, model, pos, heading), this);
            EntityPool.Register(vehicle);
            return vehicle;
        }

        public bool RemoveEntity(IEntity entity)
        {
            if (!EntityPool.Remove(entity))
            {
                return false;
            }

            AltVNative.Server.Server_RemoveEntity(NativePointer, entity.NativePointer);
            return true;
        }
    }
}