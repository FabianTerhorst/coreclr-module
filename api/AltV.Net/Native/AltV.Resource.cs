using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Resource
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong Resource_GetExportsCount(IntPtr resource);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_GetExports(IntPtr resource, IntPtr[] keys, IntPtr[] values);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Resource_GetExport(IntPtr resource, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Resource_GetDependenciesSize(IntPtr core);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_GetDependencies(IntPtr core, string[] dependencies, int size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Resource_GetDependantsSize(IntPtr core);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_GetDependants(IntPtr core, string[] dependants, int size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_SetExport(IntPtr core, IntPtr resource, IntPtr key, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Resource_SetExports(IntPtr core, IntPtr resource, IntPtr[] values,
                IntPtr[] keys, int size);

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

            internal delegate void ResourceEventDelegate(IntPtr resourcePointer);

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

            internal delegate void ClientEventDelegate(IntPtr playerPointer, string name, IntPtr args, ulong size);

            internal delegate void ServerEventDelegate(string name, IntPtr args, ulong size);

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

            internal delegate void VehicleDestroyDelegate(IntPtr vehiclePointer);

            internal delegate void ConsoleCommandDelegate(string name,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
                string[] args, int argsSize);

            internal delegate void MetaChangeDelegate(IntPtr entityPointer, BaseObjectType entityType, string key,
                IntPtr value);

            internal delegate void ExplosionDelegate(IntPtr eventPointer, IntPtr playerPointer,
                ExplosionType explosionType,
                Position position, uint explosionFx, IntPtr targetEntityPointer, BaseObjectType targetEntityType);

            internal delegate void WeaponDamageDelegate(IntPtr eventPointer, IntPtr playerPointer, IntPtr entityPointer,
                BaseObjectType entityType, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart);

            internal delegate void FireDelegate(IntPtr eventPointer, IntPtr playerPointer,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
                FireInfo[] fires, int length);

            internal delegate void StartProjectileDelegate(IntPtr eventPointer, IntPtr sourcePlayerPointer, Position startPosition, Position direction, uint ammoHash, uint weaponHash);

            internal delegate void PlayerWeaponChangeDelegate(IntPtr eventPointer, IntPtr targetPlayerPointer, uint oldWeapon, uint newWeapon);
            
            internal delegate void NetOwnerChangeDelegate(IntPtr eventPointer, IntPtr targetEntityPointer, BaseObjectType targetEntityType, IntPtr oldNetOwnerPointer, IntPtr newNetOwnerPointer);
            
            internal delegate void VehicleAttachDelegate(IntPtr eventPointer, IntPtr targetPointer, IntPtr attachedPointer);
            
            internal delegate void VehicleDetachDelegate(IntPtr eventPointer, IntPtr targetPointer, IntPtr detachedPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetMainDelegate(IntPtr resource,
                MainDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetStopDelegate(IntPtr resource,
                StopDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetTickDelegate(IntPtr resource,
                TickDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetServerEventDelegate(IntPtr resource,
                ServerEventDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCheckpointDelegate(IntPtr resource,
                CheckpointDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetClientEventDelegate(IntPtr resource,
                ClientEventDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerDamageDelegate(IntPtr resource,
                PlayerDamageDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerConnectDelegate(IntPtr resource,
                PlayerConnectDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetResourceStartDelegate(IntPtr resource,
                ResourceEventDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetResourceStopDelegate(IntPtr resource,
                ResourceEventDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetResourceErrorDelegate(IntPtr resource,
                ResourceEventDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerDeathDelegate(IntPtr resource,
                PlayerDeathDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetExplosionDelegate(IntPtr resource,
                ExplosionDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetWeaponDamageDelegate(IntPtr resource,
                WeaponDamageDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerDisconnectDelegate(IntPtr resource,
                PlayerDisconnectDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerRemoveDelegate(IntPtr resource,
                PlayerRemoveDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetVehicleRemoveDelegate(IntPtr resource,
                VehicleRemoveDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(IntPtr resource,
                PlayerChangeVehicleSeatDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerEnterVehicleDelegate(IntPtr resource,
                PlayerEnterVehicleDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(IntPtr resource,
                PlayerLeaveVehicleDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCreatePlayerDelegate(IntPtr resource,
                CreatePlayerDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRemovePlayerDelegate(IntPtr resource,
                RemovePlayerDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCreateVehicleDelegate(IntPtr resource,
                CreateVehicleDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRemoveVehicleDelegate(IntPtr resource,
                RemoveVehicleDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCreateBlipDelegate(IntPtr resource,
                CreateBlipDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRemoveBlipDelegate(IntPtr resource,
                RemoveBlipDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCreateCheckpointDelegate(IntPtr resource,
                CreateCheckpointDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRemoveCheckpointDelegate(IntPtr resource,
                RemoveCheckpointDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCreateVoiceChannelDelegate(IntPtr resource,
                CreateVoiceChannelDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRemoveVoiceChannelDelegate(IntPtr resource,
                RemoveVoiceChannelDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetConsoleCommandDelegate(IntPtr resource,
                ConsoleCommandDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetMetaChangeDelegate(IntPtr resource,
                MetaChangeDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetSyncedMetaChangeDelegate(IntPtr resource,
                MetaChangeDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCreateColShapeDelegate(IntPtr resource,
                CreateColShapeDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRemoveColShapeDelegate(IntPtr resource,
                RemoveColShapeDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetColShapeDelegate(IntPtr resource,
                ColShapeDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetVehicleDestroyDelegate(IntPtr resource,
                VehicleDestroyDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetFireDelegate(IntPtr resource,
                FireDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetStartProjectileDelegate(IntPtr resource,
                StartProjectileDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerWeaponChangeDelegate(IntPtr resource,
                PlayerWeaponChangeDelegate @delegate);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetNetOwnerChangeDelegate(IntPtr resource,
                NetOwnerChangeDelegate @delegate);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetVehicleAttachDelegate(IntPtr resource,
                VehicleAttachDelegate @delegate);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetVehicleDetachDelegate(IntPtr resource,
                VehicleDetachDelegate @delegate);
        }
    }
}