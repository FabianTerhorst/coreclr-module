using System.Numerics;
using AltV.Net.Client.Events;
using WebAssembly;
using WebAssembly.Core;
using Array = WebAssembly.Core.Array;

namespace AltV.Net.Client
{
    internal class NativeAlt
    {
        private readonly JSObject alt;

        private readonly Function log;

        private readonly Function logError;

        private readonly Function logWarning;

        private readonly Function on;

        private readonly Function off;

        private readonly Function onServer;

        private readonly Function offServer;

        private readonly Function emit;

        private readonly Function emitServer;

        private readonly Function everyTick;

        private readonly Function addGxtText;

        private readonly Function beginScaleformMovieMethodMinimap;

        private readonly Function gameControlsEnabled;

        private readonly Function getCursorPos;

        private readonly Function getGxtText;

        private readonly Function getLicenseHash;

        private readonly Function getLocale;

        private readonly Function getMsPerGameMinute;

        private readonly Function getStat;

        private readonly Function hash;

        private readonly Function isConsoleOpen;

        private readonly Function isInSandbox;

        private readonly Function isMenuOpen;

        private readonly Function isTextureExistInArchetype;

        private readonly Function loadModel;

        private readonly Function loadModelAsync;

        private readonly Function removeGxtText;

        private readonly Function removeIpl;

        private readonly Function requestIpl;

        private readonly Function resetStat;

        private readonly Function saveScreenshot;

        private readonly Function setCamFrozen;

        private readonly Function setCursorPos;

        private readonly Function setModel;

        private readonly Function setMsPerGameMinute;

        private readonly Function setStat;

        private readonly Function setWeatherCycle;

        private readonly Function setWeatherSyncActive;

        private readonly Function showCursor;

        private readonly Function toggleGameControls;

        public NativeAlt(JSObject alt)
        {
            this.alt = alt;
            log = (Function) alt.GetObjectProperty("log");
            logError = (Function) alt.GetObjectProperty("logError");
            logWarning = (Function) alt.GetObjectProperty("logWarning");
            on = (Function) alt.GetObjectProperty("on");
            off = (Function) alt.GetObjectProperty("off");
            onServer = (Function) alt.GetObjectProperty("onServer");
            offServer = (Function) alt.GetObjectProperty("offServer");
            emit = (Function) alt.GetObjectProperty("emit");
            emitServer = (Function) alt.GetObjectProperty("emitServer");
            everyTick = (Function) alt.GetObjectProperty("everyTick");
            addGxtText = (Function) alt.GetObjectProperty("addGxtText");
            beginScaleformMovieMethodMinimap = (Function) alt.GetObjectProperty("beginScaleformMovieMethodMinimap");
            gameControlsEnabled = (Function) alt.GetObjectProperty("gameControlsEnabled");
            getCursorPos = (Function) alt.GetObjectProperty("getCursorPos");
            getGxtText = (Function) alt.GetObjectProperty("getGxtText");
            getLicenseHash = (Function) alt.GetObjectProperty("getLicenseHash");
            getLocale = (Function) alt.GetObjectProperty("getLocale");
            getMsPerGameMinute = (Function) alt.GetObjectProperty("getMsPerGameMinute");
            getStat = (Function) alt.GetObjectProperty("getStat");
            hash = (Function) alt.GetObjectProperty("hash");
            isConsoleOpen = (Function) alt.GetObjectProperty("isConsoleOpen");
            isInSandbox = (Function) alt.GetObjectProperty("isInSandbox");
            isMenuOpen = (Function) alt.GetObjectProperty("isMenuOpen");
            isTextureExistInArchetype = (Function) alt.GetObjectProperty("isTextureExistInArchetype");
            loadModel = (Function) alt.GetObjectProperty("loadModel");
            loadModelAsync = (Function) alt.GetObjectProperty("loadModelAsync");
            removeGxtText = (Function) alt.GetObjectProperty("removeGxtText");
            removeIpl = (Function) alt.GetObjectProperty("removeIpl");
            requestIpl = (Function) alt.GetObjectProperty("requestIpl");
            resetStat = (Function) alt.GetObjectProperty("resetStat");
            saveScreenshot = (Function) alt.GetObjectProperty("saveScreenshot");
            setCamFrozen = (Function) alt.GetObjectProperty("setCamFrozen");
            setCursorPos = (Function) alt.GetObjectProperty("setCursorPos");
            setModel = (Function) alt.GetObjectProperty("setModel");
            setMsPerGameMinute = (Function) alt.GetObjectProperty("setMsPerGameMinute");
            setStat = (Function) alt.GetObjectProperty("setStat");
            setWeatherCycle = (Function) alt.GetObjectProperty("setWeatherCycle");
            setWeatherSyncActive = (Function) alt.GetObjectProperty("setWeatherSyncActive");
            showCursor = (Function) alt.GetObjectProperty("showCursor");
            toggleGameControls = (Function) alt.GetObjectProperty("toggleGameControls");
        }

