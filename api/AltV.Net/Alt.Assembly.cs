using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IEnumerable<Assembly> Assemblies => Module.Assemblies;

        public static void LoadAssemblyFromName(AssemblyName assemblyName) => Module.LoadAssemblyFromName(assemblyName);

        public static void LoadAssemblyFromStream(Stream stream) => Module.LoadAssemblyFromStream(stream);

        public static void LoadAssemblyFromStream(Stream stream, Stream assemblySymbols) =>
            Module.LoadAssemblyFromStream(stream, assemblySymbols);

        public static void LoadAssemblyFromPath(string path) => Module.LoadAssemblyFromPath(path);

        public static void LoadAssemblyFromNativeImagePath(string nativeImagePath, string assemblyPath) =>
            Module.LoadAssemblyFromNativeImagePath(nativeImagePath, assemblyPath);
    }
}