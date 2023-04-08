using System.Numerics;
using System.Runtime.CompilerServices;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using WeaponData = AltV.Net.Client.Elements.Data.WeaponData;

namespace AltV.Net.Client
{
    public interface ICore : ISharedCore
    {
        new IPlayerPool PlayerPool { get; }
        new IEntityPool<IVehicle> VehiclePool { get; }
        new IEntityPool<IPed> PedPool { get; }
        IBaseEntityPool BaseEntityPool { get; }
        IBaseBaseObjectPool BaseBaseObjectPool { get; }
        IBaseObjectPool<IWebView> WebViewPool { get; }
        new IBaseObjectPool<IBlip> BlipPool { get; }
        new IBaseObjectPool<ICheckpoint> CheckpointPool { get; }
        IBaseObjectPool<IAudio> AudioPool { get; }
        IBaseObjectPool<IHttpClient> HttpClientPool { get; }
        IBaseObjectPool<IWebSocketClient> WebSocketClientPool { get; }
        IBaseObjectPool<IRmlDocument> RmlDocumentPool { get; }
        IBaseObjectPool<IRmlElement> RmlElementPool { get; }
        LocalStorage LocalStorage { get; }
        new INativeResource Resource { get; }
        INatives Natives { get; }
        Voice Voice { get; }
        bool MinimapIsRectangle { set; }
        ushort Fps { get; }
        ushort Ping { get; }
        uint TotalPacketsLost { get; }
        ulong TotalPacketsSent { get; }
        Vector2 ScreenResolution { get; }
        string LicenseHash { get; }
        string Locale { get; }
        string ServerIp { get; }
        ushort ServerPort { get; }
        bool IsGameFocused { get; }
        bool IsInStreamerMode { get; }
        bool IsMenuOpened { get; }
        bool IsConsoleOpen { get; }
        bool CamFrozen { get; set; }
        Vector3 CamPos { get; }
        bool GameControlsEnabled { get; set; }
        bool RmlControlsEnabled { get; set; }
        bool VoiceControlsEnabled { get; set; }
        int MsPerGameMinute { get; set; }
        INativeResourcePool NativeResourcePool { get; }
        ITimerPool TimerPool { get; }
        IBlip CreatePointBlip(Position position);
        IBlip CreateRadiusBlip(Position position, float radius);
        IBlip CreateAreaBlip(Position position, int width, int height);
        IntPtr CreateWebViewPtr(out uint id, string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null);
        IWebView CreateWebView(string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null);
        IntPtr CreateWebViewPtr(out uint id, string url, uint propHash, string targetTexture);
        IWebView CreateWebView(string url, uint propHash, string targetTexture);
        IntPtr CreatePointBlipPtr(out uint id, Position position);
        IntPtr CreateRadiusBlipPtr(out uint id, Position position, float radius);
        IntPtr CreateAreaBlipPtr(out uint id, Position position, int width, int height);
        new IEntity GetEntityById(ushort id);
        void ShowCursor(bool state);
        bool IsCursorVisible { get; }
        Discord Discord { get; }
        FocusData FocusData { get; }
        void TriggerServerEvent(string eventName, params object[] args);
        void TriggerServerEventUnreliable(string eventName, params object[] args);
        IntPtr CreateRmlDocumentPtr(out uint id, string url);
        IRmlDocument CreateRmlDocument(string url);
        Vector2 WorldToScreen(Vector3 position);
        string[] MarshalStringArrayPtrAndFree(IntPtr ptr, uint size);
        DiscordUser? GetDiscordUser();
        void LoadRmlFont(string path, string name, bool italic = false, bool bold = false);
        HandlingData? GetHandlingByModelHash(uint modelHash);
        Vector3 ScreenToWorld(Vector2 position);
        void AddGxtText(uint key, string value);
        string GetGxtText(uint key);
        void RemoveGxtText(uint key);
        bool BeginScaleformMovieMethodMinimap(string methodName);
        void SetMinimapComponentPosition(string name, char alignX, char alignY, float posX, float posY, float sizeX, float sizeY);
        void CopyToClipboard(string content);
        PermissionState GetPermissionState(Permission permission);
        bool IsTextureExistInArchetype(uint modelHash, string targetTextureName);
        bool IsPointOnScreen(Vector3 position);
        void LoadModel(uint modelHash);
        void LoadModelAsync(uint modelHash);
        bool LoadYtyp(string ytypName);
        bool UnloadYtyp(string ytypName);
        void RequestIpl(string iplName);
        void RemoveIpl(string iplName);
        bool IsKeyDown(Key key);
        bool IsKeyToggled(Key key);
        bool DoesConfigFlagExist(string flagName);
        bool GetConfigFlag(string flagName);
        void SetConfigFlag(string flagName, bool value);
        Vector2 GetCursorPos(bool normalized);
        void SetCursorPos(Vector2 pos, bool normalized);
        string GetStatType(string stat);
        void ResetStat(string stat);
        void GetStat(string stat, out int value);
        void GetStat(string stat, out long value);
        void GetStat(string stat, out float value);
        void GetStat(string stat, out bool value);
        void GetStat(string stat, out string value);
        void GetStat(string stat, out byte value);
        void GetStat(string stat, out ushort value);
        void GetStat(string stat, out uint value);
        void GetStat(string stat, out ulong value);
        void SetStat(string stat, int value);
        void SetStat(string stat, long value);
        void SetStat(string stat, float value);
        void SetStat(string stat, bool value);
        void SetStat(string stat, string value);
        void SetStat(string stat, byte value);
        void SetStat(string stat, ushort value);
        void SetStat(string stat, uint value);
        void SetStat(string stat, ulong value);
        void ClearPedProp(int scriptId, byte component);
        void SetPedDlcProp(int scriptId, uint dlc, byte component, byte drawable, byte texture);
        void SetPedDlcClothes(int scriptId, uint dlc, byte component, byte drawable, byte texture, byte palette);
        void SetRotationVelocity(int scriptId, Rotation velocity);
        void SetWatermarkPosition(WatermarkPosition position);
        string StringToSha256(string value);
        void SetWeatherCycle(byte[] weathers, byte[] multipliers);
        void SetWeatherSyncActive(bool state);
        string GetHeadshotBase64(byte id);
        Task<string> TakeScreenshot();
        Task<string> TakeScreenshotGameOnly();
        INativeResource GetResource(string name);
        bool HasResource(string name);
        INativeResource[] GetAllResources();
        uint SetTimeout(Action action, uint duration, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
        uint SetInterval(Action action, uint duration, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
        uint NextTick(Action action, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
        uint EveryTick(Action action, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
        void ClearTimer(uint id);
        IntPtr CreateCheckpointPtr(out uint id, CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color);
        ICheckpoint CreateCheckpoint(CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color);
        IntPtr CreateAudioPtr(out uint id, string source, float volume, uint category, bool frontend);
        IAudio CreateAudio(string source, float volume, uint category, bool frontend);
        IntPtr CreateObjectPtr(out uint id, uint modelHash, Position position, Rotation rotation, bool noOffset = false,
            bool dynamic = false);
        IObject CreateObject(uint modelHash, Position position, Rotation rotation, bool noOffset = false,
            bool dynamic = false);
        MapZoomData GetMapZoomData(uint id);
        MapZoomData GetMapZoomData(string alias);
        void ResetAllMapZoomData();
        void LoadDefaultIpls();
        IntPtr CreateHttpClientPtr(out uint id);
        IHttpClient CreateHttpClient();
        IntPtr CreateWebSocketClientPtr(out uint id, string url);
        IWebSocketClient CreateWebSocketClient(string url);
        bool HasLocalMetaData(string key);
        void GetLocalMetaData<T>(string key, out MValueConst result);
        bool FileExists(string path);
        string FileRead(string path);
        byte[] FileReadBinary(string path);
        WeaponData GetWeaponDataByWeaponHash(uint weaponHash);
        IReadOnlyCollection<IObject> GetAllObjects();
        IReadOnlyCollection<IObject> GetAllWorldObjects();
        IEnumerable<string> GetRegisteredClientEvents();
        IEnumerable<string> GetRegisteredServerEvents();
        Vector3 PedBonesPosition(int scriptId, ushort boneId);
    }
}