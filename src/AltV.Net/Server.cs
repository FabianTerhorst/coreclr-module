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

        private readonly IntPtr nativePointer;

        private readonly IEntityPool entityPool;

        private readonly IVehicleFactory vehicleFactory;

        internal Server(IntPtr nativePointer, IEntityPool entityPool, IVehicleFactory vehicleFactory)
        {
            this.nativePointer = nativePointer;
            this.entityPool = entityPool;
            this.vehicleFactory = vehicleFactory;
            Instance = this;
        }

        public void LogInfo(string message)
        {
            AltVNative.Server.Server_LogInfo(nativePointer, message);
        }

        public void LogDebug(string message)
        {
            AltVNative.Server.Server_LogDebug(nativePointer, message);
        }

        public void LogWarning(string message)
        {
            AltVNative.Server.Server_LogWarning(nativePointer, message);
        }

        public void LogError(string message)
        {
            AltVNative.Server.Server_LogError(nativePointer, message);
        }

        public void LogColored(string message)
        {
            AltVNative.Server.Server_LogColored(nativePointer, message);
        }

        public uint Hash(string hash)
        {
            return AltVNative.Server.Server_Hash(nativePointer, hash);
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerServerEvent(nativePointer, eventName, ref mValueList);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, ConvertObjectsToMValues(args));
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerClientEvent(nativePointer, player.NativePointer, eventName, ref mValueList);
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
            var vehicle =
                vehicleFactory.Create(AltVNative.Server.Server_CreateVehicle(nativePointer, model, pos, heading));
            entityPool.Add(vehicle);
            return vehicle;
        }

        public bool RemoveEntity(IEntity entity)
        {
            if (!entityPool.Remove(entity))
            {
                return false;
            }

            AltVNative.Server.Server_RemoveEntity(nativePointer, entity.NativePointer);
            return true;
        }
    }
}