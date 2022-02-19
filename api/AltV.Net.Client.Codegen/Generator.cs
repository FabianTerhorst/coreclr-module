using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace AltV.Net.Client.Codegen
{
    
    public static class Codegen
    {
        private static readonly Regex ExportRegex = new(@"EXPORT +(?:(?:const +)?(?<type>[^ ]+) +(?<name>[^ ]+) *\((?<args>.*?)\)|(?<name>[^ ]+) *= *(?<type>[^ ]+) *\( *\* *\) *\((?<args>.*?)\))", RegexOptions.Compiled);
        private static readonly Regex ArgsRegex = new(@"(?:const +)?(.*?) +([^ ]+)(?:, *|$)", RegexOptions.Compiled);
        private static readonly Regex CommentRegex = new(@"//.*?(?:$|[\n\r]+)", RegexOptions.Compiled);
        
        private const string DllName = "coreclr-client-module";
        public static void Generate()
        {
            // get all files in the directory
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.h", SearchOption.TopDirectoryOnly);

            var superClassInterface = new StringBuilder();
            var superClassFields = new StringBuilder();
            
            var outputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "Codegen Output");
            Directory.CreateDirectory(outputPath);

            var methods = new StringBuilder();
            var load = new StringBuilder();
            
            foreach (var file in files)
            {
                // get file contents
                var text = CommentRegex.Replace(File.ReadAllText(file), "");
                var filename = Path.GetFileNameWithoutExtension(file);
                filename = $"{filename[0].ToString().ToUpper()}{filename.AsSpan(1)}";
           
                foreach (Match match in ExportRegex.Matches(text))
                {
                    var type = match.Groups[1].Value;
                    var name = match.Groups[2].Value;
                    var csReturnType = CsTypes.FirstOrDefault(t => t.Key == type).Value ?? "object";

                    var delegateType = new StringBuilder(); 
                    delegateType.Append($"delegate* unmanaged[Cdecl]<");
                    
                    var matches = ArgsRegex.Matches(match.Groups[3].Value);
                    for (var i = 0; i < matches.Count; i++)
                    {
                        var matchArg = matches[i];
                        var argType = matchArg.Groups[1].Value;
                        var argName = matchArg.Groups[2].Value;
                        var csArgType = CsTypes.FirstOrDefault(t => t.Key == argType).Value ?? "object";
                        if (argName.EndsWith("[]")) csArgType += "[]";
                        
                        delegateType.Append($"{csArgType}, ");
                    }
                    delegateType.Append($"{csReturnType}>");

                    methods.Append($"        public {delegateType} {name} {{ get; }}\n");
                    load.Append($"            {name} = ({delegateType}) NativeLibrary.GetExport(handle, \"{name}\");\n");
                }
                
            }
            
            var output = new StringBuilder();
                
            output.Append("using System.Numerics;\n");
            output.Append("using System.Reflection;\n");
            output.Append("using System.Runtime.InteropServices;\n");
            output.Append("namespace AltV.Net.Client.CApi\n{\n");
                
            output.Append("    public unsafe interface ILibrary\n    {\n");
            output.Append(methods);
            output.Append("    }\n\n");
                
            output.Append("    public unsafe class Library : ILibrary\n    {\n");
            output.Append($"        private const string DllName = \"{DllName}\";\n\n");
            output.Append(methods);

            output.Append("        public Library()\n");
            output.Append("        {\n");
            output.Append("            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;\n");
            output.Append("            var handle = NativeLibrary.Load(DllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);\n");
            output.Append(load);
            output.Append("        }\n");
                
            output.Append("    }\n");

            output.Append("}");

            File.WriteAllText(Path.Combine(outputPath, $"Library.cs"), output.ToString());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            {"int", "int"},
            {"unsigned int", "uint"},
            {"unsigned long", "ulong"},
            {"unsigned short", "ushort"},
            {"unsigned char", "byte"},
            {"long", "long"},
            {"short", "short"},
            {"char", "char"},
            {"float", "float"},
            {"double", "double"},
            {"bool", "bool"},
            {"void", "void"},
            {"char*", "string"},
            {"const char*", "string"},
            {"int*", "int*"},
            {"alt::IResource*", "nint"},
            {"void**", "nint*"},
            {"alt::MValueConst*", "nint"},
            {"int8_t", "sbyte"},
            {"uint8_t", "byte"},
            {"int16_t", "short"},
            {"uint16_t", "ushort"},
            {"int32_t", "int"},
            {"uint32_t", "uint"},
            {"int64_t", "long"},
            {"uint64_t", "ulong"},
            {"vector2_t", "Vector2"},
            {"vector3_t", "Vector3"}
        };
        
        public static void Main(string[] args)
        {
            Generate();
        }
    }
}