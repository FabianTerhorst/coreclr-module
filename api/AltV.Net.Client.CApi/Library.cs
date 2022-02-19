using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
namespace AltV.Net.Client.CApi
{
    public unsafe interface ILibrary
    {
        public delegate* unmanaged[Cdecl]<string, void> LogInfo { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogDebug { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogWarning { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogError { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, string> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, string, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, string, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<object, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<object, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<object, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<object, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<object, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<object, string, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<object, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<object, string[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueBlip { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValuePlayer { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueVehicle { get; }
        public delegate* unmanaged[Cdecl]<object, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<object, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<object, ulong, object, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, object, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, string[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<object, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, object, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, object, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
    }

    public unsafe class Library : ILibrary
    {
        private const string DllName = "coreclr-client-module";

        public delegate* unmanaged[Cdecl]<string, void> LogInfo { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogDebug { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogWarning { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogError { get; }
        public delegate* unmanaged[Cdecl]<string, void> LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, string> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, string, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, string, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<object, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<object, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<object, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<object, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<object, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<object, string, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<object, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<object, string[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueBlip { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValuePlayer { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueVehicle { get; }
        public delegate* unmanaged[Cdecl]<object, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<object, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<object, object, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<object, ulong, object, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, object, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, string[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<object, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, object, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, object, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public Library()
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(DllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            LogInfo = (delegate* unmanaged[Cdecl]<string, void>) NativeLibrary.GetExport(handle, "LogInfo");
            LogDebug = (delegate* unmanaged[Cdecl]<string, void>) NativeLibrary.GetExport(handle, "LogDebug");
            LogWarning = (delegate* unmanaged[Cdecl]<string, void>) NativeLibrary.GetExport(handle, "LogWarning");
            LogError = (delegate* unmanaged[Cdecl]<string, void>) NativeLibrary.GetExport(handle, "LogError");
            LogColored = (delegate* unmanaged[Cdecl]<string, void>) NativeLibrary.GetExport(handle, "LogColored");
            Resource_GetName = (delegate* unmanaged[Cdecl]<nint, string>) NativeLibrary.GetExport(handle, "Resource_GetName");
            Resource_GetFile = (delegate* unmanaged[Cdecl]<nint, string, int*, nint*, void>) NativeLibrary.GetExport(handle, "Resource_GetFile");
            Resource_FileExists = (delegate* unmanaged[Cdecl]<nint, string, bool>) NativeLibrary.GetExport(handle, "Resource_FileExists");
            Core_CreateMValueNil = (delegate* unmanaged[Cdecl]<object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueNil");
            Core_CreateMValueBool = (delegate* unmanaged[Cdecl]<object, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBool");
            Core_CreateMValueInt = (delegate* unmanaged[Cdecl]<object, long, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueInt");
            Core_CreateMValueUInt = (delegate* unmanaged[Cdecl]<object, ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueUInt");
            Core_CreateMValueDouble = (delegate* unmanaged[Cdecl]<object, double, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDouble");
            Core_CreateMValueString = (delegate* unmanaged[Cdecl]<object, string, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueString");
            Core_CreateMValueList = (delegate* unmanaged[Cdecl]<object, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueList");
            Core_CreateMValueDict = (delegate* unmanaged[Cdecl]<object, string[], nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDict");
            Core_CreateMValueCheckpoint = (delegate* unmanaged[Cdecl]<object, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueCheckpoint");
            Core_CreateMValueBlip = (delegate* unmanaged[Cdecl]<object, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBlip");
            Core_CreateMValueVoiceChannel = (delegate* unmanaged[Cdecl]<object, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVoiceChannel");
            Core_CreateMValuePlayer = (delegate* unmanaged[Cdecl]<object, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValuePlayer");
            Core_CreateMValueVehicle = (delegate* unmanaged[Cdecl]<object, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVehicle");
            Core_CreateMValueVector3 = (delegate* unmanaged[Cdecl]<object, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector3");
            Core_CreateMValueVector2 = (delegate* unmanaged[Cdecl]<object, Vector2, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector2");
            Core_CreateMValueRgba = (delegate* unmanaged[Cdecl]<object, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueRgba");
            Core_CreateMValueByteArray = (delegate* unmanaged[Cdecl]<object, ulong, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueByteArray");
            MValueConst_GetBool = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetBool");
            MValueConst_GetInt = (delegate* unmanaged[Cdecl]<nint, long>) NativeLibrary.GetExport(handle, "MValueConst_GetInt");
            MValueConst_GetUInt = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetUInt");
            MValueConst_GetDouble = (delegate* unmanaged[Cdecl]<nint, double>) NativeLibrary.GetExport(handle, "MValueConst_GetDouble");
            MValueConst_GetString = (delegate* unmanaged[Cdecl]<nint, object, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetString");
            MValueConst_GetListSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetListSize");
            MValueConst_GetList = (delegate* unmanaged[Cdecl]<nint, nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetList");
            MValueConst_GetDictSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetDictSize");
            MValueConst_GetDict = (delegate* unmanaged[Cdecl]<nint, string[], nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetDict");
            MValueConst_GetEntity = (delegate* unmanaged[Cdecl]<nint, object, object>) NativeLibrary.GetExport(handle, "MValueConst_GetEntity");
            MValueConst_CallFunction = (delegate* unmanaged[Cdecl]<object, nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "MValueConst_CallFunction");
            MValueConst_GetVector3 = (delegate* unmanaged[Cdecl]<nint, object, void>) NativeLibrary.GetExport(handle, "MValueConst_GetVector3");
            MValueConst_GetRGBA = (delegate* unmanaged[Cdecl]<nint, object, void>) NativeLibrary.GetExport(handle, "MValueConst_GetRGBA");
            MValueConst_GetByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, object, void>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArray");
            MValueConst_GetByteArraySize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArraySize");
            MValueConst_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_AddRef");
            MValueConst_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_RemoveRef");
            MValueConst_Delete = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_Delete");
            MValueConst_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetType");
        }
    }
}