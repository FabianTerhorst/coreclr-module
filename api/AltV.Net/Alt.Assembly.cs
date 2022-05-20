using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IEnumerable<Assembly> Assemblies => CoreImpl.Assemblies;
        
        public static WeakReference<AssemblyLoadContext> AssemblyLoadContext => CoreImpl.GetAssemblyLoadContext();

        public static Assembly LoadAssemblyFromName(AssemblyName assemblyName) =>
            CoreImpl.LoadAssemblyFromName(assemblyName);

        public static Assembly LoadAssemblyFromStream(Stream stream) => CoreImpl.LoadAssemblyFromStream(stream);

        public static Assembly LoadAssemblyFromStream(Stream stream, Stream assemblySymbols) =>
            CoreImpl.LoadAssemblyFromStream(stream, assemblySymbols);

        public static Assembly LoadAssemblyFromPath(string path) => CoreImpl.LoadAssemblyFromPath(path);

        public static Assembly LoadAssemblyFromNativeImagePath(string nativeImagePath, string assemblyPath) =>
            CoreImpl.LoadAssemblyFromNativeImagePath(nativeImagePath, assemblyPath);
    }
}