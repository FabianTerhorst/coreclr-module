using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Server
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogInfo(IntPtr serverPointer, string message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogDebug(IntPtr serverPointer, string message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogWarning(IntPtr serverPointer, string message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogError(IntPtr serverPointer, string message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogColored(IntPtr serverPointer, string message);
            
            //TODO: is currently implemented in c#, maybe remove?
            //[DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            //internal static extern uint Server_Hash(IntPtr serverPointer, string hash);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_TriggerServerEvent(IntPtr serverPointer, string eventName,
                ref MValue args);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_TriggerClientEvent(IntPtr serverPointer, IntPtr playerPointer,
                string eventName, ref MValue args);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern IntPtr Server_CreateVehicle(IntPtr serverPointer, uint model, Position pos,
                float heading, ref ushort id);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern IntPtr Server_CreateCheckpoint(IntPtr serverPointer, IntPtr playerTargetPointer,
                byte type, Position pos, float radius, float height, Rgba color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern IntPtr Server_CreateBlip(IntPtr serverPointer, IntPtr playerTargetPointer, byte type,
                Position pos);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern IntPtr Server_CreateBlipAttached(IntPtr serverPointer, IntPtr playerTargetPointer,
                byte type, IntPtr entityAttachPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Server_RemoveEntity(IntPtr serverPointer, IntPtr entityPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Server_RemoveBlip(IntPtr serverPointer, IntPtr blipPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Server_RemoveCheckpoint(IntPtr serverPointer, IntPtr checkpointPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Server_RemoveVehicle(IntPtr serverPointer, IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_GetResource(IntPtr serverPointer, string resourceName,
                ref IntPtr resourcePointer);
        }
    }
}