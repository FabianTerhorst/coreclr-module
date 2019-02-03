using System;
using System.Collections.Generic;
using System.Linq;
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
            return (from obj in objects
                select MValue.CreateFromObject(obj)
                into mValue
                where mValue.HasValue
                select mValue.Value).ToArray();
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