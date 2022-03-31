using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace AltV.Net.CodeGen
{
    public struct CMethod
    {
        public string ReturnType;
        public string Name;
        public string Target;
        public CMethodParam[] Params;
    }

    public struct CMethodParam
    {
        public string Type;
        public string Name;
    }
    
    public static class Codegen
    {
        private static readonly Regex ExportRegex = new(@"EXPORT_(?<target>\w+)\s+(?:(?:const\s+)?(?<type>\S+)\s+(?<name>\S+)\s*\((?<args>.*?)\)|(?<name>\S+)\s*=\s*(?<type>\S+)\s*\(\s*\*\s*\)\s*\((?<args>.*?)\))", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex ArgsRegex = new(@"(?:const\s+)?(?:\/\**\s*(?<typeOverride>.*?)\s*\*\/\s*)?(?<type>.*?)\s*(?<name>[\w\d_\-\[\]]+)(?:,\s*|$)", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex CommentRegex = new(@"//.*?(?:$|[\n\r]+)", RegexOptions.Compiled);
        private static readonly Regex TypeExtraSpaceRegex = new(@" {2,}| +(?=[\*\&]+$)", RegexOptions.Compiled);

        private static IEnumerable<CMethod> ParseMethods()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.h", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var text = CommentRegex.Replace(File.ReadAllText(file), "");
           
                foreach (Match match in ExportRegex.Matches(text))
                {
                    var type = match.Groups["type"].Value;
                    var name = match.Groups["name"].Value;
                    var target = match.Groups["target"].Value;
                    var csReturnType = CsTypes.FirstOrDefault(t => t.Key == type).Value ?? "object";

                    var args = new List<CMethodParam>();
                    var matches = ArgsRegex.Matches(match.Groups["args"].Value);
                    for (var i = 0; i < matches.Count; i++)
                    {
                        var matchArg = matches[i];
                        var argType = TypeExtraSpaceRegex.Replace(matchArg.Groups["type"].Value, "");
                        var argName = matchArg.Groups["name"].Value;
                        if (argName.EndsWith("[]")) argType += "[]";

                        var csArgType = matchArg.Groups.ContainsKey("typeOverride") && matchArg.Groups["typeOverride"].Value is not ""
                            ? matchArg.Groups["typeOverride"].Value 
                            : CsTypes.FirstOrDefault(t => t.Key == argType).Value ?? "object";
                     
                        args.Add(new CMethodParam
                        {
                            Name = name,
                            Type = csArgType
                        });
                    }
                    
                    yield return new CMethod
                    {
                        Name = name,
                        ReturnType = csReturnType,
                        Params = args.ToArray(),
                        Target = target,
                    };
                }
            }
        }
        
        public static void Generate()
        {
            var outputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "Codegen Output"); 
            Directory.CreateDirectory(outputPath);
            
            foreach (var group in ParseMethods().OrderBy(e => e.Name).GroupBy(e => e.Target))
            {
                var target = group.Key.ForceCapitalize();

                var methods = string.Join("\n", group.Select(e => $"        public delegate* unmanaged[Cdecl]<{string.Join("", e.Params.Select(p => p.Type + ", "))}{e.ReturnType}> {e.Name} {{ get; }}"));
                var loads = string.Join("\n", group.Select(e => $"            {e.Name} = (delegate* unmanaged[Cdecl]<{string.Join("", e.Params.Select(p => p.Type + ", "))}{e.ReturnType}>) NativeLibrary.GetExport(handle, \"{e.Name}\");"));
                
                var output = new StringBuilder();

                output.Append("using AltV.Net.Data;\n");
                output.Append("using System.Numerics;\n");
                output.Append("using System.Reflection;\n");
                output.Append("using System.Runtime.InteropServices;\n");
                output.Append("using AltV.Net.Elements.Args;\n");
                output.Append("using AltV.Net.Elements.Entities;\n");
                output.Append("using AltV.Net.Native;\n\n");
                output.Append("namespace AltV.Net.CApi.Libraries\n{\n");

                output.Append($"    public unsafe interface I{target}Library\n    {{\n");
                output.Append(methods + "\n");
                output.Append("    }\n\n");

                output.Append($"    public unsafe class {target}Library : I{target}Library\n    {{\n");
                output.Append(methods + "\n");

                output.Append($"        public {target}Library(string dllName)\n");
                output.Append("        {\n");
                output.Append(
                    "            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;\n");
                output.Append("            var handle = NativeLibrary.Load(dllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);\n");
                output.Append(loads + "\n");
                output.Append("        }\n");

                output.Append("    }\n");

                output.Append("}");

                File.WriteAllText(Path.Combine(outputPath, $"{target}Library.cs"), output.ToString());
            }
        }

        private static readonly SortedDictionary<string, string> CsTypes = new()
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
            {"char*", "nint"},
            {"char[]", "nint"},
            {"char*&", "nint*"},
            {"char*[]", "nint[]"},
            {"int*", "int*"},
            {"alt::ICore*", "nint"},
            {"alt::ILocalPlayer*", "nint"},
            {"alt::IPlayer*", "nint"},
            {"alt::IVehicle*", "nint"},
            {"alt::IHandlingData*", "nint"},
            {"alt::IHandlingData*&", "nint*"},
            {"alt::IEntity*", "nint"},
            {"alt::IWorldObject*", "nint"},
            {"alt::IBaseObject*", "nint"},
            {"alt::IResource*", "nint"},
            {"alt::IWebView*", "nint"},
            {"alt::ILocalStorage*", "nint"},
            {"CSharpResourceImpl*", "nint"},
            {"void**", "nint*"},
            {"alt::MValueConst*", "nint"},
            {"alt::MValueConst*[]", "nint[]"},
            {"int8_t", "sbyte"},
            {"int8_t&", "sbyte*"},
            {"uint8_t", "byte"},
            {"uint8_t&", "byte*"},
            {"int16_t", "short"},
            {"int16_t&", "short*"},
            {"uint16_t", "ushort"},
            {"uint16_t&", "ushort*"},
            {"int32_t", "int"},
            {"int32_t&", "int*"},
            {"uint32_t", "uint"},
            {"uint32_t&", "uint*"},
            {"int64_t", "long"},
            {"int64_t&", "long*"},
            {"uint64_t", "ulong"},
            {"uint64_t&", "ulong*"},
            {"vector2_t", "Vector2"},
            {"vector2_t&", "Vector2*"},
            {"vector3_t", "Vector3"},
            {"vector3_t&", "Vector3*"},
            {"rgba_t", "Rgba"},
            {"rgba_t&", "Rgba*"},
            {"alt::Array<uint32_t>", "UIntArray*"},
            
            { "position_t&", "Vector3*" },
            { "position_t", "Vector3" },
            { "alt::Position", "Vector3" },
            { "rotation_t&", "Rotation*" },
            { "rotation_t", "Rotation" },
            { "alt::Rotation", "Rotation" },
            
            { "cloth_t&", "Cloth*" },
            { "cloth_t", "Cloth" },
            { "dlccloth_t&", "DlcCloth*" },
            { "dlccloth_t", "DlcCloth" },
            { "prop_t&", "Prop*" },
            { "prop_t", "Prop" },
            { "dlcprop_t&", "DlcProp*" },
            { "dlcprop_t", "DlcProp" },
            { "const char*", "nint" },
            { "alt::MValue&", "MValue*" },
            { "alt::MValue*", "MValue*" },
            { "const char*&", "nint*" },
            { "alt::Array<uint32_t>&", "UIntArray*" },
            { "alt::Array<uint32_t>*", "UIntArray*" },
            { "void*", "nint" },
            { "alt::IBaseObject::Type&", "BaseObjectType*" },
            { "player_struct_t*", "ReadOnlyPlayer*" },
            { "alt::RGBA", "Rgba" },
            { "bool*", "byte*" },
            { "alt::IColShape*", "nint" },
            { "alt::ColShapeType", "ColShapeType" },
            { "alt::IVoiceChannel*", "nint" },
            { "alt::IBlip*", "nint" },
            { "alt::Array<alt::String>&", "StringArray*" },
            //{ "alt::MValue::List&", "MValueWriter2.MValueArray*" },
            { "const alt::MValue&", "MValue*" },
            { "const char**", "string[]" },
            { "alt::IResource::Impl*", "nint" },
            { "alt::MValueFunction::Invoker*", "nint" },
            { "MValueFunctionCallback", "MValueFunctionCallback" },//"MValue.Function",
            { "CustomInvoker*", "nint" },
            { "alt::MValue[]", "MValue[]" },
            { "alt::MValueList&", "MValue*" }, //no c# representation for MValue list memory layout yet
            { "const alt::MValueList&", "MValue*" }, //no c# representation for MValue list memory layout yet
            { "alt::MValueDict&", "MValue*" }, //no c# representation for MValue dictionary memory layout yet
            { "alt::ICheckpoint*", "nint" },
            {"alt::MValueFunction&", "MValue*"}, //no c# representation for MValue function memory layout yet, this is only in commented code and not required
            { "alt::CEvent::Type", "ushort" },
            { "alt::CEvent*", "nint" },
            { "alt::EventCallback", "EventCallback" },
            { "alt::TickCallback", "TickCallback" },
            { "alt::CommandCallback", "CommandCallback" },
            { "alt::Array<alt::IPlayer*>*", "PlayerPointerArray*" },
            { "alt::Array<alt::IVehicle*>*", "VehiclePointerArray*" },
            { "alt::Array<alt::IPlayer*>&", "PlayerPointerArray*" },
            { "alt::Array<alt::IVehicle*>&", "VehiclePointerArray*" },
            { "alt::Array<alt::StringView>*", "StringViewArray*" },
            { "alt::Array<alt::String>*", "StringArray*" },
            { "alt::Array<alt::MValue>*", "MValueWriter2.MValueArray*" },
            { "alt::MValue*[]", "nint[]" },
            { "alt::IPlayer*[]", "nint[]" },
            { "alt::IVehicle*[]", "nint[]" },
            { "uint8_t*", "byte*" },
            { "head_blend_data_t", "HeadBlendData" },
            { "head_blend_data_t&", "HeadBlendData*" },
            { "head_overlay_t", "HeadOverlay" },
            { "head_overlay_t&", "HeadOverlay*" },
            { "weapon_t*[]", "WeaponData[]" },
            { "alt::Array<weapon_t>&", "WeaponArray*" },
            { "vector2_t[]", "Vector2[]" },
            { "alt::IConnectionInfo*", "IntPtr" },
            { "ClrVehicleModelInfo*", "nint" }
        };
        
        public static void Main(string[] args)
        {
            Generate();
        }
    }
}