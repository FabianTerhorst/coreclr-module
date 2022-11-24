using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using AltV.Net.CApi;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using AltV.Net.ResourceLoaders;
using AltV.Net.Shared;
using AltV.Net.Shared.Events;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]

namespace AltV.Net
{
    internal static class ModuleWrapper
    {
        private static Core _core;

        private static IResource _resource;

        private static IScript[] _scripts;

        private static IModule[] _modules;

        private static void OnStartResource(IntPtr serverPointer, IntPtr resourcePointer, string resourceName,
            string entryPoint)
        {
            _resource.OnStart();
        }

        //TODO: optimize assembly looping with single assembly loop otherwise module startup time is to slow for large projects,
        //TODO: also can we reduce iterations by some assembies, e.g. only assemblies interested for us
        //TODO: make optional resource startup time improvements for specifying IScript and IModules manually in IResource so module doesnt has to search them
        public static void MainWithAssembly(IntPtr serverPointer, IntPtr resourcePointer,
            AssemblyLoadContext assemblyLoadContext, Dictionary<ulong, IntPtr> cApiFuncTable)
        {
            var defaultResource = !AssemblyLoader.FindType(assemblyLoadContext.Assemblies, out _resource);
            if (defaultResource)
            {
                var altVNetAsyncAssembly = assemblyLoadContext.LoadFromAssemblyName(new AssemblyName("AltV.Net.Async"));
                try
                {
                    foreach (var type in altVNetAsyncAssembly.GetTypes())
                    {
                        if (type.Name != "DefaultAsyncResource") continue;
                        var constructor =
                            type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                                null,
                                Type.EmptyTypes, null);
                        _resource = (IResource) constructor?.Invoke(null);
                        break;
                    }
                }
                catch
                {
                    // ignored
                }

                _resource ??= new DefaultResource();
            }

            //var entityFactories = AssemblyLoader.FindAllTypesWithAttribute<IEntityFactory<IEntity>, EntityFactoryAttribute>(assemblyLoadContext.Assemblies);
            //var baseObjectFactories = AssemblyLoader.FindAllTypesWithAttribute<IBaseObjectFactory<IBaseObject>, EntityFactoryAttribute>(assemblyLoadContext.Assemblies);

            //TODO: when resource has entity factories overwritten dont loop assemblies because of performance

            //TODO: when not default resource and entity factory was found and none default resource has entity factory overwritten by not returning null throw exception

            //TODO: check

            //TODO: do the same with the pools

            var library = _resource.GetLibrary() ?? new Library(cApiFuncTable, false);
            
            unsafe
            {
                if (library.Shared.Core_GetEventEnumSize() != (byte) EventType.SIZE)
                {
                    throw new Exception("Event type enum size doesn't match. Please, update the nuget");
                }
            }
            
            var playerFactory = _resource.GetPlayerFactory() ?? new PlayerFactory();
            var vehicleFactory = _resource.GetVehicleFactory() ?? new VehicleFactory();
            var blipFactory = _resource.GetBlipFactory() ?? new BlipFactory();
            var checkpointFactory = _resource.GetCheckpointFactory() ?? new CheckpointFactory();
            var voiceChannelFactory = _resource.GetVoiceChannelFactory() ?? new VoiceChannelFactory();
            var colShapeFactory = _resource.GetColShapeFactory() ?? new ColShapeFactory();
            var nativeResourceFactory = _resource.GetNativeResourceFactory() ?? new NativeResourceFactory();
            var playerPool = _resource.GetPlayerPool(playerFactory);
            var vehiclePool = _resource.GetVehiclePool(vehicleFactory);
            var blipPool = _resource.GetBlipPool(blipFactory);
            var checkpointPool = _resource.GetCheckpointPool(checkpointFactory);
            var voiceChannelPool = _resource.GetVoiceChannelPool(voiceChannelFactory);
            var colShapePool = _resource.GetColShapePool(colShapeFactory);
            var nativeResourcePool = _resource.GetNativeResourcePool(nativeResourceFactory);
            var entityPool = _resource.GetBaseEntityPool(playerPool, vehiclePool);
            var baseObjectPool =
                _resource.GetBaseBaseObjectPool(playerPool, vehiclePool, blipPool, checkpointPool, voiceChannelPool,
                    colShapePool);

