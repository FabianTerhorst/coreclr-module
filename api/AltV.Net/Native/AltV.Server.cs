using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        internal static class Server
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogInfo(IntPtr serverPointer, IntPtr message);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogDebug(IntPtr serverPointer, IntPtr message);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogWarning(IntPtr serverPointer, IntPtr message);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogError(IntPtr serverPointer, IntPtr message);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogColored(IntPtr serverPointer, IntPtr message);

            //TODO: is currently implemented in c#, maybe remove?
            //[DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            //internal static extern uint Server_Hash(IntPtr serverPointer, string hash);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_TriggerServerEvent(IntPtr serverPointer, IntPtr eventName,
                ref MValue args);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_TriggerClientEvent(IntPtr serverPointer, IntPtr playerPointer,
                IntPtr eventName, ref MValue args);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateVehicle(IntPtr serverPointer, uint model, Position pos,
                Rotation rotation, ref ushort id);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateCheckpoint(IntPtr serverPointer, IntPtr playerTargetPointer,
                byte type, Position pos, float radius, float height, Rgba color);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateBlip(IntPtr serverPointer, IntPtr playerTargetPointer, byte type,
                Position pos);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateBlipAttached(IntPtr serverPointer, IntPtr playerTargetPointer,
                byte type, IntPtr entityAttachPointer);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_GetResource(IntPtr serverPointer, string resourceName);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateVoiceChannel(IntPtr serverPointer, bool spatial,
                float maxDistance);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeCylinder(IntPtr serverPointer, Position pos,
                float radius, float height);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeSphere(IntPtr serverPointer, Position pos, float radius);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeCircle(IntPtr serverPointer, Position pos, float radius);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeCube(IntPtr serverPointer, Position pos, Position pos2);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeRectangle(IntPtr serverPointer, Position pos,
                Position pos2);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyBaseObject(IntPtr serverPointer, IntPtr baseObjectPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyVehicle(IntPtr serverPointer, IntPtr baseObjectPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyBlip(IntPtr serverPointer, IntPtr baseObjectPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyCheckpoint(IntPtr serverPointer, IntPtr baseObjectPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyVoiceChannel(IntPtr serverPointer, IntPtr baseObjectPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyColShape(IntPtr serverPointer, IntPtr baseObjectPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Server_GetNetTime(IntPtr serverPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetRootDirectory(IntPtr serverPointer, ref IntPtr text);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetPlayers(IntPtr serverPointer, ref PlayerPointerArray playerPointerArray);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetVehicles(IntPtr serverPointer, ref VehiclePointerArray vehiclePointerArray);
        }
    }
}