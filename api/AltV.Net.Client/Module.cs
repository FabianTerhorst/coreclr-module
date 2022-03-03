using System.Reflection;
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

        internal readonly IEventHandler<TickDelegate> TickEventHandler =
            new HashSetEventHandler<TickDelegate>();
        
        public void OnServerEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(args);

            if (!ServerEventBus.ContainsKey(name)) return;
            foreach (var function in ServerEventBus[name])
            {
                function.CallCatching(mValues, $"server event {name} handler");
            }
        }
        
        public void OnTick()
        {
            TickEventHandler.GetEvents().ForEachCatching(@delegate => @delegate(), $"event {nameof(OnTick)}");
        }

        public void OnCreatePlayer(IntPtr pointer, ushort id)
        {
            PlayerPool.Create(Core, pointer, id);
        }

        public void OnRemovePlayer(ushort id)
        {
            PlayerPool.Remove(id);
        }

        public void OnCreateVehicle(IntPtr pointer, ushort id)
        {
            VehiclePool.Create(Core, pointer, id);
        }

        public void OnRemoveVehicle(ushort id)
        {
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
    }
}