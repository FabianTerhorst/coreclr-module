using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AltV.Net.CApi.Generator;

public static class Codegen
{

    private static string GetCMethodDelegateType(CMethod method)
    {
        var noGc = method.NoGc ? ", SuppressGCTransition" : "";
        var args = string.Join("", method.Params.Select(p => p.Type + ", "));
        return $"delegate* unmanaged[Cdecl{noGc}]<{args}{method.ReturnType}>";
    }
        
    private static string GetCMethodArgs(CMethod method)
    {
        return string.Join(", ", method.Params.Select(p => p.Type + " " + p.Name));
    }

    public static void Generate()
    {
        var libOutputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "../../../../AltV.Net.CApi/Libraries"); 
        var tableOutputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "../../../../../runtime/c-api/func_table.cpp");

        var tableHashes = new StringBuilder();
        var tablePointers = new StringBuilder();

        var parsedMethods = Parser.ParseMethods(Environment.CurrentDirectory).ToArray();

        // Ignoring hash collisions if the names are the same
        // Server and client libraries are allowed to have methods with the colliding names
        var collisionFound = false;
        foreach (var collision in parsedMethods.GroupBy(e => e.Hash)
            .Where(e => e.Count() > 1 && e.DistinctBy(n => n.Name).Count() > 1))
        {
            collisionFound = true;
            Console.WriteLine("Colliding methods: " + string.Join(",", collision.Select(e => e.Name)));
        }
            
        if (collisionFound) throw new Exception("Collision found!");

        var capiHash = FnvHash.Generate(string.Join(";", parsedMethods.Select(e => e.Hash)));
            
        foreach (var group in parsedMethods.OrderBy(e => e.Name).GroupBy(e => e.Target))
        {
            #region C# bindings
            var target = group.Key.ForceCapitalize();
                
            var methods = string.Join("\n", group.Where(e => !e.OnlyManual)
                .Select(e => $"        public {GetCMethodDelegateType(e)} {e.Name} {{ get; }}"));
                
            // todo add docs link to the exception
            var fallbacks = string.Join("\n", group.Where(e => !e.OnlyManual)
                .Select(e => $"        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate {e.ReturnType} {e.Name}Delegate({GetCMethodArgs(e)});\n"
                             + $"        private static {e.ReturnType} {e.Name}Fallback({GetCMethodArgs(e)}) => throw new Exceptions.OutdatedSdkException(\"{e.Name}\", \"{e.Name} SDK method is outdated. Please update your module nuget\");"));
                
            var loads = string.Join("\n", group.Where(e => !e.OnlyManual)
                .Select(e => $"            {e.Name} = ({GetCMethodDelegateType(e)}) GetUnmanagedPtr<{e.Name}Delegate>(funcTable, {e.Hash}UL, {e.Name}Fallback);"));
                
            var output = new StringBuilder();

            output.Append("// ReSharper disable InconsistentNaming\n");
            output.Append("using AltV.Net.Data;\n");
            output.Append("using System.Numerics;\n");
            output.Append("using System.Runtime.InteropServices;\n");
            output.Append("using AltV.Net.Elements.Args;\n");
            output.Append("using AltV.Net.Elements.Entities;\n\n");
            output.Append("namespace AltV.Net.CApi.Libraries\n{\n");

            output.Append($"    public unsafe interface I{target}Library\n    {{\n");
            output.Append($"        public bool Outdated {{ get; }}\n");
            output.Append(methods + "\n");
            output.Append("    }\n\n");

            output.Append($"    public unsafe class {target}Library : I{target}Library\n    {{\n");
            output.Append($"        public readonly uint Methods = {parsedMethods.Length};\n");
            output.Append(methods + "\n");
            output.Append(fallbacks + "\n");

            output.Append($"        public bool Outdated {{ get; private set; }}\n");
            output.Append($"        private IntPtr GetUnmanagedPtr<T>(IDictionary<ulong, IntPtr> funcTable, ulong hash, T fn) where T : Delegate {{\n");
            output.Append($"            if (funcTable.TryGetValue(hash, out var ptr)) return ptr;\n");
            output.Append($"            Outdated = true;\n");
            output.Append($"            return Marshal.GetFunctionPointerForDelegate<T>(fn);\n");
            output.Append($"        }}\n");
            output.Append($"        public {target}Library(Dictionary<ulong, IntPtr> funcTable)\n");
            output.Append($"        {{\n");
            output.Append($"            if (!funcTable.TryGetValue(0, out var capiHash)) Outdated = true;\n");
            output.Append($"            if (*(ulong*)capiHash != {capiHash}UL) Outdated = true;\n");
            output.Append(loads + "\n");
            output.Append("        }\n");

            output.Append("    }\n");

            output.Append("}");

            File.WriteAllText(Path.Combine(libOutputPath, $"{target}Library.cs"), output.ToString());
            #endregion
                
            #region Func table

            if (group.Key != "SHARED")
            {
                tableHashes.Append($"    #ifdef ALT_{group.Key}_API\n");
                tablePointers.Append($"    #ifdef ALT_{group.Key}_API\n");
            }
                
            foreach (var e in group)
            {
                tableHashes.Append($"    {e.Hash}UL,\n");
                tablePointers.Append($"    (void*) {e.Name},\n");
            }
                
            if (group.Key != "SHARED")
            {
                tableHashes.Append($"    #endif\n");
                tablePointers.Append($"    #endif\n");
            }
            #endregion
        }

        var table = new StringBuilder();
        table.Append("#include \"func_table.h\"\n\n");
            
        table.Append($"inline uint64_t capiHash = {capiHash}UL;\n");
        table.Append("inline uint64_t capiHashes[] = {\n");
        table.Append("    0,\n");
        table.Append(tableHashes);
        table.Append("};\n\n");
            
        table.Append("inline void* capiPointers[] = {\n");
        table.Append("    (void*) &capiHash,\n");
        table.Append(tablePointers);
        table.Append("};\n\n");

        table.Append("const function_table_t* get_func_table() {\n");
        table.Append("    static constexpr function_table_t data {\n");
        table.Append("        std::extent<decltype(capiHashes)>::value,\n");
        table.Append("        &capiHashes[0],\n");
        table.Append("        &capiPointers[0]\n");
        table.Append("    };\n");
        table.Append("    return &data;\n");
        table.Append("}");
            
        File.WriteAllText(tableOutputPath, table.ToString());
    } 
        
    public static void Main()
    {
        Generate();
    }
}