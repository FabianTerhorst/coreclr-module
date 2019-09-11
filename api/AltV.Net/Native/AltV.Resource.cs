using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        internal static class Resource
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort
                CSharpResource_SetExport(IntPtr resourcePointer, string key, ref MValue value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResource_Reload(IntPtr resourcePointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResource_Load(IntPtr resourcePointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResource_Unload(IntPtr resourcePointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Resource_GetExports(IntPtr resourcePointer, ref StringViewArray keys,
                ref MValueArray values);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Resource_GetExport(IntPtr resourcePointer, string key, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_SetExport(IntPtr resourcePointer, IntPtr text, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_GetPath(IntPtr resourcePointer, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_GetName(IntPtr resourcePointer, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_GetMain(IntPtr resourcePointer, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_GetType(IntPtr resourcePointer, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Resource_IsStarted(IntPtr resourcePointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_Start(IntPtr resourcePointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_Stop(IntPtr resourcePointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Resource_GetImpl(IntPtr resourcePointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Resource_GetCSharpImpl(IntPtr resourcePointer);

            internal delegate void MainDelegate(IntPtr serverPointer, IntPtr resourcePointer, string resourceName,
                string entryPoint);

            internal delegate void StopDelegate();

            internal delegate void TickDelegate();

            internal delegate void CheckpointDelegate(IntPtr checkpointPointer, IntPtr entityPointer,
                BaseObjectType baseObjectType,
                bool state);

            internal delegate void PlayerConnectDelegate(IntPtr playerPointer, ushort playerId, string reason);

            internal delegate void PlayerDamageDelegate(IntPtr playerPointer, IntPtr attackerEntityPointer,
                BaseObjectType attackerBaseObjectType,
                ushort attackerEntityId, uint weapon, ushort damage);

            internal delegate void PlayerDeathDelegate(IntPtr playerPointer, IntPtr killerEntityPointer,
                BaseObjectType killerBaseObjectType, uint weapon);

            internal delegate void PlayerChangeVehicleSeatDelegate(IntPtr vehiclePointer, IntPtr playerPointer,
                byte oldSeat,
                byte newSeat);

            internal delegate void PlayerEnterVehicleDelegate(IntPtr vehiclePointer, IntPtr playerPointer, byte seat);

            internal delegate void PlayerLeaveVehicleDelegate(IntPtr vehiclePointer, IntPtr playerPointer, byte seat);

            internal delegate void PlayerDisconnectDelegate(IntPtr playerPointer, string reason);

            internal delegate void ClientEventDelegate(IntPtr playerPointer, string name, ref MValueArray args);

            internal delegate void ServerEventDelegate(string name, ref MValueArray args);

            internal delegate void CreatePlayerDelegate(IntPtr playerPointer, ushort playerId);

            internal delegate void RemovePlayerDelegate(IntPtr playerPointer);

            internal delegate void CreateVehicleDelegate(IntPtr vehiclePointer, ushort vehicleId);

            internal delegate void RemoveVehicleDelegate(IntPtr vehiclePointer);

            internal delegate void CreateBlipDelegate(IntPtr blipPointer);

            internal delegate void CreateVoiceChannelDelegate(IntPtr channelPointer);

            internal delegate void RemoveBlipDelegate(IntPtr blipPointer);

            internal delegate void CreateCheckpointDelegate(IntPtr checkpointPointer);

            internal delegate void RemoveCheckpointDelegate(IntPtr checkpointPointer);

            internal delegate void RemoveVoiceChannelDelegate(IntPtr channelPointer);

            internal delegate void PlayerRemoveDelegate(IntPtr playerPointer);

            internal delegate void VehicleRemoveDelegate(IntPtr vehiclePointer);

            internal delegate void CreateColShapeDelegate(IntPtr colShapePointer);

            internal delegate void RemoveColShapeDelegate(IntPtr colShapePointer);

            internal delegate void ColShapeDelegate(IntPtr colShapePointer, IntPtr targetEntityPointer,
                BaseObjectType entityType, bool state);

            internal delegate void ConsoleCommandDelegate(string name, ref StringViewArray args);

            internal delegate void MetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
                ref MValue value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResource_SetMain(IntPtr resourcePointer, MainDelegate mainDelegate,
                StopDelegate stopDelegate,
                TickDelegate tickDelegate, ServerEventDelegate serverEventDelegate,
                CheckpointDelegate checkpointDelegate,
                ClientEventDelegate clientEventDelegate, PlayerDamageDelegate playerDamageDelegate,
                PlayerConnectDelegate playerConnectDelegate, PlayerDeathDelegate playerDeathDelegate,
                PlayerDisconnectDelegate playerDisconnectDelegate, PlayerRemoveDelegate playerRemoveDelegate,
                VehicleRemoveDelegate vehicleRemoveDelegate,
                PlayerChangeVehicleSeatDelegate playerChangeVehicleSeatDelegate,
                PlayerEnterVehicleDelegate playerEnterVehicleDelegate,
                PlayerLeaveVehicleDelegate playerLeaveVehicleDelegate,
                CreatePlayerDelegate createPlayerDelegate, RemovePlayerDelegate removePlayerDelegate,
                CreateVehicleDelegate createVehicleDelegate, RemoveVehicleDelegate removeVehicleDelegate,
                CreateBlipDelegate createBlipDelegate, RemoveBlipDelegate removeBlipDelegate,
                CreateCheckpointDelegate createCheckpointDelegate, RemoveCheckpointDelegate removeCheckpointDelegate,
                CreateVoiceChannelDelegate createVoiceChannelDelegate,
                RemoveVoiceChannelDelegate removeVoiceChannelDelegate,
                ConsoleCommandDelegate consoleCommandDelegate,
                MetaDataChange metaDataChange,
                MetaDataChange syncedMetaDataChange,
                CreateColShapeDelegate createColShapeDelegate,
                RemoveColShapeDelegate removeColShapeDelegate,
                ColShapeDelegate colShapeDelegate
            );
        }
    }
}