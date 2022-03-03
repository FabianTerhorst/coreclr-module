using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Elements.Args;
using AltV.Net.Client.Elements.Entities;
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
    }
}