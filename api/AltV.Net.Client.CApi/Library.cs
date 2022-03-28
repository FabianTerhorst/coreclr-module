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
        }
    }
}