using System;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]

namespace AltV.Net
{
    internal static class ModuleWrapper
    {
        private static Module _module;

        private static IResource _resource;

        public static void Main(IntPtr serverPointer, IntPtr resourcePointer, string resourceName, string entryPoint)
        {
            MainWithResource(serverPointer, resourcePointer,
                new ResourceLoader(serverPointer, resourceName, entryPoint).Init());
            _resource.OnStart();
        }

        public static void MainWithResource(IntPtr serverPointer, IntPtr resourcePointer, IResource resource)
        {
            _resource = resource;
            if (_resource == null)
            {
                return;
            }

            var playerFactory = _resource.GetPlayerFactory();
            var vehicleFactory = _resource.GetVehicleFactory();
            var blipFactory = _resource.GetBlipFactory();
            var checkpointFactory = _resource.GetCheckpointFactory();
            var voiceChannelFactory = _resource.GetVoiceChannelFactory();
            var colShapeFactory = _resource.GetColShapeFactory();
            var playerPool = _resource.GetPlayerPool(playerFactory);
            var vehiclePool = _resource.GetVehiclePool(vehicleFactory);
            var blipPool = _resource.GetBlipPool(blipFactory);
            var checkpointPool = _resource.GetCheckpointPool(checkpointFactory);
            var voiceChannelPool = _resource.GetVoiceChannelPool(voiceChannelFactory);
            var colShapePool = _resource.GetColShapePool(colShapeFactory);
            var entityPool = _resource.GetBaseEntityPool(playerPool, vehiclePool);
            var baseObjectPool =
                _resource.GetBaseBaseObjectPool(playerPool, vehiclePool, blipPool, checkpointPool, voiceChannelPool, colShapePool);
            var server = new Server(serverPointer, baseObjectPool, entityPool, playerPool, vehiclePool, blipPool,
                checkpointPool, voiceChannelPool, colShapePool);
            var csharpResource = new CSharpNativeResource(resourcePointer);
            _module = _resource.GetModule(server, csharpResource, baseObjectPool, entityPool, playerPool, vehiclePool,
                blipPool, checkpointPool, voiceChannelPool, colShapePool);
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                Alt.Log("Loaded:" + assembly.GetName());
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Alt.Log(
                $"< ==== UNHANDLED EXCEPTION ==== > {Environment.NewLine} Received an unhandled exception from {sender?.GetType()}: " +
                (Exception) e.ExceptionObject);
        }

        public static void OnStop()
        {
            _resource.OnStop();
        }

        public static void OnTick()
        {
            _resource.OnTick();
        }

        public static void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, BaseObjectType baseObjectType,
            bool state)
        {
            _module.OnCheckpoint(checkpointPointer, entityPointer, baseObjectType, state);
        }

        public static void OnPlayerConnect(IntPtr playerPointer, ushort playerId, string reason)
        {
            _module.OnPlayerConnect(playerPointer, playerId, reason);
        }

        public static void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer,
            BaseObjectType attackerBaseObjectType,
            ushort attackerEntityId, uint weapon, ushort damage)
        {
            _module.OnPlayerDamage(playerPointer, attackerEntityPointer, attackerBaseObjectType, attackerEntityId,
                weapon, damage);
        }

        public static void OnPlayerDeath(IntPtr playerPointer, IntPtr killerEntityPointer,
            BaseObjectType killerBaseObjectType, uint weapon)
        {
            _module.OnPlayerDeath(playerPointer, killerEntityPointer, killerBaseObjectType, weapon);
        }

        public static void OnPlayerChangeVehicleSeat(IntPtr vehiclePointer, IntPtr playerPointer, byte oldSeat,
            byte newSeat)
        {
            _module.OnPlayerChangeVehicleSeat(vehiclePointer, playerPointer, oldSeat, newSeat);
        }

        public static void OnPlayerEnterVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            _module.OnPlayerEnterVehicle(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerLeaveVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            _module.OnPlayerLeaveVehicle(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            _module.OnPlayerDisconnect(playerPointer, reason);
        }

        public static void OnClientEvent(IntPtr playerPointer, string name, ref MValueArray args)
        {
            _module.OnClientEvent(playerPointer, name, ref args);
        }

        public static void OnServerEvent(string name, ref MValueArray args)
        {
            _module.OnServerEvent(name, ref args);
        }

        public static void OnCreatePlayer(IntPtr playerPointer, ushort playerId)
        {
            _module.OnCreatePlayer(playerPointer, playerId);
        }

        public static void OnRemovePlayer(IntPtr playerPointer)
        {
            _module.OnRemovePlayer(playerPointer);
        }

        public static void OnCreateVehicle(IntPtr vehiclePointer, ushort vehicleId)
        {
            _module.OnCreateVehicle(vehiclePointer, vehicleId);
        }

        public static void OnRemoveVehicle(IntPtr vehiclePointer)
        {
            _module.OnRemoveVehicle(vehiclePointer);
        }

        public static void OnCreateBlip(IntPtr blipPointer)
        {
            _module.OnCreateBlip(blipPointer);
        }

        public static void OnCreateVoiceChannel(IntPtr channelPointer)
        {
            _module.OnCreateVoiceChannel(channelPointer);
        }
        
        public static void OnCreateColShape(IntPtr colShapePointer)
        {
            _module.OnCreateColShape(colShapePointer);
        }

        public static void OnRemoveBlip(IntPtr blipPointer)
        {
            _module.OnRemoveBlip(blipPointer);
        }

        public static void OnCreateCheckpoint(IntPtr checkpointPointer)
        {
            _module.OnCreateCheckpoint(checkpointPointer);
        }

        public static void OnRemoveCheckpoint(IntPtr checkpointPointer)
        {
            _module.OnRemoveCheckpoint(checkpointPointer);
        }

        public static void OnRemoveVoiceChannel(IntPtr channelPointer)
        {
            _module.OnRemoveVoiceChannel(channelPointer);
        }
        
        public static void OnRemoveColShape(IntPtr colShapePointer)
        {
            _module.OnRemoveColShape(colShapePointer);
        }

        public static void OnPlayerRemove(IntPtr playerPointer)
        {
            _module.OnPlayerRemove(playerPointer);
        }

        public static void OnVehicleRemove(IntPtr vehiclePointer)
        {
            _module.OnVehicleRemove(vehiclePointer);
        }

        public static void OnConsoleCommand(string name, ref StringViewArray args)
        {
            _module.OnConsoleCommand(name, ref args);
        }
        
        public static void OnMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key, ref MValue value)
        {
            _module.OnMetaDataChange(entityPointer, entityType, key, ref value);
        }
        
        public static void OnSyncedMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key, ref MValue value)
        {
            _module.OnSyncedMetaDataChange(entityPointer, entityType, key, ref value);
        }

        public static void OnColShape(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType, bool state)
        {
            _module.OnColShape(colShapePointer, targetEntityPointer, entityType, state);
        }
    }
}