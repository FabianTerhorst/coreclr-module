using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;
using AltV.Net.FunctionParser;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Module : IDisposable
    {
        internal readonly IServer Server;

        private readonly WeakReference<AssemblyLoadContext> assemblyLoadContext;

        internal readonly INativeResource ModuleResource;

        internal readonly IBaseBaseObjectPool BaseBaseObjectPool;

        internal readonly IBaseEntityPool BaseEntityPool;

        internal readonly IEntityPool<IPlayer> PlayerPool;

        internal readonly IEntityPool<IVehicle> VehiclePool;

        internal readonly IBaseObjectPool<IBlip> BlipPool;

        internal readonly IBaseObjectPool<ICheckpoint> CheckpointPool;

        internal readonly IBaseObjectPool<IVoiceChannel> VoiceChannelPool;

        internal readonly IBaseObjectPool<IColShape> ColShapePool;

        internal readonly INativeResourcePool NativeResourcePool;

        internal IEnumerable<Assembly> Assemblies => !assemblyLoadContext.TryGetTarget(out var target)
            ? new List<Assembly>()
            : target.Assemblies;

        //For custom defined args event handlers
        private readonly Dictionary<string, HashSet<Function>> eventHandlers =
            new Dictionary<string, HashSet<Function>>();

        private readonly Dictionary<string, HashSet<IParserClientEventHandler>> parserClientEventHandlers =
            new Dictionary<string, HashSet<IParserClientEventHandler>>();

        private readonly Dictionary<string, HashSet<IParserServerEventHandler>> parserServerEventHandlers =
            new Dictionary<string, HashSet<IParserServerEventHandler>>();

        //For object[] args event handlers
        private readonly Dictionary<string, HashSet<ServerEventDelegate>> eventDelegateHandlers =
            new Dictionary<string, HashSet<ServerEventDelegate>>();

        private readonly Dictionary<string, HashSet<ClientEventDelegate>> clientEventDelegateHandlers =
            new Dictionary<string, HashSet<ClientEventDelegate>>();

        internal readonly IEventHandler<CheckpointDelegate> CheckpointEventHandler =
            new HashSetEventHandler<CheckpointDelegate>();

        internal readonly IEventHandler<PlayerConnectDelegate> PlayerConnectEventHandler =
            new HashSetEventHandler<PlayerConnectDelegate>();

        internal readonly IEventHandler<ResourceEventDelegate> ResourceStartEventHandler =
            new HashSetEventHandler<ResourceEventDelegate>();

        internal readonly IEventHandler<ResourceEventDelegate> ResourceStopEventHandler =
            new HashSetEventHandler<ResourceEventDelegate>();

        internal readonly IEventHandler<ResourceEventDelegate> ResourceErrorEventHandler =
            new HashSetEventHandler<ResourceEventDelegate>();

        internal readonly IEventHandler<PlayerDamageDelegate> PlayerDamageEventHandler =
            new HashSetEventHandler<PlayerDamageDelegate>();

        internal readonly IEventHandler<PlayerDeadDelegate> PlayerDeadEventHandler =
            new HashSetEventHandler<PlayerDeadDelegate>();

        internal readonly IEventHandler<ExplosionDelegate> ExplosionEventHandler =
            new HashSetEventHandler<ExplosionDelegate>();

        internal readonly IEventHandler<WeaponDamageDelegate> WeaponDamageEventHandler =
            new HashSetEventHandler<WeaponDamageDelegate>();

        internal readonly IEventHandler<PlayerChangeVehicleSeatDelegate> PlayerChangeVehicleSeatEventHandler =
            new HashSetEventHandler<PlayerChangeVehicleSeatDelegate>();

        internal readonly IEventHandler<PlayerEnterVehicleDelegate> PlayerEnterVehicleEventHandler =
            new HashSetEventHandler<PlayerEnterVehicleDelegate>();

        internal readonly IEventHandler<PlayerLeaveVehicleDelegate> PlayerLeaveVehicleEventHandler =
            new HashSetEventHandler<PlayerLeaveVehicleDelegate>();

        internal readonly IEventHandler<PlayerDisconnectDelegate> PlayerDisconnectEventHandler =
            new HashSetEventHandler<PlayerDisconnectDelegate>();

        internal readonly IEventHandler<PlayerRemoveDelegate> PlayerRemoveEventHandler =
            new HashSetEventHandler<PlayerRemoveDelegate>();

        internal readonly IEventHandler<VehicleRemoveDelegate> VehicleRemoveEventHandler =
            new HashSetEventHandler<VehicleRemoveDelegate>();

        internal readonly IEventHandler<PlayerClientEventDelegate> PlayerClientEventEventHandler =
            new HashSetEventHandler<PlayerClientEventDelegate>();

        internal readonly IEventHandler<PlayerClientCustomEventDelegate> PlayerClientCustomEventEventHandler =
            new HashSetEventHandler<PlayerClientCustomEventDelegate>();

        internal readonly IEventHandler<ServerEventEventDelegate> ServerEventEventHandler =
            new HashSetEventHandler<ServerEventEventDelegate>();

        internal readonly IEventHandler<ServerCustomEventEventDelegate> ServerCustomEventEventHandler =
            new HashSetEventHandler<ServerCustomEventEventDelegate>();

        internal readonly IEventHandler<ConsoleCommandDelegate> ConsoleCommandEventHandler =
            new HashSetEventHandler<ConsoleCommandDelegate>();

        internal readonly IEventHandler<MetaDataChangeDelegate> MetaDataChangeEventHandler =
            new HashSetEventHandler<MetaDataChangeDelegate>();

        internal readonly IEventHandler<MetaDataChangeDelegate> SyncedMetaDataChangeEventHandler =
            new HashSetEventHandler<MetaDataChangeDelegate>();

        internal readonly IEventHandler<ColShapeDelegate> ColShapeEventHandler =
            new HashSetEventHandler<ColShapeDelegate>();

        internal readonly IDictionary<string, Function> functionExports = new Dictionary<string, Function>();

        internal readonly LinkedList<GCHandle> functionExportHandles = new LinkedList<GCHandle>();

        private readonly Thread MainThread;

        public Module(IServer server, AssemblyLoadContext assemblyLoadContext,
            INativeResource moduleResource, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool)
        {
            Alt.Init(this);
            Server = server;
            this.assemblyLoadContext = new WeakReference<AssemblyLoadContext>(assemblyLoadContext);
            ModuleResource = moduleResource;
            BaseBaseObjectPool = baseBaseObjectPool;
            BaseEntityPool = baseEntityPool;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            BlipPool = blipPool;
            CheckpointPool = checkpointPool;
            VoiceChannelPool = voiceChannelPool;
            ColShapePool = colShapePool;
            NativeResourcePool = nativeResourcePool;
            MainThread = Thread.CurrentThread;
        }

        public virtual bool IsMainThread()
        {
            return Thread.CurrentThread == MainThread;
        }

        public Assembly LoadAssemblyFromName(AssemblyName assemblyName)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromAssemblyName(assemblyName);
        }

        public Assembly LoadAssemblyFromStream(Stream stream)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromStream(stream);
        }

        public Assembly LoadAssemblyFromStream(Stream stream, Stream assemblySymbols)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromStream(stream, assemblySymbols);
        }

        public Assembly LoadAssemblyFromPath(string path)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromAssemblyPath(path);
        }

        public Assembly LoadAssemblyFromNativeImagePath(string nativeImagePath, string assemblyPath)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromNativeImagePath(nativeImagePath, assemblyPath);
        }

        public void On(string eventName, Function function)
        {
            if (function == null) return;
            if (eventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> {function};
                eventHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void Off(string eventName, Function function)
        {
            if (function == null) return;
            if (eventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Remove(function);
            }
        }

        public void OnServer(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (serverEventDelegate == null) return;
            if (eventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(serverEventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ServerEventDelegate> {serverEventDelegate};
                eventDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void OffServer(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (serverEventDelegate == null) return;
            if (eventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Remove(serverEventDelegate);
            }
        }

        public void OnClient(string eventName, ClientEventDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (clientEventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ClientEventDelegate> {eventDelegate};
                clientEventDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void OffClient(string eventName, ClientEventDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (clientEventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Remove(eventDelegate);
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ClientEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (parserClientEventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(new ParserClientEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlersForEvent = new HashSet<IParserClientEventHandler>
                    {new ParserClientEventHandler<TFunc>(func, parser)};
                parserClientEventHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void Off<TFunc>(string eventName, TFunc func, ClientEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (!parserClientEventHandlers.TryGetValue(eventName, out var eventHandlersForEvent)) return;
            var parsersToDelete = new LinkedList<IParserClientEventHandler>();
            var eventHandlerToFind = new ParserClientEventHandler<TFunc>(func, parser);
            foreach (var eventHandler in eventHandlersForEvent.Where(eventHandler =>
                eventHandler.Equals(eventHandlerToFind)))
            {
                parsersToDelete.AddFirst(eventHandler);
            }

            foreach (var parserToDelete in parsersToDelete)
            {
                eventHandlersForEvent.Remove(parserToDelete);
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ServerEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (parserServerEventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(new ParserServerEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlersForEvent = new HashSet<IParserServerEventHandler>
                    {new ParserServerEventHandler<TFunc>(func, parser)};
                parserServerEventHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void Off<TFunc>(string eventName, TFunc func, ServerEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (!parserServerEventHandlers.TryGetValue(eventName, out var eventHandlersForEvent)) return;
            var parsersToDelete = new LinkedList<IParserServerEventHandler>();
            var eventHandlerToFind = new ParserServerEventHandler<TFunc>(func, parser);
            foreach (var eventHandler in eventHandlersForEvent.Where(eventHandler =>
                eventHandler.Equals(eventHandlerToFind)))
            {
                parsersToDelete.AddFirst(eventHandler);
            }

            foreach (var parserToDelete in parsersToDelete)
            {
                eventHandlersForEvent.Remove(parserToDelete);
            }
        }

        public void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, BaseObjectType baseObjectType,
            bool state)
        {
            if (!CheckpointPool.GetOrCreate(checkpointPointer, out var checkpoint))
            {
                return;
            }

            if (!BaseEntityPool.GetOrCreate(entityPointer, baseObjectType, out var entity))
            {
                return;
            }

            OnCheckPointEvent(checkpoint, entity, state);
        }

        public virtual void OnCheckPointEvent(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            foreach (var @delegate in CheckpointEventHandler.GetEvents())
            {
                @delegate(checkpoint, entity, state);
            }
        }

        public void OnPlayerConnect(IntPtr playerPointer, ushort playerId, string reason)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, playerId, out var player))
            {
                return;
            }

            OnPlayerConnectEvent(player, reason);
        }

        public void OnResourceStart(IntPtr resourcePointer)
        {
            if (!NativeResourcePool.GetOrCreate(resourcePointer, out var nativeResource)) return;
            OnResourceStartEvent(nativeResource);
        }

        public virtual void OnResourceStartEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceStartEventHandler.GetEvents())
            {
                @delegate(resource);
            }
        }

        public void OnResourceStop(IntPtr resourcePointer)
        {
            if (!NativeResourcePool.GetOrCreate(resourcePointer, out var nativeResource)) return;
            OnResourceStopEvent(nativeResource);
        }

        public virtual void OnResourceStopEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceStopEventHandler.GetEvents())
            {
                @delegate(resource);
            }
        }

        public void OnResourceError(IntPtr resourcePointer)
        {
            if (!NativeResourcePool.GetOrCreate(resourcePointer, out var nativeResource)) return;
            OnResourceErrorEvent(nativeResource);
        }

        public virtual void OnResourceErrorEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceErrorEventHandler.GetEvents())
            {
                @delegate(resource);
            }
        }

        public virtual void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerConnectEventHandler.GetEvents())
            {
                @delegate(player, reason);
            }
        }

        public void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer,
            BaseObjectType attackerBaseObjectType,
            ushort attackerEntityId, uint weapon, ushort damage)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            BaseEntityPool.GetOrCreate(attackerEntityPointer, attackerBaseObjectType, attackerEntityId,
                out var attacker);

            OnPlayerDamageEvent(player, attacker, weapon, damage);
        }

        public virtual void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, ushort damage)
        {
            foreach (var @delegate in PlayerDamageEventHandler.GetEvents())
            {
                @delegate(player, attacker, weapon, damage);
            }
        }

        public void OnPlayerDeath(IntPtr playerPointer, IntPtr killerEntityPointer, BaseObjectType killerBaseObjectType,
            uint weapon)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            BaseEntityPool.GetOrCreate(killerEntityPointer, killerBaseObjectType, out var killer);

            OnPlayerDeathEvent(player, killer, weapon);
        }

        public virtual void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            foreach (var @delegate in PlayerDeadEventHandler.GetEvents())
            {
                @delegate(player, killer, weapon);
            }
        }

        public void OnExplosion(IntPtr playerPointer, ExplosionType explosionType, Position position, uint explosionFx)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var sourcePlayer))
            {
                return;
            }

            OnExplosionEvent(sourcePlayer, explosionType, position, explosionFx);
        }

        public virtual void OnExplosionEvent(IPlayer sourcePlayer, ExplosionType explosionType, Position position,
            uint explosionFx)
        {
            foreach (var @delegate in ExplosionEventHandler.GetEvents())
            {
                @delegate(sourcePlayer, explosionType, position, explosionFx);
            }
        }

        public void OnWeaponDamage(IntPtr playerPointer, IntPtr entityPointer, BaseObjectType entityType, uint weapon,
            ushort damage, Position shotOffset, BodyPart bodyPart)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var sourcePlayer))
            {
                return;
            }

            BaseEntityPool.GetOrCreate(entityPointer, entityType, out var targetEntity);

            OnWeaponDamageEvent(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
        }

        public virtual void OnWeaponDamageEvent(IPlayer sourcePlayer, IEntity targetEntity, uint weapon, ushort damage,
            Position shotOffset, BodyPart bodyPart)
        {
            foreach (var @delegate in WeaponDamageEventHandler.GetEvents())
            {
                @delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
            }
        }

        public void OnPlayerChangeVehicleSeat(IntPtr vehiclePointer, IntPtr playerPointer, byte oldSeat,
            byte newSeat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
        }

        public virtual void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat)
        {
            foreach (var @delegate in PlayerChangeVehicleSeatEventHandler.GetEvents())
            {
                @delegate(vehicle, player, oldSeat, newSeat);
            }
        }

        public void OnPlayerEnterVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerEnterVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerEnterVehicleEventHandler.GetEvents())
            {
                @delegate(vehicle, player, seat);
            }
        }

        public void OnPlayerLeaveVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerLeaveVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerLeaveVehicleEventHandler.GetEvents())
            {
                @delegate(vehicle, player, seat);
            }
        }

        public void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerDisconnectEvent(player, reason);
        }

        public virtual void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerDisconnectEventHandler.GetEvents())
            {
                @delegate(player, reason);
            }
        }

        public void OnPlayerRemove(IntPtr playerPointer)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerRemoveEvent(player);
        }

        public virtual void OnPlayerRemoveEvent(IPlayer player)
        {
            foreach (var @delegate in PlayerRemoveEventHandler.GetEvents())
            {
                @delegate(player);
            }
        }

        public void OnVehicleRemove(IntPtr vehiclePointer)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            OnVehicleRemoveEvent(vehicle);
        }

        public virtual void OnVehicleRemoveEvent(IVehicle vehicle)
        {
            foreach (var @delegate in VehicleRemoveEventHandler.GetEvents())
            {
                @delegate(vehicle);
            }
        }

        public void OnClientEvent(IntPtr playerPointer, string name, ref MValueArray args)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            if (parserClientEventHandlers.Count != 0 &&
                parserClientEventHandlers.TryGetValue(name, out var parserEventHandlers))
            {
                foreach (var parserEventHandler in parserEventHandlers)
                {
                    parserEventHandler.Call(player, ref args);
                }
            }

            MValue[] argArray = null;
            if (this.eventHandlers.Count != 0 && this.eventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(player, BaseBaseObjectPool, argArray);
                }
            }

            object[] argObjects = null;

            if (clientEventDelegateHandlers.Count != 0 &&
                clientEventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(player, argObjects);
                }
            }

            if (PlayerClientEventEventHandler.HasEvents())
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                if (argObjects == null)
                {
                    var length = argArray.Length;
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
                    }
                }

                foreach (var eventHandler in PlayerClientEventEventHandler.GetEvents())
                {
                    eventHandler(player, name, argObjects);
                }
            }

            if (PlayerClientCustomEventEventHandler.HasEvents())
            {
                foreach (var eventHandler in PlayerClientCustomEventEventHandler.GetEvents())
                {
                    eventHandler(player, name, ref args);
                }
            }

            OnClientEventEvent(player, name, ref args, argArray, argObjects);
        }

        public virtual void OnClientEventEvent(IPlayer player, string name, ref MValueArray args, MValue[] mValues,
            object[] objects)
        {
        }

        public void OnServerEvent(string name, ref MValueArray args)
        {
            if (parserServerEventHandlers.Count != 0 &&
                parserServerEventHandlers.TryGetValue(name, out var parserEventHandlers))
            {
                foreach (var parserEventHandler in parserEventHandlers)
                {
                    parserEventHandler.Call(ref args);
                }
            }

            MValue[] argArray = null;
            if (this.eventHandlers.Count != 0 && this.eventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    try
                    {
                        eventHandler.Call(BaseBaseObjectPool, argArray);
                    }
                    catch (TargetInvocationException exception)
                    {
                        Alt.Log("exception at event:" + name + ":" + exception.InnerException);
                    }
                    catch (Exception exception)
                    {
                        Alt.Log("exception at event:" + name + ":" + exception);
                    }
                }
            }

            object[] argObjects = null;

            if (eventDelegateHandlers.Count != 0 && eventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(argObjects);
                }
            }

            if (ServerEventEventHandler.HasEvents())
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                if (argObjects == null)
                {
                    var length = argArray.Length;
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
                    }
                }

                foreach (var eventHandler in ServerEventEventHandler.GetEvents())
                {
                    eventHandler(name, argObjects);
                }
            }

            if (ServerCustomEventEventHandler.HasEvents())
            {
                foreach (var eventHandler in ServerCustomEventEventHandler.GetEvents())
                {
                    eventHandler(name, ref args);
                }
            }

            OnServerEventEvent(name, ref args, argArray, argObjects);
        }

        public virtual void OnServerEventEvent(string name, ref MValueArray args, MValue[] mValues, object[] objects)
        {
        }

        public void OnCreatePlayer(IntPtr playerPointer, ushort playerId)
        {
            PlayerPool.Create(playerPointer, playerId);
        }

        public void OnRemovePlayer(IntPtr playerPointer)
        {
            PlayerPool.Remove(playerPointer);
        }

        public void OnCreateVehicle(IntPtr vehiclePointer, ushort vehicleId)
        {
            VehiclePool.Create(vehiclePointer, vehicleId);
        }

        public void OnCreateVoiceChannel(IntPtr channelPointer)
        {
            VoiceChannelPool.Create(channelPointer);
        }

        public void OnCreateColShape(IntPtr colShapePointer)
        {
            ColShapePool.Create(colShapePointer);
        }

        public void OnRemoveVehicle(IntPtr vehiclePointer)
        {
            VehiclePool.Remove(vehiclePointer);
        }

        public void OnCreateBlip(IntPtr blipPointer)
        {
            BlipPool.Create(blipPointer);
        }

        public void OnRemoveBlip(IntPtr blipPointer)
        {
            BlipPool.Remove(blipPointer);
        }

        public void OnCreateCheckpoint(IntPtr checkpointPointer)
        {
            CheckpointPool.Create(checkpointPointer);
        }

        public void OnRemoveCheckpoint(IntPtr checkpointPointer)
        {
            CheckpointPool.Remove(checkpointPointer);
        }

        public void OnRemoveVoiceChannel(IntPtr channelPointer)
        {
            VoiceChannelPool.Remove(channelPointer);
        }

        public void OnRemoveColShape(IntPtr colShapePointer)
        {
            ColShapePool.Remove(colShapePointer);
        }

        public void OnConsoleCommand(string name, ref StringViewArray args)
        {
            var stringArgs = args.ToArray();
            if (ConsoleCommandEventHandler.HasEvents())
            {
                foreach (var eventHandler in ConsoleCommandEventHandler.GetEvents())
                {
                    eventHandler(name, stringArgs);
                }
            }

            OnConsoleCommandEvent(name, stringArgs);
        }

        public virtual void OnConsoleCommandEvent(string name, string[] args)
        {
        }

        public void OnMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            ref MValue value)
        {
            if (!BaseEntityPool.GetOrCreate(entityPointer, entityType, out var entity))
            {
                return;
            }

            OnMetaDataChangeEvent(entity, key, value.ToObject());
        }

        public virtual void OnMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            if (!MetaDataChangeEventHandler.HasEvents()) return;
            foreach (var eventHandler in MetaDataChangeEventHandler.GetEvents())
            {
                eventHandler(entity, key, value);
            }
        }

        public void OnSyncedMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            ref MValue value)
        {
            if (!BaseEntityPool.GetOrCreate(entityPointer, entityType, out var entity))
            {
                return;
            }

            OnSyncedMetaDataChangeEvent(entity, key, value.ToObject());
        }

        public virtual void OnSyncedMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            if (!SyncedMetaDataChangeEventHandler.HasEvents()) return;
            foreach (var eventHandler in SyncedMetaDataChangeEventHandler.GetEvents())
            {
                eventHandler(entity, key, value);
            }
        }

        public void OnColShape(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
            bool state)
        {
            if (!ColShapePool.GetOrCreate(colShapePointer, out var colShape))
            {
                return;
            }

            if (!BaseEntityPool.GetOrCreate(targetEntityPointer, entityType, out var entity))
            {
                return;
            }

            OnColShapeEvent(colShape, entity, state);
        }

        public virtual void OnColShapeEvent(IColShape colShape, IEntity entity, bool state)
        {
            if (!ColShapeEventHandler.HasEvents()) return;
            foreach (var eventHandler in ColShapeEventHandler.GetEvents())
            {
                eventHandler(colShape, entity, state);
            }
        }

        public void OnScriptsLoaded(IScript[] scripts)
        {
            foreach (var script in scripts)
            {
                Alt.RegisterEvents(script);
                OnScriptLoaded(script);
            }
        }

        public virtual void OnScriptLoaded(IScript script)
        {
        }

        public void OnModulesLoaded(IModule[] modules)
        {
            foreach (var module in modules)
            {
                OnModuleLoaded(module);
            }
        }

        public virtual void OnModuleLoaded(IModule module)
        {
            
        }

        public void SetExport(string key, Function function)
        {
            if (function == null) return;
            functionExports[key] = function;
            MValue.Function callDelegate = function.call;
            functionExportHandles.AddFirst(GCHandle.Alloc(callDelegate));
            ModuleResource.SetExport(key, MValue.Create(callDelegate));
        }

        public void Dispose()
        {
            foreach (var handle in functionExportHandles)
            {
                handle.Free();
            }

            functionExportHandles.Clear();
        }
    }
}