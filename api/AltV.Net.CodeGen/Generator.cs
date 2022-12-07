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
        public ulong Hash;
        public string Target;
        public CMethodParam[] Params;
        public bool NoGc;
        public bool OnlyManual;
    }

    public struct CMethodParam
    {
        public string Type;
        public string Name;
    }
    
    public static class Codegen
    {
        private static readonly Regex ExportRegex = new(@"EXPORT_(?<target>\w+)\s+(?:(?<nogc>NO_GC)\s+)?(?:(?<onlymanual>ONLY_MANUAL)\s+)?(?:(?:const\s+)?(?<type>\S+)\s+(?<name>\S+)\s*\((?<args>.*?)\)|(?<name>\S+)\s*=\s*(?<type>\S+)\s*\(\s*\*\s*\)\s*\((?<args>.*?)\))", RegexOptions.Compiled | RegexOptions.Singleline);
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
                    var nogc = match.Groups["nogc"].Length > 0;
                    var onlyManual = match.Groups["onlymanual"].Length > 0;
                    var csReturnType = CsTypes.FirstOrDefault(t => t.Key == type).Value;
                    
                    if (csReturnType is null) throw new Exception($"Unknown return type \"{type}\" in method \"{name}\"");
                    

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
                            : CsTypes.FirstOrDefault(t => t.Key == argType).Value;
                     
                        if (csArgType is null) throw new Exception($"Unknown arg type \"{argType}\" in method \"{name}\" at index {i}");
                        
                        args.Add(new CMethodParam
                        {
                            Name = name,
                            Type = csArgType
                        });
                    }
                    
                    yield return new CMethod
                    {
                        Name = name,
                        Hash = GetFnvHash(name),
                        ReturnType = csReturnType,
                        Params = args.ToArray(),
                        Target = target,
                        NoGc = nogc,
                        OnlyManual = onlyManual
                    };
                }
            }
        }

        private static string GetCMethodDelegateType(CMethod method)
        {
            var nogc = method.NoGc ? ", SuppressGCTransition" : "";
            var args = string.Join("", method.Params.Select(p => p.Type + ", "));
            return $"delegate* unmanaged[Cdecl{nogc}]<{args}{method.ReturnType}>";
        }

        private const ulong OffsetBasis = 14695981039346656037;
        private static ulong GetFnvHash(string str)
        {
            var hash = OffsetBasis;
            foreach (var c in str)
            {
                hash ^= c;
                hash += (hash << 1) + (hash << 4) + (hash << 5) + (hash << 7) + (hash << 8) + (hash << 40);
            }
            return hash;
        }

        public static void Generate()
        {
            var libOutputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "../../../../AltV.Net.CApi/Libraries"); 
            var tableOutputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "../../../../../runtime/c-api/func_table.cpp");

            var tableHashes = new StringBuilder();
            var tablePointers = new StringBuilder();

            var parsedMethods = ParseMethods().ToArray();
            
            var collisionFound = false;
            foreach (var collision in parsedMethods.GroupBy(e => e.Hash).Where(e => e.Count() > 1 && e.DistinctBy(e1 => e1.Name).Count() > 1))
            {
                collisionFound = true;
                Console.WriteLine("Colliding methods: " + string.Join(",", collision.Select(e => e.Name)));
            }

            if (collisionFound) throw new Exception("Collision found!");
            
            foreach (var group in parsedMethods.OrderBy(e => e.Name).GroupBy(e => e.Target))
            {
                #region C# bindings
                var target = group.Key.ForceCapitalize();
                
                var methods = string.Join("\n", group.Where(e => !e.OnlyManual).Select(e => $"        public {GetCMethodDelegateType(e)} {e.Name} {{ get; }}"));
                var loads = string.Join("\n", group.Where(e => !e.OnlyManual).Select(e => $"            {e.Name} = ({GetCMethodDelegateType(e)}) funcTable[{e.Hash}UL];"));
                
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
                output.Append($"        public readonly uint Methods = {parsedMethods.Length};\n");
                output.Append(methods + "\n");

                output.Append($"        public {target}Library(Dictionary<ulong, IntPtr> funcTable)\n");
                output.Append("        {\n");
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

            // if (names.Distinct().Count() != names.Count)
            //     throw new Exception("Hash collision detected! " + names.Distinct().Count() + " " + names.Count);

            var table = new StringBuilder();
            table.Append("#include \"func_table.h\"\n\n");
            
            table.Append("inline uint64_t capiHashes[] = {\n");
            table.Append(tableHashes);
            table.Append("};\n\n");
            
            table.Append("inline void* capiPointers[] = {\n");
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
            {"float*", "float*"},
            {"double", "double"},
            {"double&", "double*"},
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
            {"alt::IWeaponData*", "nint"},
            {"alt::IWeaponData*&", "nint*"},
            {"alt::IObject*", "nint"},
            {"alt::IObject**", "nint"},
            {"alt::IObject*&", "nint*"},
            {"alt::IMapData*", "nint"},
            {"alt::IAudio*", "nint"},
            {"alt::IHttpClient*", "nint"},
            {"alt::IWebSocketClient*", "nint"},
            {"alt::IEntity*", "nint"},
            {"alt::IWorldObject*", "nint"},
            {"alt::IBaseObject*", "nint"},
            {"alt::IResource*", "nint"},
            {"alt::IResource**", "nint"},
            {"alt::IWebView*", "nint"},
            {"alt::ILocalStorage*", "nint"},
            {"alt::IStatData*", "nint"},
            {"alt::IRmlDocument*", "nint"},
            {"alt::IRmlElement*", "nint"},
            {"alt::IRmlElement**", "nint"},
            {"alt::IRmlElement**&", "nint*"},
            {"void**&", "nint*"},
            {"CSharpResourceImpl*", "nint"},
            {"void**", "nint*"},
            {"alt::MValueConst*", "nint"},
            {"alt::MValueConst**", "nint"},
            {"alt::MValueConst*[]", "nint[]"},
            {"int8_t", "sbyte"},
            {"int8_t&", "sbyte*"},
            {"uint8_t", "byte"},
            {"uint8_t[]", "byte[]"},
            {"uint8_t&", "byte*"},
            {"uint8_t*&", "nint*"},
            {"int16_t", "short"},
            {"int16_t&", "short*"},
            {"uint16_t", "ushort"},
            {"uint16_t&", "ushort*"},
            {"int32_t", "int"},
            {"int32_t&", "int*"},
            {"uint32_t", "uint"},
            {"uint32_t&", "uint*"},
            {"uint32_t*", "nint"},
            {"uint32_t*&", "nint*"},
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
            { "char**", "nint" },
            { "char**&", "nint*" },
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
            { "alt::IBlip*[]", "nint[]" },
            { "uint8_t*", "byte*" },
            { "head_blend_data_t", "HeadBlendData" },
            { "head_blend_data_t&", "HeadBlendData*" },
            { "head_overlay_t", "HeadOverlay" },
            { "head_overlay_t&", "HeadOverlay*" },
            { "weapon_t*[]", "WeaponData[]" },
            { "alt::Array<weapon_t>&", "WeaponArray*" },
            { "vector2_t[]", "Vector2[]" },
            { "alt::IConnectionInfo*", "IntPtr" },
            { "ClrVehicleModelInfo*", "nint" },
            { "ClrPedModelInfo*" , "nint" },
            { "ClrDiscordUser*", "nint" },
            { "ClrConfigNodeData*", "nint" }
        };
        
        public static void Main(string[] args)
        {
            Generate();
        }
    }
}