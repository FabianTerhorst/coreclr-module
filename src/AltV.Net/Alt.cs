using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        internal static Module Module;

        public static IServer Server => Module.Server;
        
        public static event PlayerConnectDelegate OnPlayerConnect
        {
            add => Module.PlayerConnectEventHandler.Subscribe(value);
            remove => Module.PlayerConnectEventHandler.Unsubscribe(value);
        }
        
        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => Module.PlayerDisconnectEventHandler.Subscribe(value);
            remove => Module.PlayerDisconnectEventHandler.Unsubscribe(value);
        }
        
        public static event EntityRemoveDelegate OnEntityRemove
        {
            add => Module.EntityRemoveEventHandler.Subscribe(value);
            remove => Module.EntityRemoveEventHandler.Unsubscribe(value);
        }

        public static void On(string eventName, Function function)
        {
            Module.On(eventName, function);
        }

        public static void Emit(string eventName, params object[] args)
        {
            Server.TriggerServerEvent(eventName, args);
        }

        public static void Log(string message)
        {
            Server.LogInfo(message);
        }

        internal static void Setup(Module module)
        {
            Module = module;
        }
    }
}