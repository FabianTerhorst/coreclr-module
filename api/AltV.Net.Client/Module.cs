using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Elements.Args;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Enums;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Client.Events;
using AltV.Net.Client.Extensions;

namespace AltV.Net.Client
{
    public class Module
    {
        internal readonly ICore Core;
        
        internal PlayerPool PlayerPool;
        internal IEntityPool<IVehicle> VehiclePool;

        public List<SafeTimer> RunningTimers { get; } = new();
    
        public Module(ICore core)
        {
            Alt.Init(this);
            Core = core;
        }
        
        internal void InitPools(PlayerPool playerPool, IEntityPool<IVehicle> vehiclePool)
        {
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
        }

        private Dictionary<string, HashSet<Function.Function>> ServerEventBus = new();
        private Dictionary<string, HashSet<Function.Function>> ClientEventBus = new();

        internal readonly IEventHandler<TickDelegate> TickEventHandler =
            new HashSetEventHandler<TickDelegate>();

        internal readonly IEventHandler<ConsoleCommandDelegate> ConsoleCommandEventHandler =
            new HashSetEventHandler<ConsoleCommandDelegate>();
        
        internal readonly IEventHandler<PlayerSpawnDelegate> SpawnEventHandler =
            new HashSetEventHandler<PlayerSpawnDelegate>();
        
        internal readonly IEventHandler<PlayerDisconnectDelegate> DisconnectEventHandler =
            new HashSetEventHandler<PlayerDisconnectDelegate>();
        
        internal readonly IEventHandler<PlayerEnterVehicleDelegate> EnterVehicleEventHandler =
            new HashSetEventHandler<PlayerEnterVehicleDelegate>();
        
        internal readonly IEventHandler<ResourceErrorDelegate> ResourceErrorEventHandler =
            new HashSetEventHandler<ResourceErrorDelegate>();
        
        internal readonly IEventHandler<ResourceStartDelegate> ResourceStartEventHandler =
            new HashSetEventHandler<ResourceStartDelegate>();
        
        internal readonly IEventHandler<ResourceStopDelegate> ResourceStopEventHandler =
            new HashSetEventHandler<ResourceStopDelegate>();
        
        internal readonly IEventHandler<KeyUpDelegate> KeyUpEventHandler =
            new HashSetEventHandler<KeyUpDelegate>();
        
        internal readonly IEventHandler<KeyDownDelegate> KeyDownEventHandler =
            new HashSetEventHandler<KeyDownDelegate>();

        public void OnServerEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(args);

            if (!ServerEventBus.ContainsKey(name)) return;
            foreach (var function in ServerEventBus[name])
            {
                function.CallCatching(mValues, $"server event {name} handler");
            }
        }
        
        public void OnClientEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(args);

            if (!ClientEventBus.ContainsKey(name)) return;
            foreach (var function in ClientEventBus[name])
            {
                function.CallCatching(mValues, $"client event {name} handler");
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

        public void OnPlayerEnterVehicle(ushort id, byte seat)
        {
            VehiclePool.Get(id, out var vehicle);
            EnterVehicleEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, seat), $"event {nameof(OnPlayerEnterVehicle)}");
        }

        public void OnResourceError(string name)
        {
            ResourceErrorEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnResourceError)} \"{name}\"");
        }
        
        public void OnResourceStart(string name)
        {
            ResourceStartEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnResourceStart)} \"{name}\"");
        }
        
        public void OnResourceStop(string name)
        {
            ResourceStopEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnResourceStop)} \"{name}\"");
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
            Alt.Log("Creating player " + id);
            PlayerPool.Create(Core, pointer, id);
        }

        public void OnRemovePlayer(ushort id)
        {
            Alt.Log("Removing player " + id);
            PlayerPool.Remove(id);
        }

        public void OnCreateVehicle(IntPtr pointer, ushort id)
        {
            Alt.Log("Creating vehicle " + id);
            VehiclePool.Create(Core, pointer, id);
        }

        public void OnRemoveVehicle(ushort id)
        {
            Alt.Log("Removing vehicle " + id);
            VehiclePool.Remove(id);
        }
        
        public Function.Function AddServerEventListener(string eventName, Function.Function function)
        {
            if (ServerEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function.Function> {function};
                ServerEventBus[eventName] = eventHandlers;
            }

            return function;
        }
        
        public Function.Function AddClientEventListener(string eventName, Function.Function function)
        {
            if (ClientEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function.Function> {function};
                ClientEventBus[eventName] = eventHandlers;
            }

            return function;
        }

        public bool GetEntityById(ushort id, [MaybeNullWhen(false)] out IEntity entity)
        {
            unsafe
            {
                byte type = 0;
                entity = default;
                if (this.Core.Library.Entity_GetTypeByID(this.Core.NativePointer, id, &type) != 1) return false;
                
                switch ((BaseObjectType) type)
                {
                    case BaseObjectType.Player:
                    case BaseObjectType.LocalPlayer:
                    {
                        PlayerPool.Get(id, out var player);
                        entity = player;
                        return true;
                    }
                    case BaseObjectType.Vehicle:
                    {
                        VehiclePool.Get(id, out var vehicle);
                        entity = vehicle;
                        return true;
                    }
                    // todo
                    default:
                        return false;
                }
            }
        }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                var success = Core.Library.Vehicle_Handling_GetByModelHash(Core.NativePointer, modelHash, &pointer);
                if (success == 0 || pointer == IntPtr.Zero) return null;
                return new HandlingData(Core, pointer);
            }
        }
    }
}