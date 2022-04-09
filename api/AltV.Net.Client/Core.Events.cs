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
            Alt.Log("-- Creating vehicle " + id + " " + pointer);
            VehiclePool.Create(this, pointer, id);
        }

        public void OnRemoveVehicle(IntPtr pointer)
        {
            Alt.Log("-- Removing vehicle " + pointer);
            VehiclePool.Remove(pointer);
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
    }
}