            var server = _resource.GetCore(serverPointer, resourcePointer, assemblyLoadContext, library, baseObjectPool, entityPool,
                playerPool, vehiclePool, blipPool, checkpointPool, voiceChannelPool, colShapePool, nativeResourcePool);
            _core = server;
            Alt.CoreImpl = server;
            AltShared.Core = server;

            foreach (var unused in server.GetPlayers())
            {
            }

            foreach (var unused in server.GetVehicles())
            {
            }

            server.Resource.CSharpResourceImpl.SetDelegates(OnStartResource);

            _scripts = AssemblyLoader.FindAllTypes<IScript>(assemblyLoadContext.Assemblies);
            foreach (var script in _scripts)
            {
                if (script.GetType().GetInterfaces().Contains(typeof(IResource)))
                {
                    throw new InvalidOperationException(
                        "IScript must not be a IResource for type:" + script.GetType());
                }
            }

            _core.OnScriptsLoaded(_scripts);
            _modules = AssemblyLoader.FindAllTypes<IModule>(assemblyLoadContext.Assemblies);
            _core.OnModulesLoaded(_modules);
            foreach (var module in _modules)
            {
                module.OnScriptsStarted(_scripts);
            }

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
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
            foreach (var module in _modules)
            {
                module.OnStop();
            }

            _core.BlipPool.Dispose();
            _core.CheckpointPool.Dispose();
            _core.PlayerPool.Dispose();
            _core.VehiclePool.Dispose();
            _core.ColShapePool.Dispose();
            _core.VoiceChannelPool.Dispose();

            Alt.Core.Resource.CSharpResourceImpl.Dispose();

            AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;

            _core.Dispose();

            _modules = new IModule[0];
            _scripts = new IScript[0];
            _resource = null;
        }

        public static void OnTick()
        {
            _resource.OnTick();
        }

