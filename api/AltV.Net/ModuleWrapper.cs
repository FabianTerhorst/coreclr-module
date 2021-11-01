using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using AltV.Net.Native;
using AltV.Net.ResourceLoaders;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]

namespace AltV.Net
{
    internal static class ModuleWrapper
    {
        private static Module _module;

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
            AssemblyLoadContext assemblyLoadContext)
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

            var library = _resource.GetLibrary() ?? new Library();
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
            nativeResourcePool.GetOrCreate(library, serverPointer, resourcePointer, out var csharpResource);
            var server = new Server(serverPointer, library, csharpResource, baseObjectPool, entityPool, playerPool, vehiclePool,
                blipPool,
                checkpointPool, voiceChannelPool, colShapePool, nativeResourcePool);
            _module = _resource.GetModule(server, assemblyLoadContext, csharpResource, baseObjectPool, entityPool,
                playerPool, vehiclePool,
                blipPool, checkpointPool, voiceChannelPool, colShapePool, nativeResourcePool);

            foreach (var unused in server.GetPlayers())
            {
            }

            foreach (var unused in server.GetVehicles())
            {
            }

            csharpResource.CSharpResourceImpl.SetDelegates(OnStartResource);

            _scripts = AssemblyLoader.FindAllTypes<IScript>(assemblyLoadContext.Assemblies);
            foreach (var script in _scripts)
            {
                if (script.GetType().GetInterfaces().Contains(typeof(IResource)))
                {
                    throw new InvalidOperationException(
                        "IScript must not be a IResource for type:" + script.GetType());
                }
            }

            _module.OnScriptsLoaded(_scripts);
            _modules = AssemblyLoader.FindAllTypes<IModule>(assemblyLoadContext.Assemblies);
            _module.OnModulesLoaded(_modules);
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

            _module.BlipPool.Dispose();
            _module.CheckpointPool.Dispose();
            _module.PlayerPool.Dispose();
            _module.VehiclePool.Dispose();
            _module.ColShapePool.Dispose();
            _module.VoiceChannelPool.Dispose();

            Alt.Server.Resource.CSharpResourceImpl.Dispose();

            AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;

            _module.Dispose();

            _modules = new IModule[0];
            _scripts = new IScript[0];
            _module = null;
            _resource = null;
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

        public static void OnPlayerBeforeConnect(IntPtr playerPointer, ushort playerId, ulong passwordHash, string cdnUrl, string reason)
        {
            _module.OnPlayerBeforeConnect(playerPointer, playerId, passwordHash, cdnUrl, reason);
        }

        public static void OnResourceStart(IntPtr resourcePointer)
        {
            _module.OnResourceStart(resourcePointer);
        }

        public static void OnResourceStop(IntPtr resourcePointer)
        {
            _module.OnResourceStop(resourcePointer);
        }

        public static void OnResourceError(IntPtr resourcePointer)
        {
            _module.OnResourceError(resourcePointer);
        }

        public static void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer,
            BaseObjectType attackerBaseObjectType,
            ushort attackerEntityId, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            _module.OnPlayerDamage(playerPointer, attackerEntityPointer, attackerBaseObjectType, attackerEntityId,
                weapon, healthDamage, armourDamage);
        }

        public static void OnPlayerDeath(IntPtr playerPointer, IntPtr killerEntityPointer,
            BaseObjectType killerBaseObjectType, uint weapon)
        {
            _module.OnPlayerDeath(playerPointer, killerEntityPointer, killerBaseObjectType, weapon);
        }

        public static void OnExplosion(IntPtr eventPointer, IntPtr playerPointer, ExplosionType explosionType,
            Position position, uint explosionFx, IntPtr targetEntityPointer, BaseObjectType targetEntityType)
        {
            _module.OnExplosion(eventPointer, playerPointer, explosionType, position, explosionFx, targetEntityPointer, targetEntityType);
        }

        public static void OnWeaponDamage(IntPtr eventPointer, IntPtr playerPointer, IntPtr entityPointer,
            BaseObjectType entityType, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart)
        {
            _module.OnWeaponDamage(eventPointer, playerPointer, entityPointer, entityType, weapon, damage, shotOffset, bodyPart);
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

        public static void OnPlayerEnteringVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            _module.OnPlayerEnteringVehicle(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerLeaveVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            _module.OnPlayerLeaveVehicle(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            _module.OnPlayerDisconnect(playerPointer, reason);
        }

        public static void OnClientEvent(IntPtr playerPointer, string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _module.OnClientEvent(playerPointer, name, args);
        }

        public static void OnServerEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _module.OnServerEvent(name, args);
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

        public static void OnConsoleCommand(string name,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            string[] args, int argsSize)
        {
            args ??= new string[0];
            _module.OnConsoleCommand(name, args);
        }

        public static void OnMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            _module.OnMetaDataChange(entityPointer, entityType, key, value);
        }

        public static void OnSyncedMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            _module.OnSyncedMetaDataChange(entityPointer, entityType, key, value);
        }

        public static void OnColShape(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
            bool state)
        {
            _module.OnColShape(colShapePointer, targetEntityPointer, entityType, state);
        }

        public static void OnVehicleDestroy(IntPtr vehiclePointer)
        {
            _module.OnVehicleDestroy(vehiclePointer);
        }

        public static void OnFire(IntPtr eventPointer, IntPtr playerPointer,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            FireInfo[] fires, int length)
        {
            fires ??= new FireInfo[0];
            _module.OnFire(eventPointer, playerPointer, fires);
        }

        public static void OnStartProjectile(IntPtr eventPointer, IntPtr sourcePlayerPointer, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
        {
            _module.OnStartProjectile(eventPointer, sourcePlayerPointer, startPosition, direction, ammoHash, weaponHash);
        }

        public static void OnPlayerWeaponChange(IntPtr eventPointer, IntPtr targetPlayerPointer, uint oldWeapon, uint newWeapon)
        {
            _module.OnPlayerWeaponChange(eventPointer, targetPlayerPointer, oldWeapon, newWeapon);
        }

        public static void OnNetOwnerChange(IntPtr eventPointer, IntPtr targetEntityPointer, BaseObjectType targetEntityType, IntPtr oldNetOwnerPointer, IntPtr newNetOwnerPointer)
        {
            _module.OnNetOwnerChange(eventPointer, targetEntityPointer, targetEntityType, oldNetOwnerPointer, newNetOwnerPointer);
        }

        public static void OnVehicleAttach(IntPtr eventPointer, IntPtr targetPointer, IntPtr attachedPointer)
        {
            _module.OnVehicleAttach(eventPointer, targetPointer, attachedPointer);
        }

        public static void OnVehicleDetach(IntPtr eventPointer, IntPtr targetPointer, IntPtr detachedPointer)
        {
            _module.OnVehicleDetach(eventPointer, targetPointer, detachedPointer);
        }

        public static void OnVehicleDamage(IntPtr eventPointer, IntPtr vehiclePointer, IntPtr entityPointer, BaseObjectType entityType, uint bodyHealthDamage,
            uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash)
        {
            _module.OnVehicleDamage(eventPointer, vehiclePointer, entityPointer, entityType, bodyHealthDamage, additionalBodyHealthDamage,
                engineHealthDamage, petrolTankDamage, weaponHash);
        }
    }
}
