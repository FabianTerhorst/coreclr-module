using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Events;
using AltV.Net.Client.Extensions;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client
{
    public partial class Core
    {
        private Dictionary<string, HashSet<Function>> ServerEventBus = new();
        private Dictionary<string, HashSet<Function>> ClientEventBus = new();
        private Dictionary<IntPtr, Dictionary<string, HashSet<Function>>> WebViewEventBus = new();
        private Dictionary<IntPtr, Dictionary<string, HashSet<Function>>> RmlElementEventBus = new();
        private Dictionary<IntPtr, Dictionary<string, HashSet<Function>>> WebSocketEventBus = new();

        internal readonly IEventHandler<TickDelegate> TickEventHandler =
            new HashSetEventHandler<TickDelegate>();

        internal readonly IEventHandler<ConsoleCommandDelegate> ConsoleCommandEventHandler =
            new HashSetEventHandler<ConsoleCommandDelegate>();
        
        internal readonly IEventHandler<PlayerSpawnDelegate> SpawnEventHandler =
            new HashSetEventHandler<PlayerSpawnDelegate>();
        
        internal readonly IEventHandler<PlayerDisconnectDelegate> DisconnectEventHandler =
            new HashSetEventHandler<PlayerDisconnectDelegate>();
        
        internal readonly IEventHandler<GameEntityCreateDelegate> GameEntityCreateEventHandler =
            new HashSetEventHandler<GameEntityCreateDelegate>();
        
        internal readonly IEventHandler<GameEntityDestroyDelegate> GameEntityDestroyEventHandler =
            new HashSetEventHandler<GameEntityDestroyDelegate>();
        
        internal readonly IEventHandler<PlayerEnterVehicleDelegate> EnterVehicleEventHandler =
            new HashSetEventHandler<PlayerEnterVehicleDelegate>();
        
        internal readonly IEventHandler<AnyResourceErrorDelegate> AnyResourceErrorEventHandler =
            new HashSetEventHandler<AnyResourceErrorDelegate>();
        
        internal readonly IEventHandler<AnyResourceStartDelegate> AnyResourceStartEventHandler =
            new HashSetEventHandler<AnyResourceStartDelegate>();
        
        internal readonly IEventHandler<AnyResourceStopDelegate> AnyResourceStopEventHandler =
            new HashSetEventHandler<AnyResourceStopDelegate>();
        
        internal readonly IEventHandler<KeyUpDelegate> KeyUpEventHandler =
            new HashSetEventHandler<KeyUpDelegate>();
        
        internal readonly IEventHandler<KeyDownDelegate> KeyDownEventHandler =
            new HashSetEventHandler<KeyDownDelegate>();
        
        internal readonly IEventHandler<ConnectionCompleteDelegate> ConnectionCompleteEventHandler =
            new HashSetEventHandler<ConnectionCompleteDelegate>();
        
        internal readonly IEventHandler<PlayerChangeVehicleSeatDelegate> PlayerChangeVehicleSeatEventHandler =
            new HashSetEventHandler<PlayerChangeVehicleSeatDelegate>();
        
        internal readonly IEventHandler<PlayerLeaveVehicleDelegate> PlayerLeaveVehicleEventHandler =
            new HashSetEventHandler<PlayerLeaveVehicleDelegate>();

        internal readonly IEventHandler<GlobalMetaChangeDelegate> GlobalMetaChangeEventHandler =
            new HashSetEventHandler<GlobalMetaChangeDelegate>();
        
        internal readonly IEventHandler<GlobalSyncedMetaChangeDelegate> GlobalSyncedMetaChangeEventHandler =
            new HashSetEventHandler<GlobalSyncedMetaChangeDelegate>();
        
        internal readonly IEventHandler<LocalMetaChangeDelegate> LocalMetaChangeEventHandler =
            new HashSetEventHandler<LocalMetaChangeDelegate>();
        
        internal readonly IEventHandler<StreamSyncedMetaChangeDelegate> StreamSyncedMetaChangeEventHandler =
            new HashSetEventHandler<StreamSyncedMetaChangeDelegate>();
        
        internal readonly IEventHandler<SyncedMetaChangeDelegate> SyncedMetaChangeEventHandler =
            new HashSetEventHandler<SyncedMetaChangeDelegate>();
        
        internal readonly IEventHandler<TaskChangeDelegate> TaskChangeEventHandler =
            new HashSetEventHandler<TaskChangeDelegate>();
        
        internal readonly IEventHandler<WindowResolutionChangeDelegate> WindowResolutionChangeEventHandler =
            new HashSetEventHandler<WindowResolutionChangeDelegate>();

        internal readonly IEventHandler<WindowFocusChangeDelegate> WindowFocusChangeEventHandler =
            new HashSetEventHandler<WindowFocusChangeDelegate>();
        
        internal readonly IEventHandler<RemoveEntityDelegate> RemoveEntityEventHandler =
            new HashSetEventHandler<RemoveEntityDelegate>();
        
        internal readonly IEventHandler<NetOwnerChangeDelegate> NetOwnerChangeEventHandler =
            new HashSetEventHandler<NetOwnerChangeDelegate>();

        public void OnServerEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);

            if (!ServerEventBus.ContainsKey(name)) return;
            foreach (var function in ServerEventBus[name])
            {
                function.CallCatching(mValues, $"server event {name} handler");
            }
        }
        
        public void OnClientEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);

            if (!ClientEventBus.ContainsKey(name)) return;
            foreach (var function in ClientEventBus[name])
            {
                function.CallCatching(mValues, $"client event {name} handler");
            }
        }
        
        public void OnWebViewEvent(IntPtr webViewPtr, string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);
            if (!WebViewEventBus.ContainsKey(webViewPtr)) return;
            WebViewEventBus.TryGetValue(webViewPtr, out var handlers);
            if (handlers == null) return;
            if (!handlers.ContainsKey(name)) return;
            foreach (var function in handlers[name])
            {
                function.CallCatching(mValues, $"web view event {name} handler");
            }
        }
        
        public void OnRmlElementEvent(IntPtr rmlElementPtr, string name, IntPtr[] args)
        {
            var mValue = new MValueConst(this, args[0]);
            if (mValue.type != MValueConst.Type.Dict)
            {
                LogInfo("OnRmlElementEvent: Args are not dict");
                return;
            }
            if (!RmlElementEventBus.ContainsKey(rmlElementPtr)) return;
            RmlElementEventBus.TryGetValue(rmlElementPtr, out var handlers);
            if (handlers == null) return;
            if (!handlers.ContainsKey(name)) return;
            foreach (var function in handlers[name])
            {
                function.InvokeNoResult(new object[] { mValue });
            }
        }
        
        public void OnConsoleCommand(string name, string[] args)
        {
            ConsoleCommandEventHandler.GetEvents().ForEachCatching(fn => fn(name, args), $"event {nameof(OnConsoleCommand)} \"{name}\"");
        }
        
        public void OnTick()
        {
            TickEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnTick)}");
        }

        public void OnPlayerSpawn()
        {
            SpawnEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnPlayerSpawn)}");
        }
        
        public void OnPlayerDisconnect()
        {
            DisconnectEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnPlayerDisconnect)}");
        }

        public void OnPlayerEnterVehicle(IntPtr pointer, byte seat)
        {
            var vehicle = VehiclePool.Get(pointer);
            if (vehicle is null)
            {
                Console.WriteLine("Invalid vehicle: " + pointer);
                return;
            }

            EnterVehicleEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, seat), $"event {nameof(OnPlayerEnterVehicle)}");
        }

        public void OnGameEntityCreate(IntPtr pointer, byte type)
        {
            Console.WriteLine("Type was " + ((BaseObjectType) type));
            var baseObject = BaseBaseObjectPool.Get(pointer, (BaseObjectType) type);
            if (baseObject is not IEntity entity)
            {
                Console.WriteLine("Invalid entity: " + pointer + " " + (baseObject == null));
                return;
            }

            GameEntityCreateEventHandler.GetEvents().ForEachCatching(fn => fn(entity), $"event {nameof(OnGameEntityCreate)}");
        }

        public void OnGameEntityDestroy(IntPtr pointer, byte type)
        {
            var baseObject = BaseBaseObjectPool.Get(pointer, (BaseObjectType) type);
            if (baseObject is not IEntity entity)
            {
                Console.WriteLine("Invalid entity: " + pointer);
                return;
            }

            GameEntityDestroyEventHandler.GetEvents().ForEachCatching(fn => fn(entity), $"event {nameof(OnGameEntityDestroy)}");
        }

        public void OnAnyResourceError(string name)
        {
            AnyResourceErrorEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnAnyResourceError)} \"{name}\"");
        }
        
        public void OnAnyResourceStart(string name)
        {
            AnyResourceStartEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnAnyResourceStart)} \"{name}\"");
        }
        
        public void OnAnyResourceStop(string name)
        {
            AnyResourceStopEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnAnyResourceStop)} \"{name}\"");
        }
        
        public void OnKeyDown(ConsoleKey key)
        {
            KeyDownEventHandler.GetEvents().ForEachCatching(fn => fn(key), $"event {nameof(OnKeyDown)}");
        }
        
        public void OnKeyUp(ConsoleKey key)
        {
            KeyUpEventHandler.GetEvents().ForEachCatching(fn => fn(key), $"event {nameof(OnKeyUp)}");
        }
        
        public void OnCreatePlayer(IntPtr pointer, ushort id)
        {
            Alt.Log("Creating player " + id + " " + pointer);
            PlayerPool.Create(this, pointer, id);
        }

        public void OnRemovePlayer(IntPtr pointer)
        {
            Alt.Log("Removing player " + pointer);
            PlayerPool.Remove(pointer);
        }

        public void OnCreateVehicle(IntPtr pointer, ushort id)
        {
            Alt.Log("Creating vehicle " + id + " " + pointer);
            VehiclePool.Create(this, pointer, id);
        }

        public void OnRemoveVehicle(IntPtr pointer)
        {
            Alt.Log("Removing vehicle " + pointer);
            VehiclePool.Remove(pointer);
        }

        public void OnConnectionComplete()
        {
            ConnectionCompleteEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnConnectionComplete)}");
        }

        public void OnGlobalMetaChange(string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            GlobalMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnGlobalMetaChange)}");
        }

        public void OnGlobalSyncedMetaChange(string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            GlobalSyncedMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnGlobalSyncedMetaChange)}");
        }

        public void OnPlayerChangeVehicleSeat(IntPtr vehiclePtr, byte oldSeat, byte newSeat)
        {
            var vehicle = VehiclePool.Get(vehiclePtr);
            PlayerChangeVehicleSeatEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, oldSeat, newSeat), $"event {nameof(OnPlayerChangeVehicleSeat)}");
        }

        public void OnLocalMetaChange(string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            LocalMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnLocalMetaChange)}");
        }
        
        public void OnStreamSyncedMetaChange(IntPtr targetPtr, BaseObjectType type, string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            BaseEntityPool.Get(targetPtr, type, out var target);
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            StreamSyncedMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnStreamSyncedMetaChange)}");
        }
        
        public void OnSyncedMetaChange(IntPtr targetPtr, BaseObjectType type, string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            BaseEntityPool.Get(targetPtr, type, out var target);
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            SyncedMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnSyncedMetaChange)}");
        }

        public void OnTaskChange(int oldTask, int newTask)
        {
            TaskChangeEventHandler.GetEvents().ForEachCatching(fn => fn(oldTask, newTask), $"event {nameof(OnTaskChange)}");
        }

        public void OnWindowFocusChange(byte state)
        {
            WindowFocusChangeEventHandler.GetEvents().ForEachCatching(fn => fn(state != 0), $"event {nameof(OnWindowFocusChange)}");
        }
        
        public void OnWindowResolutionChange(Vector2 oldRes, Vector2 newRes)
        {
            WindowResolutionChangeEventHandler.GetEvents().ForEachCatching(fn => fn(oldRes, newRes), $"event {nameof(OnWindowResolutionChange)}");
        }

        public void OnNetOwnerChange(IntPtr targetPtr, BaseObjectType type, IntPtr newOwnerPtr, IntPtr oldOwnerPtr)
        {
            BaseEntityPool.Get(targetPtr, type, out var target);
            var newOwner = newOwnerPtr == IntPtr.Zero ? null : PlayerPool.Get(newOwnerPtr);
            var oldOwner = oldOwnerPtr == IntPtr.Zero ? null : PlayerPool.Get(oldOwnerPtr);
            NetOwnerChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, newOwner, oldOwner), $"event {nameof(OnNetOwnerChange)}");
        }

        public void OnRemoveEntity(IntPtr targetPtr, BaseObjectType type)
        {
            BaseEntityPool.Get(targetPtr, type, out var target);
            RemoveEntityEventHandler.GetEvents().ForEachCatching(fn => fn(target), $"event {nameof(OnRemoveEntity)}");
        }

        public void OnPlayerLeaveVehicle(IntPtr vehiclePtr, byte seat)
        {
            var vehicle = VehiclePool.Get(vehiclePtr);
            PlayerLeaveVehicleEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, seat), $"event {nameof(OnPlayerLeaveVehicle)}");
        }

        public void OnBlipRemove(IntPtr blipPtr)
        {
            BlipPool.Remove(blipPtr);
        }

        public void OnWebViewRemove(IntPtr webViewPtr)
        {
            WebViewPool.Remove(webViewPtr);
        }

        public void OnCheckpointRemove(IntPtr checkpointPtr)
        {
            CheckpointPool.Remove(checkpointPtr);
        }

        public void OnWebSocketClientRemove(IntPtr webSocketClientPtr)
        {
            WebViewPool.Remove(webSocketClientPtr);
        }
        
        public void OnHttpClientRemove(IntPtr httpClientPtr)
        {
            HttpClientPool.Remove(httpClientPtr);
        }
        
        public void OnAudioRemove(IntPtr audioPtr)
        {
            AudioPool.Remove(audioPtr);
        }
        
        public void OnRmlElementRemove(IntPtr rmlElementPtr)
        {
            RmlElementPool.Remove(rmlElementPtr);
        }
        
        public void OnRmlDocumentRemove(IntPtr rmlDocumentPtr)
        {
            RmlDocumentPool.Remove(rmlDocumentPtr);
        }
        
        public Function AddServerEventListener(string eventName, Function function)
        {
            if (ServerEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function> {function};
                ServerEventBus[eventName] = eventHandlers;
            }

            return function;
        }
        
        public Function AddClientEventListener(string eventName, Function function)
        {
            if (ClientEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function> {function};
                ClientEventBus[eventName] = eventHandlers;
            }

            return function;
        }

        public Function AddWebViewEventListener(IntPtr webViewPtr, string name, Function function)
        {
            if (WebViewEventBus.TryGetValue(webViewPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Add(function);
                }
                else
                {
                    eventHandler = new HashSet<Function> {function};
                    eventHandlers[name] = eventHandler;
                }
            }
            else
            {
                eventHandlers = new Dictionary<string, HashSet<Function>> {{name, new HashSet<Function> {function}}};
                WebViewEventBus[webViewPtr] = eventHandlers;
            }
            return function;
        }
        
        public Function AddRmlElementEventListener(IntPtr rmlElementPtr, string name, Function function)
        {
            if (RmlElementEventBus.TryGetValue(rmlElementPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Add(function);
                }
                else
                {
                    eventHandler = new HashSet<Function> {function};
                    eventHandlers[name] = eventHandler;
                }
            }
            else
            {
                eventHandlers = new Dictionary<string, HashSet<Function>> {{name, new HashSet<Function> {function}}};
                RmlElementEventBus[rmlElementPtr] = eventHandlers;
            }
            return function;
        }

        public Function AddWebSocketEventListener(IntPtr websocketPtr, string name, Function function)
        {
            if (WebSocketEventBus.TryGetValue(websocketPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Add(function);
                }
                else
                {
                    eventHandler = new HashSet<Function> {function};
                    eventHandlers[name] = eventHandler;
                }
            }
            else
            {
                eventHandlers = new Dictionary<string, HashSet<Function>> {{name, new HashSet<Function> {function}}};
                WebSocketEventBus[websocketPtr] = eventHandlers;
            }
            return function;
        }
    }
}