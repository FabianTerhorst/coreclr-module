﻿using System.Numerics;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Events;
using AltV.Net.Client.Extensions;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Events;

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
            new HashSetEventHandler<ConsoleCommandDelegate>(EventType.CONSOLE_COMMAND_EVENT);

        internal readonly IEventHandler<PlayerSpawnDelegate> SpawnEventHandler =
            new HashSetEventHandler<PlayerSpawnDelegate>(EventType.SPAWNED);

        internal readonly IEventHandler<PlayerDisconnectDelegate> DisconnectEventHandler =
            new HashSetEventHandler<PlayerDisconnectDelegate>(EventType.DISCONNECT_EVENT);

        internal readonly IEventHandler<GameEntityCreateDelegate> GameEntityCreateEventHandler =
            new HashSetEventHandler<GameEntityCreateDelegate>(EventType.GAME_ENTITY_CREATE);

        internal readonly IEventHandler<GameEntityDestroyDelegate> GameEntityDestroyEventHandler =
            new HashSetEventHandler<GameEntityDestroyDelegate>(EventType.GAME_ENTITY_DESTROY);

        internal readonly IEventHandler<PlayerEnterVehicleDelegate> EnterVehicleEventHandler =
            new HashSetEventHandler<PlayerEnterVehicleDelegate>(EventType.PLAYER_ENTER_VEHICLE);

        internal readonly IEventHandler<AnyResourceErrorDelegate> AnyResourceErrorEventHandler =
            new HashSetEventHandler<AnyResourceErrorDelegate>(EventType.RESOURCE_ERROR);

        internal readonly IEventHandler<AnyResourceStartDelegate> AnyResourceStartEventHandler =
            new HashSetEventHandler<AnyResourceStartDelegate>(EventType.RESOURCE_START);

        internal readonly IEventHandler<AnyResourceStopDelegate> AnyResourceStopEventHandler =
            new HashSetEventHandler<AnyResourceStopDelegate>(EventType.RESOURCE_STOP);

        internal readonly IEventHandler<KeyUpDelegate> KeyUpEventHandler =
            new HashSetEventHandler<KeyUpDelegate>(EventType.KEYBOARD_EVENT);

        internal readonly IEventHandler<KeyDownDelegate> KeyDownEventHandler =
            new HashSetEventHandler<KeyDownDelegate>(EventType.KEYBOARD_EVENT);

        internal readonly IEventHandler<ConnectionCompleteDelegate> ConnectionCompleteEventHandler =
            new HashSetEventHandler<ConnectionCompleteDelegate>(EventType.CONNECTION_COMPLETE);

        internal readonly IEventHandler<PlayerChangeVehicleSeatDelegate> PlayerChangeVehicleSeatEventHandler =
            new HashSetEventHandler<PlayerChangeVehicleSeatDelegate>(EventType.PLAYER_CHANGE_VEHICLE_SEAT);

        internal readonly IEventHandler<PlayerLeaveVehicleDelegate> PlayerLeaveVehicleEventHandler =
            new HashSetEventHandler<PlayerLeaveVehicleDelegate>(EventType.PLAYER_LEAVE_VEHICLE);

        internal readonly IEventHandler<GlobalMetaChangeDelegate> GlobalMetaChangeEventHandler =
            new HashSetEventHandler<GlobalMetaChangeDelegate>(EventType.GLOBAL_META_CHANGE);

        internal readonly IEventHandler<GlobalSyncedMetaChangeDelegate> GlobalSyncedMetaChangeEventHandler =
            new HashSetEventHandler<GlobalSyncedMetaChangeDelegate>(EventType.GLOBAL_SYNCED_META_CHANGE);

        internal readonly IEventHandler<LocalMetaChangeDelegate> LocalMetaChangeEventHandler =
            new HashSetEventHandler<LocalMetaChangeDelegate>(EventType.LOCAL_SYNCED_META_CHANGE);

        internal readonly IEventHandler<StreamSyncedMetaChangeDelegate> StreamSyncedMetaChangeEventHandler =
            new HashSetEventHandler<StreamSyncedMetaChangeDelegate>(EventType.STREAM_SYNCED_META_CHANGE);

        internal readonly IEventHandler<SyncedMetaChangeDelegate> SyncedMetaChangeEventHandler =
            new HashSetEventHandler<SyncedMetaChangeDelegate>(EventType.SYNCED_META_CHANGE);

        internal readonly IEventHandler<TaskChangeDelegate> TaskChangeEventHandler =
            new HashSetEventHandler<TaskChangeDelegate>(EventType.TASK_CHANGE);

        internal readonly IEventHandler<WindowResolutionChangeDelegate> WindowResolutionChangeEventHandler =
            new HashSetEventHandler<WindowResolutionChangeDelegate>(EventType.WINDOW_RESOLUTION_CHANGE);

        internal readonly IEventHandler<WindowFocusChangeDelegate> WindowFocusChangeEventHandler =
            new HashSetEventHandler<WindowFocusChangeDelegate>(EventType.WINDOW_FOCUS_CHANGE);

        internal readonly IEventHandler<RemoveEntityDelegate> RemoveEntityEventHandler =
            new HashSetEventHandler<RemoveEntityDelegate>(EventType.REMOVE_ENTITY_EVENT);

        internal readonly IEventHandler<NetOwnerChangeDelegate> NetOwnerChangeEventHandler =
            new HashSetEventHandler<NetOwnerChangeDelegate>(EventType.NETOWNER_CHANGE);

        internal readonly IEventHandler<PlayerChangeAnimationDelegate> PlayerChangeAnimationEventHandler =
            new HashSetEventHandler<PlayerChangeAnimationDelegate>(EventType.PLAYER_CHANGE_ANIMATION_EVENT);

        internal readonly IEventHandler<PlayerChangeInteriorDelegate> PlayerChangeInteriorEventHandler =
            new HashSetEventHandler<PlayerChangeInteriorDelegate>(EventType.PLAYER_CHANGE_INTERIOR_EVENT);

        internal readonly IEventHandler<PlayerWeaponShootDelegate> PlayerWeaponShootEventHandler =
            new HashSetEventHandler<PlayerWeaponShootDelegate>(EventType.PLAYER_WEAPON_SHOOT_EVENT);

        internal readonly IEventHandler<PlayerWeaponChangeDelegate> PlayerWeaponChangeEventHandler =
            new HashSetEventHandler<PlayerWeaponChangeDelegate>(EventType.PLAYER_WEAPON_CHANGE);


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
                function.InvokeNoResult(new object[] {mValue});
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

        public void OnKeyDown(Key key)
        {
            KeyDownEventHandler.GetEvents().ForEachCatching(fn => fn(key), $"event {nameof(OnKeyDown)}");
        }

        public void OnKeyUp(Key key)
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

        public void OnCreateObject(IntPtr pointer, ushort id)
        {
            Alt.Log("Creating object " + id + " " + pointer);
            ObjectPool.Create(this, pointer, id);
        }

        public void OnRemoveObject(IntPtr pointer)
        {
            Alt.Log("Removing object " + pointer);
            ObjectPool.Remove(pointer);
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
        public void OnPlayerChangeAnimation(IntPtr playerPtr, uint oldDict, uint newDict, uint oldName, uint newName)
        {
            var player = PlayerPool.Get(playerPtr);
            if (player == null)
            {
                Alt.LogWarning("OnPlayerChangeAnimation: Invalid player " + playerPtr);
                return;
            }
            
            PlayerChangeAnimationEventHandler.GetEvents().ForEachCatching(fn => fn(player, oldDict, newDict, oldName, newName), $"event {nameof(OnPlayerChangeAnimation)}");
        }
        
        public void OnPlayerChangeInterior(IntPtr playerPtr, uint oldIntLoc, uint newIntLoc)
        {
            var player = PlayerPool.Get(playerPtr);
            if (player == null)
            {
                Alt.LogWarning("OnPlayerChangeInterior: Invalid player " + playerPtr);
                return;
            }
            
            PlayerChangeInteriorEventHandler.GetEvents().ForEachCatching(fn => fn(player, oldIntLoc, newIntLoc), $"event {nameof(OnPlayerChangeInterior)}");
        }

        public void OnPlayerWeaponShoot(uint weapon, ushort totalAmmo, ushort ammoInClip)
        {
            PlayerWeaponShootEventHandler.GetEvents().ForEachCatching(fn => fn(weapon, totalAmmo, ammoInClip), $"event {nameof(OnPlayerWeaponShoot)}");
        }

        public void OnPlayerWeaponChange(uint oldWeapon, uint newWeapon)
        {
            PlayerWeaponChangeEventHandler.GetEvents().ForEachCatching(fn => fn(oldWeapon, newWeapon), $"event {nameof(OnPlayerWeaponChange)}");
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

        public void OnBlipCreate(IntPtr blipPtr)
        {
            BlipPool.Create(this, blipPtr);
        }

        public void OnWebViewCreate(IntPtr webViewPtr)
        {
            WebViewPool.Create(this, webViewPtr);
        }

        public void OnCheckpointCreate(IntPtr checkpointPtr)
        {
            CheckpointPool.Create(this, checkpointPtr);
        }

        public void OnWebSocketClientCreate(IntPtr webSocketClientPtr)
        {
            WebViewPool.Create(this, webSocketClientPtr);
        }

        public void OnHttpClientCreate(IntPtr httpClientPtr)
        {
            HttpClientPool.Create(this, httpClientPtr);
        }

        public void OnAudioCreate(IntPtr audioPtr)
        {
            AudioPool.Create(this, audioPtr);
        }

        public void OnRmlElementCreate(IntPtr rmlElementPtr)
        {
            RmlElementPool.Create(this, rmlElementPtr);
        }

        public void OnRmlDocumentCreate(IntPtr rmlDocumentPtr)
        {
            RmlDocumentPool.Create(this, rmlDocumentPtr);
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
            if (function is null)
            {
                Alt.LogWarning("Failed to register server event " + eventName + ": function is null");
                return null;
            }
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


        public bool RemoveServerEventListener(string eventName, Function function)
        {
            if (function is null)
            {
                Alt.LogWarning("Failed to unregister server event " + eventName + ": function is null");
                return false;
            }

            if (ServerEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }

            return true;
        }


        public Function AddClientEventListener(string eventName, Function function)
        {
            if (function is null)
            {
                Alt.LogWarning("Failed to register client event " + eventName + ": function is null");
                return null;
            }
            
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

        public bool RemoveClientEventListener(string eventName, Function function)
        {
            if (function is null)
            {
                Alt.LogWarning("Failed to unregister client event " + eventName + ": function is null");
                return false;
            }

            if (ClientEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }

            return true;
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


        public bool RemoveWebViewEventListener(IntPtr webViewPtr, string name, Function function)
        {
            if (function is null)
            {
                Alt.LogWarning("Failed to unregister WebView event " + name + ": function is null");
                return false;
            }

            if (WebViewEventBus.TryGetValue(webViewPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Remove(function);
                }
            }

            return true;
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