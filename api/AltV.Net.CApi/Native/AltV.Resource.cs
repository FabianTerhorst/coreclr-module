using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    //TODO: refactor to function pointers
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Resource
        {
            internal delegate void MainDelegate(IntPtr serverPointer, IntPtr resourcePointer, string resourceName,
                string entryPoint);

            internal delegate void StopDelegate();

            internal delegate void TickDelegate();

            internal delegate void CheckpointDelegate(IntPtr checkpointPointer, IntPtr entityPointer,
                BaseObjectType baseObjectType,
                byte state);

            internal delegate void PlayerConnectDelegate(IntPtr playerPointer, string reason);

            internal delegate void PlayerConnectDeniedDelegate(PlayerConnectDeniedReason reason, string name, string ip,
                ulong passwordHash, byte isDebug, string branch, uint majorVersion, string cdnUrl, long discordId);

            internal delegate void ResourceEventDelegate(IntPtr resourcePointer);

            internal delegate void PlayerDamageDelegate(IntPtr playerPointer, IntPtr attackerEntityPointer,
                BaseObjectType attackerBaseObjectType, uint weapon, ushort healthDamage, ushort armourDamage);

            internal delegate void PlayerDeathDelegate(IntPtr playerPointer, IntPtr killerEntityPointer,
                BaseObjectType killerBaseObjectType, uint weapon);

            internal delegate void PlayerHealDelegate(IntPtr playerPointer, ushort oldHealth, ushort newHealth,
                ushort oldArmour, ushort newArmour);

            internal delegate void PlayerChangeVehicleSeatDelegate(IntPtr vehiclePointer, IntPtr playerPointer,
                byte oldSeat,
                byte newSeat);

            internal delegate void PlayerEnterVehicleDelegate(IntPtr vehiclePointer, IntPtr playerPointer, byte seat);

            internal delegate void PlayerEnteringVehicleDelegate(IntPtr vehiclePointer, IntPtr playerPointer, byte seat);

            internal delegate void PlayerLeaveVehicleDelegate(IntPtr vehiclePointer, IntPtr playerPointer, byte seat);

            internal delegate void PlayerDisconnectDelegate(IntPtr playerPointer, string reason);

            internal delegate void ClientEventDelegate(IntPtr playerPointer, string name, IntPtr args, ulong size);

            internal delegate void ServerEventDelegate(string name, IntPtr args, ulong size);

            internal delegate void ColShapeDelegate(IntPtr colShapePointer, IntPtr targetEntityPointer,
                BaseObjectType entityType, byte state);

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

            internal delegate void VehicleDamageDelegate(IntPtr eventPointer, IntPtr targetPointer, IntPtr sourcePointer, BaseObjectType sourceType, uint bodyHealthDamage, uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash);

            internal delegate void VehicleHornDelegate(IntPtr eventPointer, IntPtr targetPointer,
                IntPtr reporterPointer, byte state);

            internal delegate void ConnectionQueueAddDelegate(IntPtr connectionInfoPointer);

            internal delegate void ConnectionQueueRemoveDelegate(IntPtr connectionInfoPointer);

            internal delegate void ServerStartedDelegate();

            internal delegate void PlayerRequestControlDelegate(IntPtr target, BaseObjectType targetType, IntPtr player);
            internal delegate void PlayerChangeAnimationDelegate(IntPtr target, uint oldDict, uint newDict, uint oldName, uint newName);
            internal delegate void PlayerChangeInteriorDelegate(IntPtr target, uint oldIntLoc, uint newIntLoc);
            internal delegate void PlayerDimensionChangeDelegate(IntPtr player, int oldDimension, int newDimension);

            internal delegate void VehicleSirenDelegate(IntPtr targetVehicle, byte state);

            internal delegate void PlayerSpawnDelegate(IntPtr player);

            internal delegate void CreateBaseObjectDelegate(IntPtr baseObject, BaseObjectType type, uint id);

            internal delegate void RemoveBaseObjectDelegate(IntPtr baseObject, BaseObjectType type);


            internal delegate void RequestSyncedSceneDelegate(IntPtr eventPointer, IntPtr source, int sceneId);

            internal delegate void StartSyncedSceneDelegate(IntPtr source, int sceneId, Position startPosition, Rotation startRotation, uint animDictHash, IntPtr[] entites, BaseObjectType[] types, uint[] animHashes, ulong size);

            internal delegate void StopSyncedSceneDelegate(IntPtr source, int sceneId);

            internal delegate void UpdateSyncedSceneDelegate(IntPtr source, float startRate, int sceneId);

            internal delegate void GivePedScriptedTaskDelegate(IntPtr eventPointer, IntPtr source, IntPtr target, uint taskType);


            internal delegate void PedDamageDelegate(IntPtr pedPointer, IntPtr attackerEntityPointer,
                BaseObjectType attackerBaseObjectType, uint weapon, ushort healthDamage, ushort armourDamage);

            internal delegate void PedDeathDelegate(IntPtr pedPointer, IntPtr killerEntityPointer,
                BaseObjectType killerBaseObjectType, uint weapon);

            internal delegate void PedHealDelegate(IntPtr pedPointer, ushort oldHealth, ushort newHealth,
                ushort oldArmour, ushort newArmour);

            internal delegate void PlayerStartTalkingDelegate(IntPtr playerPointer);

            internal delegate void PlayerStopTalkingDelegate(IntPtr playerPointer);
            internal delegate void ClientScriptRPCDelegate(IntPtr eventPointer, IntPtr targetPointer, string name, IntPtr args, ulong size, ushort answerId);


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
            internal static extern void CSharpResourceImpl_SetPlayerConnectDeniedDelegate(IntPtr resource,
                PlayerConnectDeniedDelegate @delegate);

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
            internal static extern void CSharpResourceImpl_SetPlayerHealDelegate(IntPtr resource,
                PlayerHealDelegate @delegate);

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
            internal static extern void CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(IntPtr resource,
                PlayerChangeVehicleSeatDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerEnterVehicleDelegate(IntPtr resource,
                PlayerEnterVehicleDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerEnteringVehicleDelegate(IntPtr resource,
                PlayerEnteringVehicleDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(IntPtr resource,
                PlayerLeaveVehicleDelegate @delegate);

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

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetVehicleDamageDelegate(IntPtr resource,
                VehicleDamageDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetVehicleHornDelegate(IntPtr resource,
                VehicleHornDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetConnectionQueueAddDelegate(IntPtr resource,
                ConnectionQueueAddDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetConnectionQueueRemoveDelegate(IntPtr resource,
                ConnectionQueueRemoveDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetServerStartedDelegate(IntPtr resource,
                ServerStartedDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerRequestControlDelegate(IntPtr resource,
                PlayerRequestControlDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerChangeAnimationDelegate(IntPtr resource,
                PlayerChangeAnimationDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerChangeInteriorDelegate(IntPtr resource,
                PlayerChangeInteriorDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerDimensionChangeDelegate(IntPtr resource,
                PlayerDimensionChangeDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetVehicleSirenDelegate(IntPtr resource,
                VehicleSirenDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerSpawnDelegate(IntPtr resource,
                PlayerSpawnDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetCreateBaseObjectDelegate(IntPtr resource,
                CreateBaseObjectDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRemoveBaseObjectDelegate(IntPtr resource,
                RemoveBaseObjectDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetRequestSyncedSceneDelegate(IntPtr resource,
                RequestSyncedSceneDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetStartSyncedSceneDelegate(IntPtr resource,
                StartSyncedSceneDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetStopSyncedSceneDelegate(IntPtr resource,
                StopSyncedSceneDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetUpdateSyncedSceneDelegate(IntPtr resource,
                UpdateSyncedSceneDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetGivePedScriptedTaskDelegate(IntPtr resource,
                GivePedScriptedTaskDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPedDamageDelegate(IntPtr resource,
                PedDamageDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPedDeathDelegate(IntPtr resource,
                PedDeathDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPedHealDelegate(IntPtr resource,
                PedHealDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerStartTalkingDelegate(IntPtr resource,
                PlayerStartTalkingDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetPlayerStopTalkingDelegate(IntPtr resource,
                PlayerStopTalkingDelegate @delegate);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void CSharpResourceImpl_SetClientScriptRPCDelegate(IntPtr resource,
                ClientScriptRPCDelegate @delegate);
        }
    }
}