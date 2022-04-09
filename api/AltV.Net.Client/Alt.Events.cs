using AltV.Net.Client.Events;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static event TickDelegate OnTick
        {
            add => CoreImpl.TickEventHandler.Add(value);
            remove => CoreImpl.TickEventHandler.Remove(value);
        }
        
        public static event ConsoleCommandDelegate OnConsoleCommand
        {
            add => CoreImpl.ConsoleCommandEventHandler.Add(value);
            remove => CoreImpl.ConsoleCommandEventHandler.Remove(value);
        }
        
        public static event PlayerSpawnDelegate OnPlayerSpawn
        {
            add => CoreImpl.SpawnEventHandler.Add(value);
            remove => CoreImpl.SpawnEventHandler.Remove(value);
        }
        
        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => CoreImpl.DisconnectEventHandler.Add(value);
            remove => CoreImpl.DisconnectEventHandler.Remove(value);
        }
        
        public static event PlayerEnterVehicleDelegate OnPlayerEnterVehicle
        {
            add => CoreImpl.EnterVehicleEventHandler.Add(value);
            remove => CoreImpl.EnterVehicleEventHandler.Remove(value);
        }
        
        public static event GameEntityCreateDelegate OnGameEntityCreate
        {
            add => CoreImpl.GameEntityCreateEventHandler.Add(value);
            remove => CoreImpl.GameEntityCreateEventHandler.Remove(value);
        }
        
        public static event GameEntityDestroyDelegate OnGameEntityDestroy
        {
            add => CoreImpl.GameEntityDestroyEventHandler.Add(value);
            remove => CoreImpl.GameEntityDestroyEventHandler.Remove(value);
        }
        
        public static event ResourceErrorDelegate OnResourceError
        {
            add => CoreImpl.ResourceErrorEventHandler.Add(value);
            remove => CoreImpl.ResourceErrorEventHandler.Remove(value);
        }
        
        public static event ResourceStartDelegate OnResourceStart
        {
            add => CoreImpl.ResourceStartEventHandler.Add(value);
            remove => CoreImpl.ResourceStartEventHandler.Remove(value);
        }
        
        public static event ResourceStopDelegate OnResourceStop
        {
            add => CoreImpl.ResourceStopEventHandler.Add(value);
            remove => CoreImpl.ResourceStopEventHandler.Remove(value);
        }
        
        public static event KeyUpDelegate OnKeyUp
        {
            add => CoreImpl.KeyUpEventHandler.Add(value);
            remove => CoreImpl.KeyUpEventHandler.Remove(value);
        }
        
        public static event KeyDownDelegate OnKeyDown
        {
            add => CoreImpl.KeyDownEventHandler.Add(value);
            remove => CoreImpl.KeyDownEventHandler.Remove(value);
        }
        
        public static void OnServer(string eventName, Function function) => CoreImpl.AddServerEventListener(eventName, function);
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3>(string eventName, Action<T1, T2, T3> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2>(string eventName, Action<T1, T2> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1>(string eventName, Action<T1> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer(string eventName, Action function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2, T3>(string eventName, Func<T1, T2, T3> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1, T2>(string eventName, Func<T1, T2> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnServer<T1>(string eventName, Func<T1> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static void OnClient(string eventName, Function function) => CoreImpl.AddClientEventListener(eventName, function);
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3>(string eventName, Action<T1, T2, T3> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2>(string eventName, Action<T1, T2> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1>(string eventName, Action<T1> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient(string eventName, Action function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2, T3>(string eventName, Func<T1, T2, T3> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1, T2>(string eventName, Func<T1, T2> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static void OnClient<T1>(string eventName, Func<T1> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
    }
}