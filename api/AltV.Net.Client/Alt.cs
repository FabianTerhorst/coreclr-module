using System.Collections.Generic;
using AltV.Net.Client.Events;
using WebAssembly;

namespace AltV.Net.Client
{
    public static class Alt
    {
        private static NativeAlt _alt;

        public static NativeNatives Natives;

        private static readonly IDictionary<string, NativeEventHandler<NativeEventDelegate, ServerEventDelegate>>
            NativeServerEventHandlers =
                new Dictionary<string, NativeEventHandler<NativeEventDelegate, ServerEventDelegate>>();

        private static readonly IDictionary<string, NativeEventHandler<NativeEventDelegate, ServerEventDelegate>>
            NativeEventHandlers =
                new Dictionary<string, NativeEventHandler<NativeEventDelegate, ServerEventDelegate>>();

        private static NativeEventHandler<ConnectionCompleteEventDelegate, ConnectionCompleteEventDelegate>
            _nativeConnectionCompleteHandler;

        private static NativeEventHandler<DisconnectEventDelegate, DisconnectEventDelegate> _nativeDisconnectHandler;
        
        private static NativeEventHandler<EveryTickEventDelegate, EveryTickEventDelegate> _nativeEveryTickHandler;

        public static event ConnectionCompleteEventDelegate OnConnectionComplete
        {
            add
            {
                if (_nativeConnectionCompleteHandler == null)
                {
                    _nativeConnectionCompleteHandler = new NativeConnectionCompleteEventHandler();
                    _alt.On("connectionComplete", _nativeConnectionCompleteHandler.GetNativeEventHandler());
                }

                _nativeConnectionCompleteHandler.Add(value);
            }
            remove => _nativeConnectionCompleteHandler?.Remove(value);
        }

        public static event DisconnectEventDelegate OnDisconnect
        {
            add
            {
                if (_nativeDisconnectHandler == null)
                {
                    _nativeDisconnectHandler = new NativeDisconnectEventHandler();
                    _alt.On("disconnect", _nativeDisconnectHandler.GetNativeEventHandler());
                }

                _nativeDisconnectHandler.Add(value);
            }
            remove => _nativeDisconnectHandler?.Remove(value);
        }
        
        public static event EveryTickEventDelegate EveryTick
        {
            add
            {
                if (_nativeEveryTickHandler == null)
                {
                    _nativeEveryTickHandler = new NativeEveryTickEventHandler();
                    _alt.EveryTick(_nativeEveryTickHandler.GetNativeEventHandler());
                }

                _nativeEveryTickHandler.Add(value);
            }
            remove => _nativeEveryTickHandler?.Remove(value);
        }

        public static void Init(object alt, object natives)
        {
            _alt = new NativeAlt((JSObject) alt);
            Natives = new NativeNatives((JSObject) natives);
        }

        public static void Log(string message)
        {
            _alt.Log(message);
        }

        public static void Emit(string eventName, params object[] args)
        {
            _alt.Emit(eventName, args);
        }

        public static void OnServer(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (!NativeServerEventHandlers.TryGetValue(eventName, out var nativeEventHandler))
            {
                nativeEventHandler = new NativeServerEventHandler();
                _alt.OnServer(eventName, nativeEventHandler.GetNativeEventHandler());
                NativeServerEventHandlers[eventName] = nativeEventHandler;
            }

            nativeEventHandler.Add(serverEventDelegate);
        }

        public static void OffServer(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (!NativeServerEventHandlers.TryGetValue(eventName, out var nativeEventHandler))
            {
                return;
            }

            nativeEventHandler.Remove(serverEventDelegate);
        }

        public static void On(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (!NativeEventHandlers.TryGetValue(eventName, out var nativeEventHandler))
            {
                nativeEventHandler = new NativeServerEventHandler();
                _alt.On(eventName, nativeEventHandler.GetNativeEventHandler());
                NativeEventHandlers[eventName] = nativeEventHandler;
            }

            nativeEventHandler.Add(serverEventDelegate);
        }

        public static void Off(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (!NativeEventHandlers.TryGetValue(eventName, out var nativeEventHandler))
            {
                return;
            }

            nativeEventHandler.Remove(serverEventDelegate);
        }
    }
}