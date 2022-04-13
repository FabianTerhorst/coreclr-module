using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Elements.Interfaces;
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
        
        public static event ConnectionCompleteDelegate OnConnectionComplete
        {
            add => CoreImpl.ConnectionCompleteEventHandler.Add(value);
            remove => CoreImpl.ConnectionCompleteEventHandler.Remove(value);
        }
        
        public static event PlayerChangeVehicleSeatDelegate OnPlayerChangeVehicleSeat
        {
            add => CoreImpl.PlayerChangeVehicleSeatEventHandler.Add(value);
            remove => CoreImpl.PlayerChangeVehicleSeatEventHandler.Remove(value);
        }
        
        public static event PlayerLeaveVehicleDelegate OnPlayerLeaveVehicle
        {
            add => CoreImpl.PlayerLeaveVehicleEventHandler.Add(value);
            remove => CoreImpl.PlayerLeaveVehicleEventHandler.Remove(value);
        }
        
        public static event GlobalMetaChangeDelegate OnGlobalMetaChange
        {
            add => CoreImpl.GlobalMetaChangeEventHandler.Add(value);
            remove => CoreImpl.GlobalMetaChangeEventHandler.Remove(value);
        }
        
        public static event GlobalSyncedMetaChangeDelegate OnGlobalSyncedMetaChange
        {
            add => CoreImpl.GlobalSyncedMetaChangeEventHandler.Add(value);
            remove => CoreImpl.GlobalSyncedMetaChangeEventHandler.Remove(value);
        }
        
        public static event LocalMetaChangeDelegate OnLocalMetaChange
        {
            add => CoreImpl.LocalMetaChangeEventHandler.Add(value);
            remove => CoreImpl.LocalMetaChangeEventHandler.Remove(value);
        }
        
        public static event StreamSyncedMetaChangeDelegate OnStreamSyncedMetaChange
        {
            add => CoreImpl.StreamSyncedMetaChangeEventHandler.Add(value);
            remove => CoreImpl.StreamSyncedMetaChangeEventHandler.Remove(value);
        }
        
        public static event SyncedMetaChangeDelegate OnSyncedMetaChange
        {
            add => CoreImpl.SyncedMetaChangeEventHandler.Add(value);
            remove => CoreImpl.SyncedMetaChangeEventHandler.Remove(value);
        }
        
        public static event TaskChangeDelegate OnTaskChange
        {
            add => CoreImpl.TaskChangeEventHandler.Add(value);
            remove => CoreImpl.TaskChangeEventHandler.Remove(value);
        }
        
        public static event WindowResolutionChangeDelegate OnWindowResolutionChange
        {
            add => CoreImpl.WindowResolutionChangeEventHandler.Add(value);
            remove => CoreImpl.WindowResolutionChangeEventHandler.Remove(value);
        }
        
        public static event WindowFocusChangeDelegate OnWindowFocusChange
        {
            add => CoreImpl.WindowFocusChangeEventHandler.Add(value);
            remove => CoreImpl.WindowFocusChangeEventHandler.Remove(value);
        }
        
        public static event RemoveEntityDelegate OnRemoveEntity
        {
            add => CoreImpl.RemoveEntityEventHandler.Add(value);
            remove => CoreImpl.RemoveEntityEventHandler.Remove(value);
        }
        
        public static event NetOwnerChangeDelegate OnNetOwnerChange
        {
            add => CoreImpl.NetOwnerChangeEventHandler.Add(value);
            remove => CoreImpl.NetOwnerChangeEventHandler.Remove(value);
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

        #region WebView
        public static void On(this IWebView webView, string eventName, Function function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, function);
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4>(this IWebView webView, string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3>(this IWebView webView, string eventName, Action<T1, T2, T3> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2>(this IWebView webView, string eventName, Action<T1, T2> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1>(this IWebView webView, string eventName, Action<T1> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On(this IWebView webView, string eventName, Action function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6, T7>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5, T6>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4, T5>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3, T4>(this IWebView webView, string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2, T3>(this IWebView webView, string eventName, Func<T1, T2, T3> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1, T2>(this IWebView webView, string eventName, Func<T1, T2> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static void On<T1>(this IWebView webView, string eventName, Func<T1> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        #endregion
    }
}