using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        private static Module _module;

        public static Server Server => _module.Server;
        
        public static event PlayerConnectDelegate OnPlayerConnect
        {
            add => _module.PlayerConnectEventHandler.Subscribe(value);
            remove => _module.PlayerConnectEventHandler.Unsubscribe(value);
        }
        
        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => _module.PlayerDisconnectEventHandler.Subscribe(value);
            remove => _module.PlayerDisconnectEventHandler.Unsubscribe(value);
        }
        
        public static event EntityRemoveDelegate OnEntityRemove
        {
            add => _module.EntityRemoveEventHandler.Subscribe(value);
            remove => _module.EntityRemoveEventHandler.Unsubscribe(value);
        }

        public static void On(string eventName, Function function)
        {
            _module.On(eventName, function);
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
            _module = module;
        }
    }
}