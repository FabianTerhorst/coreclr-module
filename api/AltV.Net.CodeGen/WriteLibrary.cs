using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltV.Net.CodeGen
{
    public static class WriteLibrary
    {
        private const string Quote = "\"";
        
        private static readonly IDictionary<string, string> CToCSharpTypes = new Dictionary<string, string>
        {
            ["alt::IPlayer*"] = "nint",
            ["int8_t"] = "sbyte",
            ["uint8_t"] = "byte",
            ["int16_t"] = "short",
            ["uint16_t"] = "ushort",
            ["int32_t"] = "int",
            ["uint32_t"] = "uint",
            ["int64_t"] = "long",
            ["uint64_t"] = "ulong",
            ["void"] = "void",
            ["uint16_t&"] = "ref ushort",
            ["position_t&"] = "Position*",
            ["position_t"] = "Position",
            ["alt::Position"] = "Position",
            ["rotation_t&"] = "ref Rotation",
            ["rotation_t"] = "Rotation",
            ["alt::Rotation"] = "Rotation",
            ["cloth_t&"] = "ref Cloth",
            ["cloth_t"] = "Cloth",
            ["dlccloth_t&"] = "ref DlcCloth",
            ["dlccloth_t"] = "DlcCloth",
            ["prop_t&"] = "ref Prop",
            ["prop_t"] = "Prop",
            ["dlcprop_t&"] = "ref DlcProp",
            ["dlcprop_t"] = "DlcProp",
            ["const char*"] = "nint",
            ["alt::MValue&"] = "ref MValue",
            ["alt::MValue*"] = "ref MValue",
            ["bool"] = "bool",
            ["const char*&"] = "ref nint",
            ["int"] = "int",
            ["int*"] = "ref int",
            ["alt::Array<uint32_t>&"] = "ref UIntArray",
            ["alt::Array<uint32_t>*"] = "ref UIntArray",
            ["float"] = "float",
            ["float*"] = "ref float",
            ["alt::IVehicle*"] = "nint",
            ["void*"] = "nint",
            ["alt::IBaseObject::Type&"] = "ref BaseObjectType",
            ["player_struct_t*"] = "ref ReadOnlyPlayer",
            ["rgba_t&"] = "ref Rgba",
            ["alt::RGBA"] = "Rgba",
            ["bool*"] = "ref bool",
            ["alt::IColShape*"] = "nint",
            ["alt::ColShapeType"] = "ColShapeType",
            ["alt::IEntity*"] = "nint",
            ["alt::IVoiceChannel*"] = "nint",
            ["alt::IBlip*"] = "nint",
            ["alt::IResource*"] = "nint",
            ["alt::Array<alt::String>&"] = "ref StringArray",
            ["alt::MValue::List&"] = "ref MValueWriter2.MValueArray",
            ["const alt::MValue&"] = "ref MValue",
            ["const char**"] = "string[]",
            ["alt::IResource::Impl*"] = "nint",
            ["CSharpResourceImpl*"] = "nint",
            ["alt::MValueFunction::Invoker*"] = "nint",
            ["MValueFunctionCallback"] = "MValueFunctionCallback",//"MValue.Function",
            ["CustomInvoker*"] = "nint",
            ["double"] = "double",
            ["alt::MValue[]"] = "MValue[]",
            ["alt::MValueList&"] = "ref MValue", //no c# representation for MValue list memory layout yet
            ["const alt::MValueList&"] = "ref MValue", //no c# representation for MValue list memory layout yet
            ["alt::MValueDict&"] = "ref MValue", //no c# representation for MValue dictionary memory layout yet
            ["alt::ICheckpoint*"] = "nint",
            ["uint64_t&"] = "ref ulong",
            ["alt::MValueFunction&"] =
                "ref MValue", //no c# representation for MValue function memory layout yet, this is only in commented code and not required
            ["alt::ICore*"] = "nint",
            ["alt::CEvent::Type"] = "ushort",
            ["alt::CEvent*"] = "nint",
            ["alt::EventCallback"] = "AltV.Net.Server.EventCallback",
            ["alt::TickCallback"] = "AltV.Net.Server.TickCallback",
            ["alt::CommandCallback"] = "AltV.Net.Server.CommandCallback",
            ["alt::Array<alt::IPlayer*>*"] = "ref PlayerPointerArray",
            ["alt::Array<alt::IVehicle*>*"] = "ref VehiclePointerArray",
            ["alt::Array<alt::IPlayer*>&"] = "ref PlayerPointerArray",
            ["alt::Array<alt::IVehicle*>&"] = "ref VehiclePointerArray",
            ["alt::Array<alt::StringView>*"] = "ref StringViewArray",
            ["alt::Array<alt::String>*"] = "ref StringArray",
            ["alt::Array<alt::MValue>*"] = "ref MValueWriter2.MValueArray",
            ["alt::MValueConst*"] = "nint",
            ["alt::MValueConst*[]"] = "nint[]",
            ["const char*[]"] = "nint[]",
            ["alt::MValue*[]"] = "nint[]",
            ["alt::IPlayer*[]"] = "nint[]",
            ["alt::IVehicle*[]"] = "nint[]",
            ["char[]"] = "nint",
            ["uint8_t&"] = "ref byte",
            ["rgba_t"] = "Rgba",
            ["void*"] = "nint",
            ["const void*"] = "nint"
        };

        private static string TypeToCSharp(string cType, string name = null)
        {
            if (name == "base64" && cType == "const char*") return "string";
            cType = cType.Replace(" &", "&").Replace(" *", "*");
            if (CToCSharpTypes.TryGetValue(cType, out var cSharpType))
            {
                return cSharpType;
            }

            throw new ArgumentException("No csharp type found for:" + cType + " param:" + name);
        }

        private static string TransformParameterName(string parameterName)
        {
            var splitParamName = parameterName.Split("_");
            if (splitParamName.Length < 2) return parameterName;

            var newParamName = "";
            for (int i = 0, length = splitParamName.Length; i < length; i++)
            {
                if (i > 0)
                {
                    newParamName += splitParamName[i].FirstCharToUpper();
                }
                else
                {
                    newParamName += splitParamName[i];
                }
            }

            return newParamName;
        }

        public static string Write(ParseExports.CMethod[] methods)
        {
            var fullFile = new StringBuilder();
            var properties = new StringBuilder();
            var exports = new StringBuilder();
            var imports = new StringBuilder();
            imports.Append($@"using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Native;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;");

            fullFile.Append(imports);
            
            foreach (var method in methods)
            {
                var template = $@"    public delegate* unmanaged[Cdecl]<{string.Join(", ", method.Params.Select(param => TypeToCSharp(param.Type, param.Name)).ToArray())}, {TypeToCSharp(method.ReturnType)}> {method.Name} {{ get; }}";
                template += Environment.NewLine;
                properties.Append(template);

                var exportTemplate = $@"        {method.Name} = (delegate* unmanaged[Cdecl]<{string.Join(", ", method.Params.Select(param => TypeToCSharp(param.Type, param.Name)).ToArray())}, {TypeToCSharp(method.ReturnType)}>) NativeLibrary.GetExport(handle, {Quote}{method.Name}{Quote});";
                exportTemplate += Environment.NewLine;
                exports.Append(exportTemplate);
            }

            var interfaceFile = new StringBuilder();

            var interfaceTemplate = $@"
public unsafe interface ILibrary
{{
{properties}
}}";
            interfaceTemplate += Environment.NewLine;

            fullFile.Append(interfaceTemplate);

            var implementationFile = new StringBuilder();

            var implementationTemplate = $@"
public unsafe class Library : ILibrary
{{
    private const string DllName = {Quote}csharp-module{Quote};

{properties}
    public Library() 
    {{
        var handle = NativeLibrary.Load(DllName);
{exports}
    }}
}}";
            
            fullFile.Append(implementationTemplate);

            return fullFile.ToString();
        }
    }
}