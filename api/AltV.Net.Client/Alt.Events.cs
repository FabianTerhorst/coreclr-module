using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Events;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static event TickDelegate OnTick
        {
            add => Module.TickEventHandler.Add(value);
            remove => Module.TickEventHandler.Remove(value);
        }
        
        public static event ConsoleCommandDelegate OnConsoleCommand
        {
            add => Module.ConsoleCommandEventHandler.Add(value);
            remove => Module.ConsoleCommandEventHandler.Remove(value);
        }
        
        public static event PlayerSpawnDelegate OnPlayerSpawn
        {
            add => Module.SpawnEventHandler.Add(value);
            remove => Module.SpawnEventHandler.Remove(value);
        }
        
        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => Module.DisconnectEventHandler.Add(value);
            remove => Module.DisconnectEventHandler.Remove(value);
        }
        
        public static event PlayerEnterVehicleDelegate OnPlayerEnterVehicle
        {
            add => Module.EnterVehicleEventHandler.Add(value);
            remove => Module.EnterVehicleEventHandler.Remove(value);
        }
        
        public static void OnServer(string eventName, Function.Function function) => Module.AddServerEventListener(eventName, function);
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3>(string eventName, Action<T1, T2, T3> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2>(string eventName, Action<T1, T2> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1>(string eventName, Action<T1> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer(string eventName, Action function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2, T3>(string eventName, Func<T1, T2, T3> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1, T2>(string eventName, Func<T1, T2> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnServer<T1>(string eventName, Func<T1> function) => Module.AddServerEventListener(eventName, Function.Function.Create(function));
        public static void OnClient(string eventName, Function.Function function) => Module.AddClientEventListener(eventName, function);
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3>(string eventName, Action<T1, T2, T3> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2>(string eventName, Action<T1, T2> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1>(string eventName, Action<T1> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient(string eventName, Action function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2, T3>(string eventName, Func<T1, T2, T3> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1, T2>(string eventName, Func<T1, T2> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
        public static void OnClient<T1>(string eventName, Func<T1> function) => Module.AddClientEventListener(eventName, Function.Function.Create(function));
    }
}