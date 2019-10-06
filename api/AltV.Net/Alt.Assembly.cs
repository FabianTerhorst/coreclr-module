using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IEnumerable<Assembly> Assemblies => Module.Assemblies;

        public static Assembly LoadAssemblyFromName(AssemblyName assemblyName) =>
            Module.LoadAssemblyFromName(assemblyName);

        public static Assembly LoadAssemblyFromStream(Stream stream) => Module.LoadAssemblyFromStream(stream);

        public static Assembly LoadAssemblyFromStream(Stream stream, Stream assemblySymbols) =>
            Module.LoadAssemblyFromStream(stream, assemblySymbols);

        public static Assembly LoadAssemblyFromPath(string path) => Module.LoadAssemblyFromPath(path);

        public static Assembly LoadAssemblyFromNativeImagePath(string nativeImagePath, string assemblyPath) =>
            Module.LoadAssemblyFromNativeImagePath(nativeImagePath, assemblyPath);
    }
}