using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Exceptions;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client
{
    public partial class Core
    {
        public void LoadRmlFont(string path, string name, bool italic = false, bool bold = false)
        {
            unsafe
            {
                var pathPtr = MemoryUtils.StringToHGlobalUtf8(path);
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                Library.Client.Core_LoadRmlFont(NativePointer, Resource.NativePointer, pathPtr, namePtr, (byte) (italic ? 1 : 0), (byte) (bold ? 1 : 0));
                Marshal.FreeHGlobal(pathPtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public Vector2 WorldToScreen(Vector3 position)
        {
            unsafe
            {
                var result = Vector2.Zero;
                Library.Client.Core_WorldToScreen(NativePointer, position, &result);
                return result;
            }
        }

        public Vector3 ScreenToWorld(Vector2 position)
        {
            unsafe
            {
                var result = Vector3.Zero;
                Library.Client.Core_ScreenToWorld(NativePointer, position, &result);
                return result;
            }
        }

        #region GXT

        public void AddGxtText(uint key, string value)
        {
            unsafe
            {
                var valuePtr = MemoryUtils.StringToHGlobalUtf8(value);
                Library.Client.Core_AddGXTText(NativePointer, Resource.NativePointer, key, valuePtr);
                Marshal.FreeHGlobal(valuePtr);
            }
        }

        public string GetGxtText(uint key)
        {
            unsafe
            {
                var size = 0;
                return PtrToStringUtf8AndFree(Library.Client.Core_GetGXTText(NativePointer, Resource.NativePointer, key, &size), size);
            }
        }

        public void RemoveGxtText(uint key)
        {
            unsafe
            {
                Library.Client.Core_RemoveGXTText(NativePointer, Resource.NativePointer, key);
            }
        }

        #endregion

        #region Minimap

        public bool BeginScaleformMovieMethodMinimap(string methodName)
        {
            unsafe
            {
                var methodNamePtr = MemoryUtils.StringToHGlobalUtf8(methodName);
                var result = Library.Client.Core_BeginScaleformMovieMethodMinimap(NativePointer, methodNamePtr);
                Marshal.FreeHGlobal(methodNamePtr);
                return result == 1;
            }
        }

        public void SetMinimapComponentPosition(string name, char alignX, char alignY, float posX, float posY, float sizeX, float sizeY)
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                Library.Client.Core_SetMinimapComponentPosition(NativePointer, namePtr, (byte) alignX, (byte) alignY, posX, posY, sizeX, sizeY);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public bool MinimapIsRectangle
        {
            set
            {
                unsafe
                {
                    Library.Client.Core_SetMinimapIsRectangle(NativePointer, (byte) (value ? 1 : 0));
                }
            }
        }

        #endregion

        public void CopyToClipboard(string content)
        {
            unsafe
            {
                var contentPtr = MemoryUtils.StringToHGlobalUtf8(content);
                var state = Library.Client.Core_CopyToClipboard(NativePointer, contentPtr) == 1;
                Marshal.FreeHGlobal(contentPtr);
                if (!state) throw new PermissionException(Permission.ClipboardAccess);
            }
        }

        public ushort Fps
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_GetFPS(NativePointer);
                }
            }
        }

        public ushort Ping
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_GetPing(NativePointer);
                }
            }
        }

        public uint TotalPacketsLost
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_GetTotalPacketsLost(NativePointer);
                }
            }
        }

        public ulong TotalPacketsSent
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_GetTotalPacketsSent(NativePointer);
                }
            }
        }

        public Vector2 ScreenResolution
        {
            get
            {
                unsafe
                {
                    var result = Vector2.Zero;
                    Library.Client.Core_GetScreenResolution(NativePointer, &result);
                    return result;
                }
            }
        }

        public string LicenseHash
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return PtrToStringUtf8AndFree(Library.Client.Core_GetLicenseHash(NativePointer, &size), size);
                }
            }
        }

        public string Locale
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return PtrToStringUtf8AndFree(Library.Client.Core_GetLocale(NativePointer, &size), size);
                }
            }
        }

        public bool GetPermissionState(Permission permission)
        {
            unsafe
            {
                return Library.Client.Core_GetPermissionState(NativePointer, (byte) permission) == 1;
            }
        }

        public string ServerIp
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return PtrToStringUtf8AndFree(Library.Client.Core_GetServerIp(NativePointer, &size), size);
                }
            }
        }

        public ushort ServerPort
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_GetServerPort(NativePointer);
                }
            }
        }

        public bool IsGameFocused
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsGameFocused(NativePointer) == 1;
                }
            }
        }

        public bool IsInStreamerMode
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsInStreamerMode(NativePointer) == 1;
                }
            }
        }

        public bool IsMenuOpened
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsMenuOpened(NativePointer) == 1;
                }
            }
        }

        public bool IsPointOnScreen(Vector3 position)
        {
            unsafe
            {
                return Library.Client.Core_IsPointOnScreen(NativePointer, position) == 1;
            }
        }

        public bool IsFullScreen
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsFullScreen(NativePointer) == 1;
                }
            }
        }

        public bool IsConsoleOpen
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsConsoleOpen(NativePointer) == 1;
                }
            }
        }

        public bool IsTextureExistInArchetype(uint modelHash, string targetTextureName)
        {
            unsafe
            {
                var targetTextureNamePtr = MemoryUtils.StringToHGlobalUtf8(targetTextureName);
                var result = Library.Client.Core_IsTextureExistInArchetype(NativePointer, modelHash, targetTextureNamePtr) == 1;
                Marshal.FreeHGlobal(targetTextureNamePtr);
                return result;
            }
        }

        public void LoadModel(uint modelHash)
        {
            unsafe
            {
                Library.Client.Core_LoadModel(NativePointer, modelHash);
            }
        }

        public void LoadModelAsync(uint modelHash)
        {
            unsafe
            {
                Library.Client.Core_LoadModelAsync(NativePointer, modelHash);
            }
        }

        public bool LoadYtyp(string ytypName)
        {
            unsafe
            {
                var ytypNamePtr = MemoryUtils.StringToHGlobalUtf8(ytypName);
                var result = Library.Client.Core_LoadYtyp(NativePointer, ytypNamePtr);
                Marshal.FreeHGlobal(ytypNamePtr);
                return result == 1;
            }
        }

        public bool UnloadYtyp(string ytypName)
        {
            unsafe
            {
                var ytypNamePtr = MemoryUtils.StringToHGlobalUtf8(ytypName);
                var result = Library.Client.Core_UnloadYtyp(NativePointer, ytypNamePtr);
                Marshal.FreeHGlobal(ytypNamePtr);
                return result == 1;
            }
        }

        public void RequestIpl(string iplName)
        {
            unsafe
            {
                var iplNamePtr = MemoryUtils.StringToHGlobalUtf8(iplName);
                Library.Client.Core_RequestIpl(NativePointer, iplNamePtr);
                Marshal.FreeHGlobal(iplNamePtr);
            }
        }

        public void RemoveIpl(string iplName)
        {
            unsafe
            {
                var iplNamePtr = MemoryUtils.StringToHGlobalUtf8(iplName);
                Library.Client.Core_RemoveIpl(NativePointer, iplNamePtr);
                Marshal.FreeHGlobal(iplNamePtr);
            }
        }

        public bool IsKeyDown(Key key)
        {
            unsafe
            {
                return Library.Client.Core_IsKeyDown(NativePointer, (uint) key) == 1;
            }
        }

        public bool IsKeyToggled(Key key)
        {
            unsafe
            {
                return Library.Client.Core_IsKeyToggled(NativePointer, (uint) key) == 1;
            }
        }

        public bool CamFrozen
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsCamFrozen(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    Library.Client.Core_SetCamFrozen(NativePointer, (byte) (value ? 1 : 0));
                }
            }
        }

        public Vector3 CamPos
        {
            get
            {
                unsafe
                {
                    var vector = Vector3.Zero;
                    Library.Client.Core_GetCamPos(NativePointer, &vector);
                    return vector;
                }
            }
        }

        public bool DoesConfigFlagExist(string flagName)
        {
            unsafe
            {
                var flagNamePtr = MemoryUtils.StringToHGlobalUtf8(flagName);
                var result = Library.Client.Core_DoesConfigFlagExist(NativePointer, flagNamePtr) == 1;
                Marshal.FreeHGlobal(flagNamePtr);
                return result;
            }
        }

        public bool GetConfigFlag(string flagName)
        {
            unsafe
            {
                var flagNamePtr = MemoryUtils.StringToHGlobalUtf8(flagName);
                var result = Library.Client.Core_GetConfigFlag(NativePointer, flagNamePtr) == 1;
                Marshal.FreeHGlobal(flagNamePtr);
                return result;
            }
        }

        public void SetConfigFlag(string flagName, bool value)
        {
            unsafe
            {
                var flagNamePtr = MemoryUtils.StringToHGlobalUtf8(flagName);
                Library.Client.Core_SetConfigFlag(NativePointer, flagNamePtr, (byte) (value ? 1 : 0));
                Marshal.FreeHGlobal(flagNamePtr);
            }
        }

        public bool GameControlsEnabled
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_AreGameControlsEnabled(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    Library.Client.Core_ToggleGameControls(NativePointer, Resource.NativePointer, (byte) (value ? 1 : 0));
                }
            }
        }

        public bool RmlControlsEnabled
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_AreRmlControlsEnabled(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    Library.Client.Core_ToggleRmlControls(NativePointer, (byte) (value ? 1 : 0));
                }
            }
        }

        public bool VoiceControlsEnabled
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_AreVoiceControlsEnabled(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    Library.Client.Core_ToggleVoiceControls(NativePointer, (byte) (value ? 1 : 0));
                }
            }
        }

        public Vector2 GetCursorPos(bool normalized)
        {
            unsafe
            {
                var vector = Vector2.Zero;
                Library.Client.Core_GetCursorPos(NativePointer, &vector, (byte) (normalized ? 1 : 0));
                return vector;
            }
        }

        public void SetCursorPos(Vector2 pos, bool normalized)
        {
            unsafe
            {
                Library.Client.Core_SetCursorPos(NativePointer, pos, (byte) (normalized ? 1 : 0));
            }
        }

        public int MsPerGameMinute
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_GetMsPerGameMinute(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Client.Core_SetMsPerGameMinute(NativePointer, value);
                }
            }
        }

        #region Stat

        private IntPtr GetStatPointer(string stat)
        {
            unsafe
            {
                var statPtr = MemoryUtils.StringToHGlobalUtf8(stat);
                var result = Library.Client.Core_GetStatData(NativePointer, statPtr);
                Marshal.FreeHGlobal(statPtr);
                if (result == IntPtr.Zero) throw new InvalidStatException(stat);
                return result;
            }
        }
        private string GetStatType(IntPtr stat)
        {
            unsafe
            {
                var size = 0;
                return PtrToStringUtf8AndFree(Library.Client.Core_GetStatType(NativePointer, stat, &size), size);
            }
        }
        private Type GetStatTypeType(IntPtr stat)
        {

            return GetStatType(stat) switch
            {
                "INT" or "TEXTLABEL" => typeof(int),
                "INT64" => typeof(long),
                "FLOAT" => typeof(float),
                "BOOL" => typeof(bool),
                "STRING" => typeof(string),
                "UINT8" => typeof(byte),
                "UINT16" => typeof(ushort),
                "UINT32" => typeof(uint),
                "UINT64" or "POS" or "DATE" or "PACKED" or "USERID" => typeof(ulong),
                _ => throw new Exception("Unknown stat type")
            };
        }
        private IntPtr GetStatAndEnsureType(string stat, Type type)
        {
            var statPtr = GetStatPointer(stat);
            var statType = GetStatTypeType(statPtr);
            if (statType != type)
            {
                throw new InvalidStatTypeException(stat, type, statType);
            }
            return statPtr;
        }

        public string GetStatType(string stat)
        {
            return GetStatType(GetStatPointer(stat));
        }

        public void ResetStat(string stat)
        {
            unsafe
            {
                var statPtr = MemoryUtils.StringToHGlobalUtf8(stat);
                Library.Client.Core_ResetStat(NativePointer, statPtr);
            }
        }

        public void GetStat(string stat, out int value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(int));
            unsafe
            {
                value = Library.Client.Core_GetStatInt(NativePointer, statPtr);
            }
        }

        public void GetStat(string stat, out long value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(long));
            unsafe
            {
                value = Library.Client.Core_GetStatLong(NativePointer, statPtr);
            }
        }

        public void GetStat(string stat, out float value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(float));
            unsafe
            {
                value = Library.Client.Core_GetStatFloat(NativePointer, statPtr);
            }
        }

        public void GetStat(string stat, out bool value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(bool));
            unsafe
            {
                value = Library.Client.Core_GetStatBool(NativePointer, statPtr) == 1;
            }
        }

        public void GetStat(string stat, out string value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(string));
            unsafe
            {
                var size = 0;
                value = PtrToStringUtf8AndFree(Library.Client.Core_GetStatString(NativePointer, statPtr, &size), size);
            }
        }

        public void GetStat(string stat, out byte value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(byte));
            unsafe
            {
                value = Library.Client.Core_GetStatUInt8(NativePointer, statPtr);
            }
        }

        public void GetStat(string stat, out ushort value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(ushort));
            unsafe
            {
                value = Library.Client.Core_GetStatUInt16(NativePointer, statPtr);
            }
        }

        public void GetStat(string stat, out uint value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(uint));
            unsafe
            {
                value = Library.Client.Core_GetStatUInt32(NativePointer, statPtr);
            }
        }

        public void GetStat(string stat, out ulong value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(ulong));
            unsafe
            {
                value = Library.Client.Core_GetStatUInt64(NativePointer, statPtr);
            }
        }

        public void SetStat(string stat, int value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(int));
            unsafe
            {
                Library.Client.Core_SetStatInt(NativePointer, statPtr, value);
            }
        }

        public void SetStat(string stat, long value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(long));
            unsafe
            {
                Library.Client.Core_SetStatLong(NativePointer, statPtr, value);
            }
        }

        public void SetStat(string stat, float value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(float));
            unsafe
            {
                Library.Client.Core_SetStatFloat(NativePointer, statPtr, value);
            }
        }

        public void SetStat(string stat, bool value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(bool));
            unsafe
            {
                Library.Client.Core_SetStatBool(NativePointer, statPtr, (byte) (value ? 1 : 0));
            }
        }

        public void SetStat(string stat, string value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(string));
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(value);
                Library.Client.Core_SetStatString(NativePointer, statPtr, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetStat(string stat, byte value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(byte));
            unsafe
            {
                Library.Client.Core_SetStatUInt8(NativePointer, statPtr, value);
            }
        }

        public void SetStat(string stat, ushort value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(ushort));
            unsafe
            {
                Library.Client.Core_SetStatUInt16(NativePointer, statPtr, value);
            }
        }

        public void SetStat(string stat, uint value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(uint));
            unsafe
            {
                Library.Client.Core_SetStatUInt32(NativePointer, statPtr, value);
            }
        }

        public void SetStat(string stat, ulong value)
        {
            var statPtr = GetStatAndEnsureType(stat, typeof(ulong));
            unsafe
            {
                Library.Client.Core_SetStatUInt64(NativePointer, statPtr, value);
            }
        }

        #endregion

        #region Clothes

        public void ClearPedProp(int scriptId, byte component)
        {
            unsafe
            {
                Library.Client.Core_ClearPedProp(NativePointer, scriptId, component);
            }
        }

        public void SetPedDlcProp(int scriptId, uint dlc, byte component, byte drawable, byte texture)
        {
            unsafe
            {
                Library.Client.Core_SetPedDlcProp(NativePointer, scriptId, dlc, component, drawable, texture);
            }
        }

        public void SetPedDlcClothes(int scriptId, uint dlc, byte component, byte drawable, byte texture, byte palette)
        {
            unsafe
            {
                Library.Client.Core_SetPedDlcClothes(NativePointer, scriptId, dlc, component, drawable, texture, palette);
            }
        }

        #endregion

        public void SetRotationVelocity(int scriptId, Rotation velocity)
        {
            unsafe
            {
                Library.Client.Core_SetRotationVelocity(NativePointer, scriptId, velocity);
            }
        }

        public void SetWatermarkPosition(WatermarkPosition position)
        {
            unsafe
            {
                Library.Client.Core_SetWatermarkPosition(NativePointer, (byte) position);
            }
        }

        public string StringToSha256(string value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(value);
                var size = 0;
                return PtrToStringUtf8AndFree(Library.Client.Core_StringToSHA256(NativePointer, stringPtr, &size), size);
            }
        }

        public void SetWeatherCycle(byte[] weathers, byte[] multipliers)
        {
            unsafe
            {
                Library.Client.Core_SetWeatherCycle(NativePointer, weathers, weathers.Length, multipliers, multipliers.Length);
            }
        }

        public void SetWeatherSyncActive(bool state)
        {
            unsafe
            {
                Library.Client.Core_SetWeatherSyncActive(NativePointer, (byte) (state ? 1 : 0));
            }
        }

        public string GetHeadshotBase64(byte id)
        {
            unsafe
            {
                var size = 0;
                return PtrToStringUtf8AndFree(Library.Client.Core_GetHeadshotBase64(NativePointer, id, &size), size);
            }
        }

        public async Task<string> TakeScreenshot()
        {
            GCHandle handle;
            string data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(IntPtr strPtr)
                {
                    data = Marshal.PtrToStringUTF8(strPtr);
                    semaphore.Release();
                }

                ScreenshotResultModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var result = Library.Client.Core_TakeScreenshot(NativePointer, resolveTask) == 1;
                if (!result)
                {
                    handle.Free();
                    throw new PermissionException(Permission.ScreenCapture);
                }
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data;
        }

        public async Task<string> TakeScreenshotGameOnly()
        {
            GCHandle handle;
            string data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(IntPtr strPtr)
                {
                    data = Marshal.PtrToStringUTF8(strPtr);
                    semaphore.Release();
                }

                ScreenshotResultModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var result = Library.Client.Core_TakeScreenshotGameOnly(NativePointer, resolveTask) == 1;
                if (!result)
                {
                    handle.Free();
                    throw new PermissionException(Permission.ScreenCapture);
                }
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data;
        }

        public MapZoomData GetMapZoomData(uint id)
        {
            unsafe
            {
                return new MapZoomData(this, id);
            }
        }

        public MapZoomData GetMapZoomData(string alias)
        {
            unsafe
            {
                var aliasPtr = MemoryUtils.StringToHGlobalUtf8(alias);
                uint id = 0;
                var ptr = Library.Client.Core_GetMapZoomDataByAlias(NativePointer, aliasPtr, &id);
                if (ptr == IntPtr.Zero) return null;
                Marshal.FreeHGlobal(aliasPtr);
                return new MapZoomData(this, id);
            }
        }

        public void ResetAllMapZoomData()
        {
            unsafe
            {
                Library.Client.Core_ResetAllMapZoomData(NativePointer);
            }
        }

        public void LoadDefaultIpls()
        {
            unsafe
            {
                Library.Client.Core_LoadDefaultIpls(NativePointer);
            }
        }

        public void ShowCursor(bool state)
        {
            unsafe
            {
                Library.Client.Core_ShowCursor(NativePointer, Resource.NativePointer, state ? (byte)1 : (byte)0);
            }
        }

        public bool IsCursorVisible
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsCursorVisible(NativePointer, Resource.NativePointer) == 1;
                }
            }
        }

        public bool HasLocalMetaData(string key)
        {
            unsafe
            {
                var keyPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Library.Client.Core_HasLocalMeta(NativePointer, keyPtr);
                Marshal.FreeHGlobal(keyPtr);
                return result == 1;
            }
        }

        public void GetLocalMetaData<T>(string key, out MValueConst result)
        {
            unsafe
            {
                var keyPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var value = new MValueConst(this, Library.Client.Core_GetLocalMeta(NativePointer, keyPtr));
                Marshal.FreeHGlobal(keyPtr);
                result = value;
            }
        }

        public bool FileExists(string path)
        {
            unsafe
            {
                var valuePtr = MemoryUtils.StringToHGlobalUtf8(path);
                var result = Library.Client.Core_Client_FileExists(NativePointer, Resource.NativePointer, valuePtr);
                Marshal.FreeHGlobal(valuePtr);
                return result == 1;
            }
        }

        public string? FileRead(string path)
        {
            unsafe
            {
                var pathPtr = MemoryUtils.StringToHGlobalUtf8(path);
                var size = 0;
                var ptr = Library.Client.Core_Client_FileRead(NativePointer, Resource.NativePointer, pathPtr, &size);
                Marshal.FreeHGlobal(pathPtr);
                if (ptr == IntPtr.Zero) return null;
                var result = PtrToStringUtf8AndFree(ptr, size);
                return result;
            }
        }

        public byte[]? FileReadBinary(string path)
        {
            unsafe
            {
                var pathPtr = MemoryUtils.StringToHGlobalUtf8(path);
                var size = 0;
                var result = Library.Shared.Core_FileRead(NativePointer, pathPtr, &size);
                if (result == IntPtr.Zero) return null;
                Marshal.FreeHGlobal(pathPtr);
                var buffer = new byte[size];
                Marshal.Copy(result, buffer, 0, size);
                return buffer;
            }
        }
    }
}