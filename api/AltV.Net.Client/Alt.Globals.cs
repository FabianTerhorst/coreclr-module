using System.Numerics;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Data;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        public static Vector3 ScreenToWorld(Vector2 position) => Core.ScreenToWorld(position);
        public static Vector3 ScreenToWorld(float x, float y) => Core.ScreenToWorld(new Vector2(x, y));
        public static Vector2 WorldToScreen(Vector3 position) => Core.WorldToScreen(position);
        public static Vector2 WorldToScreen(float x, float y, float z) => Core.WorldToScreen(new Vector3(x, y, z));
        public static void ShowCursor(bool state) => Core.ShowCursor(state);
        public static bool IsCursorVisible => Core.IsCursorVisible;
        public static void AddGxtText(uint key, string value) => Core.AddGxtText(key, value);
        public static void AddGxtText(string key, string value) => Core.AddGxtText(Hash(key), value);
        public static string GetGxtText(uint key) => Core.GetGxtText(key);
        public static string GetGxtText(string key) => Core.GetGxtText(Hash(key));
        public static void RemoveGxtText(uint key) => Core.RemoveGxtText(key);
        public static void RemoveGxtText(string key) => Core.RemoveGxtText(Hash(key));
        public static bool BeginScaleformMovieMethodMinimap(string methodName) => Core.BeginScaleformMovieMethodMinimap(methodName);
        public static void SetMinimapComponentPosition(string name, char alignX, char alignY, float posX, float posY, float sizeX, float sizeY) => Core.SetMinimapComponentPosition(name, alignX, alignY, posX, posY, sizeX, sizeY);
        public static void SetMinimapComponentPosition(string name, char alignX, char alignY, Vector2 pos, Vector2 size) => Core.SetMinimapComponentPosition(name, alignX, alignY, pos.X, pos.Y, size.X, size.Y);
        public static void CopyToClipboard(string content) => Core.CopyToClipboard(content);
        public static PermissionState GetPermissionState(Permission permission) => Core.GetPermissionState(permission);
        public static bool IsTextureExistInArchetype(uint modelHash, string targetTextureName) => Core.IsTextureExistInArchetype(modelHash, targetTextureName);
        public static bool IsTextureExistInArchetype(string modelName, string targetTextureName) => Core.IsTextureExistInArchetype(Hash(modelName), targetTextureName);
        public static bool IsPointOnScreen(Vector3 position) => Core.IsPointOnScreen(position);
        public static bool IsFullScreen() => Core.IsFullScreen;
        public static void LoadRmlFont(string path, string name, bool italic = false, bool bold = false) => Core.LoadRmlFont(path, name, italic, bold);
        public static void LoadModel(uint modelHash) => Core.LoadModel(modelHash);
        public static void LoadModel(string modelName) => Core.LoadModel(Hash(modelName));
        public static void LoadModelAsync(uint modelHash) => Core.LoadModelAsync(modelHash);
        public static void LoadModelAsync(string modelName) => Core.LoadModelAsync(Hash(modelName));
        public static bool LoadYtyp(string ytypName) => Core.LoadYtyp(ytypName);
        public static bool UnloadYtyp(string ytypName) => Core.UnloadYtyp(ytypName);
        public static void RequestIpl(string iplName) => Core.RequestIpl(iplName);
        public static void RemoveIpl(string iplName) => Core.RemoveIpl(iplName);
        public static bool IsKeyDown(Key key) => Core.IsKeyDown(key);
        public static bool IsKeyToggled(Key key) => Core.IsKeyToggled(key);
        public static bool DoesConfigFlagExist(string flagName) => Core.DoesConfigFlagExist(flagName);
        public static bool GetConfigFlag(string flagName) => Core.GetConfigFlag(flagName);
        public static void SetConfigFlag(string flagName, bool value) => Core.SetConfigFlag(flagName, value);
        public static Vector2 GetCursorPos(bool normalized) => Core.GetCursorPos(normalized);
        public static void SetCursorPos(Vector2 pos, bool normalized) => Core.SetCursorPos(pos, normalized);
        public static string GetStatType(string stat) => Core.GetStatType(stat);
        public static void ResetStat(string stat) => Core.ResetStat(stat);
        public static void GetStat(string stat, out int value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out long value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out float value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out bool value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out string value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out byte value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out ushort value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out uint value) => Core.GetStat(stat, out value);
        public static void GetStat(string stat, out ulong value) => Core.GetStat(stat, out value);
        public static void SetStat(string stat, int value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, long value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, float value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, bool value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, string value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, byte value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, ushort value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, uint value) => Core.SetStat(stat, value);
        public static void SetStat(string stat, ulong value) => Core.SetStat(stat, value);
        public static void ClearPedProp(int scriptId, byte component) => Core.ClearPedProp(scriptId, component);
        public static void SetPedDlcProp(int scriptId, uint dlc, byte component, byte drawable, byte texture) => Core.SetPedDlcProp(scriptId, dlc, component, drawable, texture);
        public static void SetPedDlcClothes(int scriptId, uint dlc, byte component, byte drawable, byte texture, byte palette) => Core.SetPedDlcClothes(scriptId, dlc, component, drawable, texture, palette);
        public static void SetRotationVelocity(int scriptId, Rotation velocity) => Core.SetRotationVelocity(scriptId, velocity);
        public static void SetWatermarkPosition(WatermarkPosition position) => Core.SetWatermarkPosition(position);
        public static string StringToSha256(string value) => Core.StringToSha256(value);
        public static void SetWeatherCycle(byte[] weathers, byte[] multipliers) => Core.SetWeatherCycle(weathers, multipliers);
        public static void SetWeatherSyncActive(bool state) => Core.SetWeatherSyncActive(state);
        public static string GetHeadshotBase64(byte id) => Core.GetHeadshotBase64(id);
        public static Task<string> TakeScreenshot() => Core.TakeScreenshot();
        public static Task<string> TakeScreenshotGameOnly() => Core.TakeScreenshotGameOnly();

        public static MapZoomData GetMapZoomData(uint id) => Core.GetMapZoomData(id);
        public static MapZoomData GetMapZoomData(string alias) => Core.GetMapZoomData(alias);
        public static void ResetAllMapZoomData() => Core.ResetAllMapZoomData();
        public static void LoadDefaultIpls() => Core.LoadDefaultIpls();
        public static bool MinimapIsRectangle { set => Core.MinimapIsRectangle = value; }
        public static ushort Fps => Core.Fps;
        public static ushort Ping => Core.Ping;
        public static uint TotalPacketsLost => Core.TotalPacketsLost;
        public static ulong TotalPacketsSent => Core.TotalPacketsSent;
        public static Vector2 ScreenResolution => Core.ScreenResolution;
        public static string LicenseHash => Core.LicenseHash;
        public static string Locale => Core.Locale;
        public static string ServerIp => Core.ServerIp;
        public static ushort ServerPort => Core.ServerPort;
        public static bool IsGameFocused => Core.IsGameFocused;
        public static bool IsInStreamerMode => Core.IsInStreamerMode;
        public static bool IsMenuOpened => Core.IsMenuOpened;
        public static bool IsConsoleOpen => Core.IsConsoleOpen;
        public static bool CamFrozen { get => Core.CamFrozen; set => Core.CamFrozen = value; }
        public static Vector3 CamPos => Core.CamPos;
        public static bool GameControlsEnabled { get => Core.GameControlsEnabled; set => Core.GameControlsEnabled = value; }
        public static bool RmlControlsEnabled { get => Core.RmlControlsEnabled; set => Core.RmlControlsEnabled = value; }
        public static bool VoiceControlsEnabled { get => Core.VoiceControlsEnabled; set => Core.VoiceControlsEnabled = value; }
        public static int MsPerGameMinute { get => Core.MsPerGameMinute; set => Core.MsPerGameMinute = value; }
    }
}