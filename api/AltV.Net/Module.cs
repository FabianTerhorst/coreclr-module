using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly Dictionary<string, HashSet<Function>> eventBusClient =
            new Dictionary<string, HashSet<Function>>();

        private readonly Dictionary<string, HashSet<Function>> eventBusServer =
            new Dictionary<string, HashSet<Function>>();

        private readonly Dictionary<string, HashSet<IParserClientEventHandler>> eventBusClientParser =
            new Dictionary<string, HashSet<IParserClientEventHandler>>();

        private readonly Dictionary<string, HashSet<IParserServerEventHandler>> eventBusServerParser =
            new Dictionary<string, HashSet<IParserServerEventHandler>>();

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

        internal readonly IEventHandler<VehicleDestroyDelegate> VehicleDestroyEventHandler =
            new HashSetEventHandler<VehicleDestroyDelegate>();
        
        internal readonly IEventHandler<FireDelegate> FireEventHandler =
            new HashSetEventHandler<FireDelegate>();
        
        internal readonly IEventHandler<StartProjectileDelegate> StartProjectileEventHandler =
            new HashSetEventHandler<StartProjectileDelegate>();
        
        internal readonly IEventHandler<PlayerWeaponChangeDelegate> PlayerWeaponChangeEventHandler =
            new HashSetEventHandler<PlayerWeaponChangeDelegate>();
        
        internal readonly IEventHandler<NetOwnerChangeDelegate> NetOwnerChangeEventHandler =
            new HashSetEventHandler<NetOwnerChangeDelegate>();
        
        internal readonly IEventHandler<VehicleAttachDelegate> VehicleAttachEventHandler =
            new HashSetEventHandler<VehicleAttachDelegate>();
        
        internal readonly IEventHandler<VehicleDetachDelegate> VehicleDetachEventHandler =
            new HashSetEventHandler<VehicleDetachDelegate>();

        internal readonly IDictionary<string, Function> functionExports = new Dictionary<string, Function>();

        internal readonly LinkedList<GCHandle> functionExportHandles = new LinkedList<GCHandle>();

        private readonly Thread MainThread;

        private readonly IDictionary<int, IDictionary<IBaseObject, ulong>> threadRefCount =
            new Dictionary<int, IDictionary<IBaseObject, ulong>>();

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

        [Conditional("DEBUG")]
        public void CountUpRefForCurrentThread(IBaseObject baseObject)
        {
            if (baseObject == null) return;
            var currThread = Thread.CurrentThread.ManagedThreadId;
            lock (threadRefCount)
            {
                if (!threadRefCount.TryGetValue(currThread, out var baseObjectRefCount))
                {
                    baseObjectRefCount = new Dictionary<IBaseObject, ulong>();
                    threadRefCount[currThread] = baseObjectRefCount;
                }

                if (!baseObjectRefCount.TryGetValue(baseObject, out var count))
                {
                    count = 0;
                }

                baseObjectRefCount[baseObject] = count + 1;
            }
        }

        [Conditional("DEBUG")]
        public void CountDownRefForCurrentThread(IBaseObject baseObject)
        {
            if (baseObject == null) return;
            var currThread = Thread.CurrentThread.ManagedThreadId;
            lock (threadRefCount)
            {
                if (!threadRefCount.TryGetValue(currThread, out var baseObjectRefCount))
                {
                    return;
                }

                if (!baseObjectRefCount.TryGetValue(baseObject, out var count))
                {
                    return;
                }

                if (count == 1)
                {
                    baseObjectRefCount.Remove(baseObject);
                    return;
                }

                baseObjectRefCount[baseObject] = count - 1;
            }
        }

        public bool HasRefForCurrentThread(IBaseObject baseObject)
        {
            var currThread = Thread.CurrentThread.ManagedThreadId;
            lock (threadRefCount)
            {
                if (!threadRefCount.TryGetValue(currThread, out var baseObjectRefCount))
                {
                    return false;
                }

                if (!baseObjectRefCount.TryGetValue(baseObject, out var count))
                {
                    return false;
                }

                return count > 0;
            }
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
        
        public WeakReference<AssemblyLoadContext> GetAssemblyLoadContext()
        {
            return assemblyLoadContext;
        }

        public AssemblyLoadContext GetAssemblyLoadContext()
        {
            return !assemblyLoadContext.TryGetTarget(out var target) ? null : target;
        }

        public void OnClient(string eventName, Function function)
        {
            if (function == null) return;
            if (eventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function> {function};
                eventBusClient[eventName] = eventHandlers;
            }
        }

        public void OffClient(string eventName, Function function)
        {
            if (function == null) return;
            if (eventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }
        }

        public void OnServer(string eventName, Function function)
        {
            if (function == null) return;
            if (eventBusServer.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function> {function};
                eventBusServer[eventName] = eventHandlers;
            }
        }

        public void OffServer(string eventName, Function function)
        {
            if (function == null) return;
            if (eventBusServer.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ClientEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (eventBusClientParser.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(new ParserClientEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlers = new HashSet<IParserClientEventHandler>
                    {new ParserClientEventHandler<TFunc>(func, parser)};
                eventBusClientParser[eventName] = eventHandlers;
            }
        }

        public void Off<TFunc>(string eventName, TFunc func, ClientEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (!eventBusClientParser.TryGetValue(eventName, out var eventHandlers)) return;
            var parsersToDelete = new LinkedList<IParserClientEventHandler>();
            var eventHandlerToFind = new ParserClientEventHandler<TFunc>(func, parser);
            foreach (var eventHandler in eventHandlers.Where(eventHandler =>
                eventHandler.Equals(eventHandlerToFind)))
            {
                parsersToDelete.AddFirst(eventHandler);
            }

            foreach (var parserToDelete in parsersToDelete)
            {
                eventHandlers.Remove(parserToDelete);
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ServerEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (eventBusServerParser.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(new ParserServerEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlers = new HashSet<IParserServerEventHandler>
                    {new ParserServerEventHandler<TFunc>(func, parser)};
                eventBusServerParser[eventName] = eventHandlers;
            }
        }

        public void Off<TFunc>(string eventName, TFunc func, ServerEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (!eventBusServerParser.TryGetValue(eventName, out var eventHandlers)) return;
            var parsersToDelete = new LinkedList<IParserServerEventHandler>();
            var eventHandlerToFind = new ParserServerEventHandler<TFunc>(func, parser);
            foreach (var eventHandler in eventHandlers.Where(eventHandler =>
                eventHandler.Equals(eventHandlerToFind)))
            {
                parsersToDelete.AddFirst(eventHandler);
            }

            foreach (var parserToDelete in parsersToDelete)
            {
                eventHandlers.Remove(parserToDelete);
            }
        }

        public void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, BaseObjectType baseObjectType,
            bool state)
        {
            if (!CheckpointPool.Get(checkpointPointer, out var checkpoint))
            {
                Console.WriteLine("OnCheckpoint Invalid checkpoint " + checkpointPointer + " " + entityPointer + " " +
                                  baseObjectType + " " + state);
                return;
            }

            if (!BaseEntityPool.Get(entityPointer, baseObjectType, out var entity))
            {
                Console.WriteLine("OnCheckpoint Invalid entity " + checkpointPointer + " " + entityPointer + " " +
                                  baseObjectType + " " + state);
                return;
            }

            OnCheckPointEvent(checkpoint, entity, state);
        }

        public virtual void OnCheckPointEvent(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            foreach (var @delegate in CheckpointEventHandler.GetEvents())
            {
                try
                {
                    @delegate(checkpoint, entity, state);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnCheckPointEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnCheckPointEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerConnect(IntPtr playerPointer, ushort playerId, string reason)
        {
            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerConnect Invalid player " + playerPointer + " " + playerId + " " +
                                  reason);
                return;
            }

            OnPlayerConnectEvent(player, reason);
        }

        public void OnResourceStart(IntPtr resourcePointer)
        {
            var resource = Server.GetResource(resourcePointer);
            if (resource == null) return;
            OnResourceStartEvent(resource);
        }

        public virtual void OnResourceStartEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceStartEventHandler.GetEvents())
            {
                try
                {
                    @delegate(resource);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStartEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStartEvent" + ":" + exception);
                }
            }
        }

        public void OnResourceStop(IntPtr resourcePointer)
        {
            var resource = Server.GetResource(resourcePointer);
            if (resource == null) return;
            OnResourceStopEvent(resource);
        }

        public virtual void OnResourceStopEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceStopEventHandler.GetEvents())
            {
                try
                {
                    @delegate(resource);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStopEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStopEvent" + ":" + exception);
                }
            }
        }

        public void OnResourceError(IntPtr resourcePointer)
        {
            var resource = Server.GetResource(resourcePointer);
            if (resource == null) return;
            OnResourceErrorEvent(resource);
        }

        public virtual void OnResourceErrorEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceErrorEventHandler.GetEvents())
            {
                try
                {
                    @delegate(resource);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnResourceErrorEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnResourceErrorEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerConnectEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, reason);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerConnectEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerConnectEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer,
            BaseObjectType attackerBaseObjectType,
            ushort attackerEntityId, uint weapon, ushort damage)
        {
            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerDamage Invalid player " + playerPointer + " " + attackerEntityPointer + " " +
                                  attackerBaseObjectType + " " + attackerEntityId + " " + weapon + " " + damage);
                return;
            }

            BaseEntityPool.Get(attackerEntityPointer, attackerBaseObjectType,
                out var attacker);

            OnPlayerDamageEvent(player, attacker, weapon, damage);
        }

        public virtual void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, ushort damage)
        {
            foreach (var @delegate in PlayerDamageEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, attacker, weapon, damage);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDamageEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDamageEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerDeath(IntPtr playerPointer, IntPtr killerEntityPointer, BaseObjectType killerBaseObjectType,
            uint weapon)
        {
            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerDeath Invalid player " + playerPointer + " " + killerEntityPointer + " " +
                                  killerBaseObjectType + " " + weapon);
                return;
            }

            BaseEntityPool.Get(killerEntityPointer, killerBaseObjectType, out var killer);

            OnPlayerDeathEvent(player, killer, weapon);
        }

        public virtual void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            foreach (var @delegate in PlayerDeadEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, killer, weapon);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDeathEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDeathEvent" + ":" + exception);
                }
            }
        }

        public void OnExplosion(IntPtr eventPointer, IntPtr playerPointer, ExplosionType explosionType,
            Position position, uint explosionFx, IntPtr targetEntityPointer, BaseObjectType targetEntityType)
        {
            if (!PlayerPool.Get(playerPointer, out var sourcePlayer))
            {
                Console.WriteLine("OnExplosion Invalid player " + playerPointer + " " + explosionType + " " +
                                  position + " " + explosionFx);
                return;
            }

            BaseEntityPool.Get(targetEntityPointer, targetEntityType, out var targetEntity);

            OnExplosionEvent(eventPointer, sourcePlayer, explosionType, position, explosionFx, targetEntity);
        }

        public virtual void OnExplosionEvent(IntPtr eventPointer, IPlayer sourcePlayer, ExplosionType explosionType,
            Position position,
            uint explosionFx, IEntity targetEntity)
        {
            var cancel = false;
            foreach (var @delegate in ExplosionEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(sourcePlayer, explosionType, position, explosionFx, targetEntity))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnExplosionEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnExplosionEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                AltNative.Event.Event_Cancel(eventPointer);
            }
        }

        public void OnWeaponDamage(IntPtr eventPointer, IntPtr playerPointer, IntPtr entityPointer,
            BaseObjectType entityType, uint weapon,
            ushort damage, Position shotOffset, BodyPart bodyPart)
        {
            if (!PlayerPool.Get(playerPointer, out var sourcePlayer))
            {
                Console.WriteLine("OnWeaponDamage Invalid player " + playerPointer + " " + entityPointer + " " +
                                  entityType + " " + weapon + " " + damage + " " + shotOffset + " " + bodyPart);
                return;
            }

            BaseEntityPool.Get(entityPointer, entityType, out var targetEntity);

            OnWeaponDamageEvent(eventPointer, sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
        }

        public virtual void OnWeaponDamageEvent(IntPtr eventPointer, IPlayer sourcePlayer, IEntity targetEntity,
            uint weapon, ushort damage,
            Position shotOffset, BodyPart bodyPart)
        {
            var cancel = false;
            foreach (var @delegate in WeaponDamageEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnWeaponDamageEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnWeaponDamageEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                AltNative.Event.Event_Cancel(eventPointer);
            }
        }

        public void OnPlayerChangeVehicleSeat(IntPtr vehiclePointer, IntPtr playerPointer, byte oldSeat,
            byte newSeat)
        {
            if (!VehiclePool.Get(vehiclePointer, out var vehicle))
            {
                Console.WriteLine("OnPlayerChangeVehicleSeat Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  oldSeat + " " + newSeat);
                return;
            }

            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerChangeVehicleSeat Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  oldSeat + " " + newSeat);
                return;
            }

            OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
        }

        public virtual void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat)
        {
            foreach (var @delegate in PlayerChangeVehicleSeatEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle, player, oldSeat, newSeat);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeVehicleSeatEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeVehicleSeatEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerEnterVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            if (!VehiclePool.Get(vehiclePointer, out var vehicle))
            {
                Console.WriteLine("OnPlayerEnterVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerEnterVehicle Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            OnPlayerEnterVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerEnterVehicleEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle, player, seat);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerEnterVehicleEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerEnterVehicleEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerLeaveVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            if (!VehiclePool.Get(vehiclePointer, out var vehicle))
            {
                Console.WriteLine("OnPlayerLeaveVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerLeaveVehicle Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            OnPlayerLeaveVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerLeaveVehicleEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle, player, seat);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerLeaveVehicleEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerLeaveVehicleEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerDisconnect Invalid player " + playerPointer + " " + reason);
                return;
            }

            OnPlayerDisconnectEvent(player, reason);
        }

        public virtual void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerDisconnectEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, reason);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDisconnectEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDisconnectEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerRemove(IntPtr playerPointer)
        {
            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnPlayerRemove Invalid player " + playerPointer);
                return;
            }

            OnPlayerRemoveEvent(player);
        }

        public virtual void OnPlayerRemoveEvent(IPlayer player)
        {
            foreach (var @delegate in PlayerRemoveEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerRemoveEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerRemoveEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleRemove(IntPtr vehiclePointer)
        {
            if (!VehiclePool.Get(vehiclePointer, out var vehicle))
            {
                Console.WriteLine("OnVehicleRemove Invalid vehicle " + vehiclePointer);
                return;
            }

            OnVehicleRemoveEvent(vehicle);
        }

        public virtual void OnVehicleRemoveEvent(IVehicle vehicle)
        {
            foreach (var @delegate in VehicleRemoveEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleRemoveEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleRemoveEvent" + ":" + exception);
                }
            }
        }

        public void OnClientEvent(IntPtr playerPointer, string name, IntPtr[] args)
        {
            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnClientEvent Invalid player " + playerPointer);
                return;
            }

            var length = args.Length;
            MValueConst[] mValues = null;

            if (eventBusClientParser.Count != 0 &&
                eventBusClientParser.TryGetValue(name, out var parserEventHandlers))
            {
                mValues = new MValueConst[length];
                for (var i = 0; i < length; i++)
                {
                    mValues[i] = new MValueConst(args[i]);
                }

                foreach (var parserEventHandler in parserEventHandlers)
                {
                    try
                    {
                        parserEventHandler.Call(player, mValues);
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

            if (eventBusClient.Count != 0 && eventBusClient.TryGetValue(name, out var eventHandlersClient))
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                foreach (var eventHandler in eventHandlersClient)
                {
                    try
                    {
                        eventHandler.Call(player, mValues);
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

            if (PlayerClientEventEventHandler.HasEvents())
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                if (argObjects == null)
                {
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = mValues[i].ToObject();
                    }
                }

                foreach (var eventHandler in PlayerClientEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(player, name, argObjects);
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

            if (PlayerClientCustomEventEventHandler.HasEvents())
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                foreach (var eventHandler in PlayerClientCustomEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(player, name, mValues);
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

            OnClientEventEvent(player, name, args, mValues, argObjects);
        }

        public virtual void OnClientEventEvent(IPlayer player, string name, IntPtr[] args, MValueConst[] mValues,
            object[] objects)
        {
        }

        public void OnServerEvent(string name, IntPtr[] args)
        {
            var length = args.Length;
            var mValues = new MValueConst[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(args[i]);
            }

            if (eventBusServerParser.Count != 0 &&
                eventBusServerParser.TryGetValue(name, out var parserEventHandlers))
            {
                foreach (var parserEventHandler in parserEventHandlers)
                {
                    parserEventHandler.Call(mValues);
                }
            }

            if (eventBusServer.Count != 0 && eventBusServer.TryGetValue(name, out var eventHandlersServer))
            {
                foreach (var eventNameEventHandler in eventHandlersServer)
                {
                    try
                    {
                        eventNameEventHandler.Call(mValues);
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

            if (ServerEventEventHandler.HasEvents())
            {
                if (argObjects == null)
                {
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = mValues[i].ToObject();
                    }
                }

                foreach (var eventHandler in ServerEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(name, argObjects);
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

            if (ServerCustomEventEventHandler.HasEvents())
            {
                foreach (var eventHandler in ServerCustomEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(name, mValues);
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

            OnServerEventEvent(name, args, mValues, argObjects);
        }

        public virtual void OnServerEventEvent(string name, IntPtr[] args, MValueConst[] mValues, object[] objects)
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

        public void OnConsoleCommand(string name, string[] args)
        {
            if (ConsoleCommandEventHandler.HasEvents())
            {
                foreach (var eventHandler in ConsoleCommandEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(name, args);
                    }
                    catch (TargetInvocationException exception)
                    {
                        Alt.Log("exception at event:" + "OnConsoleCommand" + ":" + exception.InnerException);
                    }
                    catch (Exception exception)
                    {
                        Alt.Log("exception at event:" + "OnConsoleCommand" + ":" + exception);
                    }
                }
            }

            OnConsoleCommandEvent(name, args);
        }

        public virtual void OnConsoleCommandEvent(string name, string[] args)
        {
        }

        public void OnMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            if (!BaseEntityPool.Get(entityPointer, entityType, out var entity))
            {
                Console.WriteLine("OnMetaDataChange Invalid entity " + entityPointer + " " + entityType + " " + key + " " + value);
                return;
            }

            OnMetaDataChangeEvent(entity, key, new MValueConst(value).ToObject());
        }

        public virtual void OnMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            if (!MetaDataChangeEventHandler.HasEvents()) return;
            foreach (var eventHandler in MetaDataChangeEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(entity, key, value);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnMetaDataChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnMetaDataChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnSyncedMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            if (!BaseEntityPool.Get(entityPointer, entityType, out var entity))
            {
                Console.WriteLine("OnSyncedMetaDataChange Invalid entity " + entityPointer + " " + entityType + " " + key + " " + value);
                return;
            }

            OnSyncedMetaDataChangeEvent(entity, key, new MValueConst(value).ToObject());
        }

        public virtual void OnSyncedMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            if (!SyncedMetaDataChangeEventHandler.HasEvents()) return;
            foreach (var eventHandler in SyncedMetaDataChangeEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(entity, key, value);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnSyncedMetaDataChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnSyncedMetaDataChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnColShape(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
            bool state)
        {
            if (!ColShapePool.Get(colShapePointer, out var colShape))
            {
                Console.WriteLine("OnColShape Invalid colshape " + colShapePointer + " " + targetEntityPointer + " " + entityType + " " + state);
                return;
            }

            if (!BaseEntityPool.Get(targetEntityPointer, entityType, out var entity))
            {
                Console.WriteLine("OnColShape Invalid entity " + colShapePointer + " " + targetEntityPointer + " " + entityType + " " + state);
                return;
            }

            OnColShapeEvent(colShape, entity, state);
        }

        public virtual void OnColShapeEvent(IColShape colShape, IEntity entity, bool state)
        {
            if (!ColShapeEventHandler.HasEvents()) return;
            foreach (var eventHandler in ColShapeEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(colShape, entity, state);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnColShapeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnColShapeEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleDestroy(IntPtr vehiclePointer)
        {
            if (!VehiclePool.Get(vehiclePointer, out var vehicle))
            {
                Console.WriteLine("OnVehicleDestroy Invalid vehicle " + vehiclePointer);
                return;
            }

            OnVehicleDestroyEvent(vehicle);
        }

        public virtual void OnVehicleDestroyEvent(IVehicle vehicle)
        {
            if (!VehicleDestroyEventHandler.HasEvents()) return;
            foreach (var eventHandler in VehicleDestroyEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(vehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDestroyEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDestroyEvent" + ":" + exception);
                }
            }
        }
        
        public void OnFire(IntPtr eventPointer, IntPtr playerPointer, FireInfo[] fires)
        {
            if (!PlayerPool.Get(playerPointer, out var player))
            {
                Console.WriteLine("OnFire Invalid player " + playerPointer);
                return;
            }

            OnFireEvent(eventPointer, player, fires);
        }

        public virtual void OnFireEvent(IntPtr eventPointer, IPlayer player, FireInfo[] fires)
        {
            if (!FireEventHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in FireEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(player, fires))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnFireEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnFireEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                AltNative.Event.Event_Cancel(eventPointer);
            }
        }

        public void OnStartProjectile(IntPtr eventPointer, IntPtr sourcePlayerPointer, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
        {
            if (!PlayerPool.Get(sourcePlayerPointer, out var player))
            {
                Console.WriteLine("OnStartProjectile Invalid player " + sourcePlayerPointer);
                return;
            }

            OnStartProjectileEvent(eventPointer, player, startPosition, direction, ammoHash, weaponHash);
        }

        public virtual void OnStartProjectileEvent(IntPtr eventPointer, IPlayer player, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
        {
            if (!StartProjectileEventHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in StartProjectileEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(player, startPosition, direction, ammoHash, weaponHash))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnStartProjectileEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnStartProjectileEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                AltNative.Event.Event_Cancel(eventPointer);
            }
        }

        public void OnPlayerWeaponChange(IntPtr eventPointer, IntPtr targetPlayerPointer, uint oldWeapon, uint newWeapon)
        {
            if (!PlayerPool.Get(targetPlayerPointer, out var player))
            {
                Console.WriteLine("OnPlayerWeaponChange Invalid player " + targetPlayerPointer);
                return;
            }

            OnPlayerWeaponChangeEvent(eventPointer, player, oldWeapon, newWeapon);
        }

        public virtual void OnPlayerWeaponChangeEvent(IntPtr eventPointer, IPlayer player, uint oldWeapon, uint newWeapon)
        {
            if (!PlayerWeaponChangeEventHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in PlayerWeaponChangeEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(player, oldWeapon, newWeapon))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerWeaponChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerWeaponChangeEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                AltNative.Event.Event_Cancel(eventPointer);
            }
        }
        
        public void OnNetOwnerChange(IntPtr eventPointer, IntPtr targetEntityPointer, BaseObjectType targetEntityType, IntPtr oldNetOwnerPointer, IntPtr newNetOwnerPointer)
        {
            if (!BaseEntityPool.Get(targetEntityPointer, targetEntityType, out var targetEntity))
            {
                Console.WriteLine("OnNetOwnerChange Invalid targetEntity " + targetEntity);
                return;
            }

            PlayerPool.Get(oldNetOwnerPointer, out var oldPlayer);
            PlayerPool.Get(newNetOwnerPointer, out var newPlayer);

            OnNetOwnerChangeEvent(targetEntity, oldPlayer, newPlayer);
        }

        public virtual void OnNetOwnerChangeEvent(IEntity targetEntity, IPlayer oldPlayer, IPlayer newPlayer)
        {
            if (!NetOwnerChangeEventHandler.HasEvents()) return;
            foreach (var @delegate in NetOwnerChangeEventHandler.GetEvents())
            {
                try
                {
                    @delegate(targetEntity, oldPlayer, newPlayer);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnNetOwnerChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnNetOwnerChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleAttach(IntPtr eventPointer, IntPtr targetPointer, IntPtr attachedPointer)
        {
            if (!VehiclePool.Get(targetPointer, out var targetVehicle))
            {
                Console.WriteLine("OnVehicleAttach Invalid targetVehicle " + targetVehicle);
                return;
            }
            
            if (!VehiclePool.Get(attachedPointer, out var attachedVehicle))
            {
                Console.WriteLine("OnVehicleAttach Invalid attachedVehicle " + attachedPointer);
                return;
            }

            OnVehicleAttachEvent(targetVehicle, attachedVehicle);
        }

        public virtual void OnVehicleAttachEvent(IVehicle targetVehicle, IVehicle attachedVehicle)
        {
            if (!VehicleAttachEventHandler.HasEvents()) return;
            foreach (var @delegate in VehicleAttachEventHandler.GetEvents())
            {
                try
                {
                    @delegate(targetVehicle, attachedVehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleAttachEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleAttachEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleDetach(IntPtr eventPointer, IntPtr targetPointer, IntPtr detachedPointer)
        {
            if (!VehiclePool.Get(targetPointer, out var targetVehicle))
            {
                Console.WriteLine("OnVehicleAttach Invalid targetVehicle " + targetVehicle);
                return;
            }
            
            if (!VehiclePool.Get(detachedPointer, out var detachedVehicle))
            {
                Console.WriteLine("OnVehicleDetach Invalid detachedPointer " + detachedPointer);
                return;
            }

            OnVehicleDetachEvent(targetVehicle, detachedVehicle);
        }

        public virtual void OnVehicleDetachEvent(IVehicle targetVehicle, IVehicle detachedVehicle)
        {
            if (!VehicleDetachEventHandler.HasEvents()) return;
            foreach (var @delegate in VehicleDetachEventHandler.GetEvents())
            {
                try
                {
                    @delegate(targetVehicle, detachedVehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDetachEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDetachEvent" + ":" + exception);
                }
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
            MValueFunctionCallback callDelegate = function.Call;
            functionExportHandles.AddFirst(GCHandle.Alloc(callDelegate));
            Alt.Server.CreateMValueFunction(out var mValue,
                AltNative.MValueNative.Invoker_Create(ModuleResource.ResourceImplPtr, callDelegate));
            ModuleResource.SetExport(key, in mValue);
            mValue.Dispose();
        }

        public void Dispose()
        {
            functionExports.Clear();
            foreach (var handle in functionExportHandles)
            {
                handle.Free();
            }

            functionExportHandles.Clear();
            assemblyLoadContext.SetTarget(null);
        }
    }
}