        public void Log(string message)
        {
            log.Call(alt, message);
        }

        public void LogError(string message)
        {
            logError.Call(alt, message);
        }

        public void LogWarning(string message)
        {
            logWarning.Call(alt, message);
        }

        public void On(string eventName, object eventHandler)
        {
            on.Call(alt, eventName, eventHandler);
        }

        public void Off(string eventName, object eventHandler)
        {
            off.Call(alt, eventName, eventHandler);
        }

        public void OnServer(string eventName, NativeEventDelegate serverEventDelegate)
        {
            onServer.Call(alt, eventName, serverEventDelegate);
        }
        
        public void OffServer(string eventName, NativeEventDelegate serverEventDelegate)
        {
            offServer.Call(alt, eventName, serverEventDelegate);
        }
        
        public void Emit(string eventName, params object[] args)
        {
            emit.Call(alt, eventName, args);
        }
        
        public void EmitServer(string eventName, params object[] args)
        {
            emitServer.Call(alt, eventName, args);
        }

        public void EveryTick(EveryTickEventDelegate everyTickEventDelegate)
        {
            everyTick.Call(alt, everyTickEventDelegate);
        }

        public void AddGxtText(string key, string value)
        {
            addGxtText.Call(alt, key, value);
        }

        public void BeginScaleformMovieMethodMinimap(string methodName)
        {
            beginScaleformMovieMethodMinimap.Call(alt, methodName);
        }

        public bool GameControlsEnabled()
        {
            return (bool) gameControlsEnabled.Call(alt);
        }

        public Vector2 GetCursorPos()
        {
            var vector2 = (JSObject) getCursorPos.Call(alt);
            return new Vector2((int)vector2.GetObjectProperty("x"),(int)vector2.GetObjectProperty("y"));
        }

        public string GetGxtText(string key)
        {
            return (string) getGxtText.Call(alt, key);
        }

        public string GetLicenseHash()
        {
            return (string) getLicenseHash.Call(alt);
        }

        public string GetLocale()
        {
            return (string) getLocale.Call(alt);
        }

        public int GetMsPerGameMinute()
        {
            return (int) getMsPerGameMinute.Call(alt);
        }

        public int GetStat(string statName)
        {
            return (int) getStat.Call(alt, statName);
        }

        public int Hash(string hashString)
        {
            return (int) hash.Call(alt, hashString);
        }

        public bool IsConsoleOpen()
        {
            return (bool) isConsoleOpen.Call(alt);
        }

        public bool IsInSandbox()
        {
            return (bool) isInSandbox.Call(alt);
        }

        public bool IsMenuOpen()
        {
            return (bool) isMenuOpen.Call(alt);
        }

        public bool IsTextureExistInArchetype(int modelHash, string modelName)
        {
            return (bool) isTextureExistInArchetype.Call(alt, modelHash, modelName);
        }

        public void LoadModel(int modelHash)
        {
            loadModel.Call(alt, modelHash);
        }

        public void LoadModelAsync(int modelHash)
        {
            loadModelAsync.Call(modelHash);
        }

        public void RemoveGxtText(string key)
        {
            removeGxtText.Call(alt, key);
        }

        public void RemoveIpl(string iplName)
        {
            removeIpl.Call(alt, iplName);
        }

        public void RequestIpl(string iplName)
        {
            requestIpl.Call(alt, iplName);
        }

        public void ResetStat(string statName)
        {
            resetStat.Call(alt, statName);
        }

        public bool SaveScreenshot(string stem)
        {
            return (bool) saveScreenshot.Call(alt, stem);
        }

        public void SetCamFrozen(bool state)
        {
            setCamFrozen.Call(alt, state);
        }

        public void SetCursorPos(Vector2 pos)
        {
            var vector2 = Runtime.NewJSObject();
            vector2.SetObjectProperty("x", pos.X);
            vector2.SetObjectProperty("y", pos.Y);
            setCursorPos.Call(alt, vector2);
        }

        public void SetModel(string modelName)
        {
            setModel.Call(alt, modelName);
        }

        public void SetMsPerGameMinute(int ms)
        {
            setMsPerGameMinute.Call(alt, ms);
        }

        public void SetStat(string statName, int value)
        {
            setStat.Call(alt, statName, value);
        }

        public void SetWeatherCycle(int[] weathers, int[] multipliers)
        {
            setWeatherCycle.Call(alt, new Array(weathers), new Array(multipliers));
        }

        public void SetWeatherSyncActive(bool isActive)
        {
            setWeatherSyncActive.Call(alt, isActive);
        }

        public void ShowCursor(bool state)
        {
            showCursor.Call(alt, state);
        }

        public void ToggleGameControls(bool state)
        {
            toggleGameControls.Call(alt, state);
        }
    }
}