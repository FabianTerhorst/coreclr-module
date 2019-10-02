using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Server
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogInfo(IntPtr server, IntPtr str);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogDebug(IntPtr server, IntPtr str);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogWarning(IntPtr server, IntPtr str);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogError(IntPtr server, IntPtr str);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_LogColored(IntPtr server, IntPtr str);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_SubscribeEvent(IntPtr server, ushort ev,
                AltV.Net.Server.EventCallback cb);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_SubscribeTick(IntPtr server, AltV.Net.Server.TickCallback cb);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Server_SubscribeCommand(IntPtr server, IntPtr cmd,
                AltV.Net.Server.CommandCallback cb);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_TriggerServerEvent(IntPtr server, IntPtr ev, ref MValue args);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_TriggerClientEvent(IntPtr server, IntPtr target, IntPtr ev,
                ref MValue args);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateVehicle(IntPtr server, uint model, Position pos, Rotation rot,
                ref ushort id);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateCheckpoint(IntPtr server, IntPtr target, byte type, Position pos,
                float radius, float height, Rgba color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateBlip(IntPtr server, IntPtr target, byte type, Position pos);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateBlipAttached(IntPtr server, IntPtr target, byte type,
                IntPtr attachTo);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_GetResource(IntPtr server, IntPtr resourceName);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateVoiceChannel(IntPtr server, bool spatial, float maxDistance);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeCylinder(IntPtr server, Position pos, float radius,
                float height);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeSphere(IntPtr server, Position pos, float radius);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeCircle(IntPtr server, Position pos, float radius);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeCube(IntPtr server, Position pos, Position pos2);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateColShapeRectangle(IntPtr server, Position pos, Position pos2);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyVehicle(IntPtr server, IntPtr baseObject);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyBlip(IntPtr server, IntPtr baseObject);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyCheckpoint(IntPtr server, IntPtr baseObject);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyVoiceChannel(IntPtr server, IntPtr baseObject);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DestroyColShape(IntPtr server, IntPtr baseObject);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Server_GetNetTime(IntPtr server);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetRootDirectory(IntPtr server, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetPlayers(IntPtr server, ref PlayerPointerArray players);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetVehicles(IntPtr server, ref VehiclePointerArray vehicles);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_StartResource(IntPtr server, IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_StopResource(IntPtr server, IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_RestartResource(IntPtr server, IntPtr text);
        }
    }
}