        public static void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, BaseObjectType baseObjectType,
            bool state)
        {
            _core.OnCheckpoint(checkpointPointer, entityPointer, baseObjectType, state);
        }

        public static void OnPlayerConnect(IntPtr playerPointer, ushort playerId, string reason)
        {
            _core.OnPlayerConnect(playerPointer, playerId, reason);
        }

        public static void OnPlayerBeforeConnect(IntPtr eventPointer, IntPtr connectionInfoPointer, string reason)
        {
            var connectionInfo = Marshal.PtrToStructure<PlayerConnectionInfo>(connectionInfoPointer);
            _core.OnPlayerBeforeConnect(eventPointer, connectionInfo, reason);
        }

        public static void OnResourceStart(IntPtr resourcePointer)
        {
            _core.OnResourceStart(resourcePointer);
        }

        public static void OnResourceStop(IntPtr resourcePointer)
        {
            _core.OnResourceStop(resourcePointer);
        }

        public static void OnResourceError(IntPtr resourcePointer)
        {
            _core.OnResourceError(resourcePointer);
        }

        public static void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer,
            BaseObjectType attackerBaseObjectType,
            ushort attackerEntityId, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            _core.OnPlayerDamage(playerPointer, attackerEntityPointer, attackerBaseObjectType, attackerEntityId,
                weapon, healthDamage, armourDamage);
        }

        public static void OnPlayerDeath(IntPtr playerPointer, IntPtr killerEntityPointer,
            BaseObjectType killerBaseObjectType, uint weapon)
        {
            _core.OnPlayerDeath(playerPointer, killerEntityPointer, killerBaseObjectType, weapon);
        }

        public static void OnExplosion(IntPtr eventPointer, IntPtr playerPointer, ExplosionType explosionType,
            Position position, uint explosionFx, IntPtr targetEntityPointer, BaseObjectType targetEntityType)
        {
            _core.OnExplosion(eventPointer, playerPointer, explosionType, position, explosionFx, targetEntityPointer, targetEntityType);
        }

        public static void OnWeaponDamage(IntPtr eventPointer, IntPtr playerPointer, IntPtr entityPointer,
            BaseObjectType entityType, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart)
        {
            _core.OnWeaponDamage(eventPointer, playerPointer, entityPointer, entityType, weapon, damage, shotOffset, bodyPart);
        }

        public static void OnPlayerChangeVehicleSeat(IntPtr vehiclePointer, IntPtr playerPointer, byte oldSeat,
            byte newSeat)
        {
            _core.OnPlayerChangeVehicleSeat(vehiclePointer, playerPointer, oldSeat, newSeat);
        }

        public static void OnPlayerEnterVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            _core.OnPlayerEnterVehicle(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerEnteringVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            _core.OnPlayerEnteringVehicle(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerLeaveVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            _core.OnPlayerLeaveVehicle(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            _core.OnPlayerDisconnect(playerPointer, reason);
        }

        public static void OnClientEvent(IntPtr playerPointer, string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnClientEvent(playerPointer, name, args);
        }

        public static void OnServerEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnServerEvent(name, args);
        }

        public static void OnCreatePlayer(IntPtr playerPointer, ushort playerId)
        {
            _core.OnCreatePlayer(playerPointer, playerId);
        }

        public static void OnRemovePlayer(IntPtr playerPointer)
        {
            _core.OnPlayerRemove(playerPointer);
            _core.OnRemovePlayer(playerPointer);
        }

        public static void OnCreateObject(IntPtr playerPointer, ushort playerId)
        {
            _core.OnCreateObject(playerPointer, playerId);
        }

        public static void OnRemoveObject(IntPtr playerPointer)
        {
            _core.OnRemoveObject(playerPointer);
        }

        public static void OnCreateVehicle(IntPtr vehiclePointer, ushort vehicleId)
        {
            _core.OnCreateVehicle(vehiclePointer, vehicleId);
        }

        public static void OnRemoveVehicle(IntPtr vehiclePointer)
        {
            _core.OnVehicleRemove(vehiclePointer);
            _core.OnRemoveVehicle(vehiclePointer);
        }

        public static void OnCreateBlip(IntPtr blipPointer)
        {
            _core.OnCreateBlip(blipPointer);
        }

        public static void OnCreateVoiceChannel(IntPtr channelPointer)
        {
            _core.OnCreateVoiceChannel(channelPointer);
        }

        public static void OnCreateColShape(IntPtr colShapePointer)
        {
            _core.OnCreateColShape(colShapePointer);
        }

        public static void OnRemoveBlip(IntPtr blipPointer)
        {
            _core.OnRemoveBlip(blipPointer);
        }

        public static void OnCreateCheckpoint(IntPtr checkpointPointer)
        {
            _core.OnCreateCheckpoint(checkpointPointer);
        }

        public static void OnRemoveCheckpoint(IntPtr checkpointPointer)
        {
            _core.OnRemoveCheckpoint(checkpointPointer);
        }

        public static void OnRemoveVoiceChannel(IntPtr channelPointer)
        {
            _core.OnRemoveVoiceChannel(channelPointer);
        }

        public static void OnRemoveColShape(IntPtr colShapePointer)
        {
            _core.OnRemoveColShape(colShapePointer);
        }

        public static void OnPlayerRemove(IntPtr playerPointer)
        {
            // todo removed from api
            _core.OnPlayerRemove(playerPointer);
        }

        public static void OnVehicleRemove(IntPtr vehiclePointer)
        {
            // todo removed from api
            _core.OnVehicleRemove(vehiclePointer);
        }

        public static void OnConsoleCommand(string name,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            string[] args, int argsSize)
        {
            args ??= new string[0];
            _core.OnConsoleCommand(name, args);
        }

        public static void OnMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            _core.OnMetaDataChange(entityPointer, entityType, key, value);
        }

        public static void OnSyncedMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            _core.OnSyncedMetaDataChange(entityPointer, entityType, key, value);
        }

        public static void OnColShape(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
            bool state)
        {
            _core.OnColShape(colShapePointer, targetEntityPointer, entityType, state);
        }

        public static void OnVehicleDestroy(IntPtr vehiclePointer)
        {
            _core.OnVehicleDestroy(vehiclePointer);
        }

        public static void OnFire(IntPtr eventPointer, IntPtr playerPointer,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            FireInfo[] fires, int length)
        {
            fires ??= new FireInfo[0];
            _core.OnFire(eventPointer, playerPointer, fires);
        }

        public static void OnStartProjectile(IntPtr eventPointer, IntPtr sourcePlayerPointer, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
        {
            _core.OnStartProjectile(eventPointer, sourcePlayerPointer, startPosition, direction, ammoHash, weaponHash);
        }

        public static void OnPlayerWeaponChange(IntPtr eventPointer, IntPtr targetPlayerPointer, uint oldWeapon, uint newWeapon)
        {
            _core.OnPlayerWeaponChange(eventPointer, targetPlayerPointer, oldWeapon, newWeapon);
        }

        public static void OnNetOwnerChange(IntPtr eventPointer, IntPtr targetEntityPointer, BaseObjectType targetEntityType, IntPtr oldNetOwnerPointer, IntPtr newNetOwnerPointer)
        {
            _core.OnNetOwnerChange(eventPointer, targetEntityPointer, targetEntityType, oldNetOwnerPointer, newNetOwnerPointer);
        }

        public static void OnVehicleAttach(IntPtr eventPointer, IntPtr targetPointer, IntPtr attachedPointer)
        {
            _core.OnVehicleAttach(eventPointer, targetPointer, attachedPointer);
        }

        public static void OnVehicleDetach(IntPtr eventPointer, IntPtr targetPointer, IntPtr detachedPointer)
        {
            _core.OnVehicleDetach(eventPointer, targetPointer, detachedPointer);
        }

        public static void OnVehicleDamage(IntPtr eventPointer, IntPtr vehiclePointer, IntPtr entityPointer, BaseObjectType entityType, uint bodyHealthDamage,
            uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash)
        {
            _core.OnVehicleDamage(eventPointer, vehiclePointer, entityPointer, entityType, bodyHealthDamage, additionalBodyHealthDamage,
                engineHealthDamage, petrolTankDamage, weaponHash);
        }
        
        public static void OnConnectionQueueAdd(IntPtr connectionInfo)
        {
            _core.OnConnectionQueueAdd(connectionInfo);
        }
        
        public static void OnConnectionQueueRemove(IntPtr connectionInfo)
        { 
            _core.OnConnectionQueueRemove(connectionInfo);
        }

        public static void OnServerStarted()
        {
            _core.OnServerStarted();
        }

        public static void OnPlayerRequestControl(IntPtr target, BaseObjectType targetType, IntPtr player)
        {
            _core.OnPlayerRequestControl(target, targetType, player);
        }

        public static void OnPlayerChangeAnimation(IntPtr player, uint oldDict, uint newDict, uint oldName, uint newName)
        {
            _core.OnPlayerChangeAnimation(player, oldDict, newDict, oldName, newName);
        }

        public static void OnPlayerChangeInterior(IntPtr player,  uint oldIntLoc, uint newIntLoc)
        {
            _core.OnPlayerChangeInterior(player, oldIntLoc, newIntLoc);
        }

        public static void OnPlayerDimensionChange(IntPtr player, int oldDimension, int newDimension)
        {
            _core.OnPlayerDimensionChange(player, oldDimension, newDimension);
        }

        public static void OnPlayerConnectDenied(PlayerConnectDeniedReason reason, string name, string ip, ulong passwordHash, bool isDebug, string branch, uint majorVersion, string cdnUrl, long discordId)
        {
            _core.onPlayerConnectDenied(reason, name, ip, passwordHash, isDebug, branch, majorVersion, cdnUrl,
                discordId);
        }
    }
}
