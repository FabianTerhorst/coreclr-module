using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        private IntPtr NativePointer { get; }

        internal Server(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
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

        public void TriggerServerEvent(string eventName, MValue[] args)
        {
            var mValueList = MValue.Nil;
            Alt.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            Alt.Server.Server_TriggerServerEvent(NativePointer, eventName, ref mValueList);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, MValue[] args)
        {
            var mValueList = MValue.Nil;
            Alt.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            Alt.Server.Server_TriggerClientEvent(NativePointer, player.NativePointer, eventName, ref mValueList);
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            var vehicle = new Vehicle(Alt.Server.Server_CreateVehicle(NativePointer, model, pos, heading));
            return vehicle;
        }

        public void RemoveEntity(IEntity entity)
        {
            Alt.Server.Server_RemoveEntity(NativePointer, entity.NativePointer);
        }
    }
}