using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization.Json;
using AltV.Net.Client.EventHandlers;
using AltV.Net.Client.Events;
using WebAssembly;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        private static NativeAlt _alt;

        public static NativeNatives Natives;

        internal static NativeLocalStorage LocalStorage;
        
        internal static NativePlayer Player;

        internal static NativeHandlingData HandlingData;

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
        
        private static NativeEventHandler<NativeGameEntityCreateEventDelegate, GameEntityCreateEventDelegate> _nativeGameEntityCreateHandler;
        
        private static NativeEventHandler<NativeGameEntityDestroyEventDelegate, GameEntityDestroyEventDelegate> _nativeGameEntityDestroyHandler;

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
        
        public static event EveryTickEventDelegate OnEveryTick
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
        
        public static event GameEntityCreateEventDelegate OnGameEntityCreate
        {
            add
            {
                if (_nativeGameEntityCreateHandler == null)
                {
                    _nativeGameEntityCreateHandler = new GameEntityCreateEventHandler();
                    _alt.On("gameEntityCreate", _nativeGameEntityCreateHandler.GetNativeEventHandler());
                }

                _nativeGameEntityCreateHandler.Add(value);
            }
            remove => _nativeGameEntityCreateHandler?.Remove(value);
        }
        
        public static event GameEntityDestroyEventDelegate OnGameEntityDestroy
        {
            add
            {
                if (_nativeGameEntityDestroyHandler == null)
                {
                    _nativeGameEntityDestroyHandler = new GameEntityDestroyEventHandler();
                    _alt.On("gameEntityDestroy", _nativeGameEntityDestroyHandler.GetNativeEventHandler());
                }

                _nativeGameEntityDestroyHandler.Add(value);
            }
            remove => _nativeGameEntityDestroyHandler?.Remove(value);
        }

        public static void Init(object wrapper)
        {
            var jsWrapper = (JSObject) wrapper;
            var alt = (JSObject) jsWrapper.GetObjectProperty("alt");
            var natives = (JSObject) jsWrapper.GetObjectProperty("natives");
            var localStorage = (JSObject) jsWrapper.GetObjectProperty("LocalStorage");
            var player = (JSObject) jsWrapper.GetObjectProperty("Player");
            var handlingData = (JSObject) jsWrapper.GetObjectProperty("HandlingData");
            _alt = new NativeAlt(alt);
            Natives = new NativeNatives(natives);
            LocalStorage = new NativeLocalStorage(localStorage);
            Player = new NativePlayer(player);
            HandlingData = new NativeHandlingData(handlingData);
        }

        public static void Log(string message)
        {
            _alt.Log(message);
        }

        public static void LogError(string message)
        {
            _alt.LogError(message);
        }

        public static void LogWarning(string message)
        {
            _alt.LogWarning(message);
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

        public static void AddGxtText(string key, string value)
        {
            _alt.AddGxtText(key, value);
        }

        public static void BeginScaleformMovieMethodMinimap(string methodName)
        {
            _alt.BeginScaleformMovieMethodMinimap(methodName);
        }

        public static bool GameControlsEnabled()
        {
            return _alt.GameControlsEnabled();
        }

        public static Vector2 GetCursorPos()
        {
            return _alt.GetCursorPos();
        }

        public static string GetGxtText(string key)
        {
            return _alt.GetGxtText(key);
        }

        public static string GetLicenseHash()
        {
            return _alt.GetLicenseHash();
        }

        public static string GetLocale()
        {
            return _alt.GetLocale();
        }

        public static int GetMsPerGameMinute()
        {
            return _alt.GetMsPerGameMinute();
        }

        public static int GetStat(string statName)
        {
            return _alt.GetStat(statName);
        }

        public static int Hash(string hashString)
        {
            return _alt.Hash(hashString);
        }

        public static bool IsConsoleOpen()
        {
            return _alt.IsConsoleOpen();
        }

        public static bool IsInSandbox()
        {
            return _alt.IsInSandbox();
        }

        public static bool IsMenuOpen()
        {
            return _alt.IsMenuOpen();
        }

        public static bool IsTextureExistInArchetype(int modelHash, string modelName)
        {
            return _alt.IsTextureExistInArchetype(modelHash, modelName);
        }

        public static void LoadModel(int modelHash)
        {
            _alt.LoadModel(modelHash);
        }

        public static void LoadModelAsync(int modelHash)
        {
            _alt.LoadModelAsync(modelHash);
        }

        public static void RemoveGxtText(string key)
        {
            _alt.RemoveGxtText(key);
        }

        public static void RemoveIpl(string iplName)
        {
            _alt.RemoveIpl(iplName);
        }

        public static void RequestIpl(string iplName)
        {
            _alt.RequestIpl(iplName);
        }

        public static void ResetStat(string statName)
        {
            _alt.ResetStat(statName);
        }

        /**
         * Remarks: Only available in sandbox mode
         */
        public static bool SaveScreenshot(string stem)
        {
            return _alt.SaveScreenshot(stem);
        }

        public static void SetCamFrozen(bool state)
        {
            _alt.SetCamFrozen(state);
        }

        public static void SetCursorPos(Vector2 pos)
        {
            _alt.SetCursorPos(pos);
        }

        public static void SetModel(string modelName)
        {
            _alt.SetModel(modelName);
        }

        public static void SetMsPerGameMinute(int ms)
        {
            _alt.SetMsPerGameMinute(ms);
        }

        public static void SetStat(string statName, int value)
        {
            _alt.SetStat(statName, value);
        }

        public static void SetWeatherCycle(int[] weathers, int[] multipliers)
        {
            _alt.SetWeatherCycle(weathers, multipliers);
        }

        public static void SetWeatherSyncActive(bool isActive)
        {
            _alt.SetWeatherSyncActive(isActive);
        }

        /**
         * Remarks:
         * This is handled by resource scoped internal integer, which gets increased/decreased by every function call. 
         * When you show your cursor 5 times, to hide it you have to do that 5 times accordingly.
         */
        public static void ShowCursor(bool state)
        {
            _alt.ShowCursor(state);
        }

        public static void ToggleGameControls(bool state)
        {
            _alt.ToggleGameControls(state);
        }
    }
}