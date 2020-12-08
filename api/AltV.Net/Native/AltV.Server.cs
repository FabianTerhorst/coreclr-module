using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;

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
            internal static extern bool Server_FileExists(IntPtr server, IntPtr path);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_FileRead(IntPtr server, IntPtr path, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_TriggerServerEvent(IntPtr server, IntPtr ev, IntPtr[] args, int size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_TriggerClientEvent(IntPtr server, IntPtr target, IntPtr ev,
                IntPtr[] args, int size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateVehicle(IntPtr server, uint model, Position pos, Rotation rot,
                ref ushort id);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_CreateCheckpoint(IntPtr server, byte type, Position pos, float radius,
                float height, Rgba color);

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
            internal static extern IntPtr Server_CreateColShapeRectangle(IntPtr server, float x1, float y1, float x2,
                float y2, float z);

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
            internal static extern ulong Server_GetPlayerCount(IntPtr server);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetPlayers(IntPtr server, IntPtr[] players, ulong size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong Server_GetVehicleCount(IntPtr server);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_GetVehicles(IntPtr server, IntPtr[] vehicles, ulong size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_GetEntityById(IntPtr core, ushort id, ref byte type);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_StartResource(IntPtr server, IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_StopResource(IntPtr server, IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_RestartResource(IntPtr server, IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_GetMetaData(IntPtr core, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_SetMetaData(IntPtr core, IntPtr key, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Server_HasMetaData(IntPtr core, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DeleteMetaData(IntPtr core, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Server_GetSyncedMetaData(IntPtr core, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_SetSyncedMetaData(IntPtr core, IntPtr key, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Server_HasSyncedMetaData(IntPtr core, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Server_DeleteSyncedMetaData(IntPtr core, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueNil(IntPtr core);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueBool(IntPtr core, bool value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueInt(IntPtr core, long value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueUInt(IntPtr core, ulong value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueDouble(IntPtr core, double value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueString(IntPtr core, IntPtr value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueList(IntPtr core, IntPtr[] val, ulong size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueDict(IntPtr core, string[] keys, IntPtr[] val, ulong size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueCheckpoint(IntPtr core, IntPtr value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueBlip(IntPtr core, IntPtr value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueVoiceChannel(IntPtr core, IntPtr value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValuePlayer(IntPtr core, IntPtr value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueVehicle(IntPtr core, IntPtr value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueFunction(IntPtr core, IntPtr value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueVector3(IntPtr core, Position value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueRgba(IntPtr core, Rgba value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Core_CreateMValueByteArray(IntPtr core, ulong size, IntPtr data);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Core_IsDebug(IntPtr core);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Core_GetVersion(IntPtr core, ref IntPtr data, ref ulong size);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Core_GetBranch(IntPtr core, ref IntPtr data, ref ulong size);
        }
    }
}