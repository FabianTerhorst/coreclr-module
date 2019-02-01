using System;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server
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

        public void LogServer(string message)
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

        public void TriggerServerEvent(string eventName, ref MValue args)
        {
            Alt.Server.Server_TriggerServerEvent(NativePointer, eventName, ref args);
        }

        public void TriggerClientEvent(IntPtr playerPointer, string eventName, ref MValue args)
        {
            Alt.Server.Server_TriggerClientEvent(NativePointer, playerPointer, eventName, ref args);
        }

        public IntPtr CreateVehicle(uint model, Position pos, float heading)
        {
            return Alt.Server.Server_CreateVehicle(NativePointer, model, pos, heading);
        }

        public void RemoveEntity(IntPtr entityPointer)
        {
            Alt.Server.Server_RemoveEntity(NativePointer, entityPointer);
        }
    }
}