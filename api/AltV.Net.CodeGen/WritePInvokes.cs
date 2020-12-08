using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltV.Net.CodeGen
{
    public static class WritePInvokes
    {
        //TODO: add a dictionary for unsafe code to generate headers for that as well
        private static readonly IDictionary<string, string> CToCSharpTypes = new Dictionary<string, string>
        {
            ["alt::IPlayer*"] = "IntPtr",
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
            ["position_t&"] = "ref Position",
            ["position_t"] = "Position",
            ["alt::Position"] = "Position",
            ["rotation_t&"] = "ref Rotation",
            ["rotation_t"] = "Rotation",
            ["alt::Rotation"] = "Rotation",
            ["const char*"] = "IntPtr",
            ["alt::MValue&"] = "ref MValue",
            ["alt::MValue*"] = "ref MValue",
            ["bool"] = "bool",
            ["const char*&"] = "ref IntPtr",
            ["int"] = "int",
            ["int*"] = "ref int",
            ["alt::Array<uint32_t>&"] = "ref UIntArray",
            ["alt::Array<uint32_t>*"] = "ref UIntArray",
            ["float"] = "float",
            ["float*"] = "ref float",
            ["alt::IVehicle*"] = "IntPtr",
            ["void*"] = "IntPtr",
            ["alt::IBaseObject::Type&"] = "ref BaseObjectType",
            ["player_struct_t*"] = "ref ReadOnlyPlayer",
            ["rgba_t&"] = "ref Rgba",
            ["alt::RGBA"] = "Rgba",
            ["bool*"] = "ref bool",
            ["alt::IColShape*"] = "IntPtr",
            ["alt::ColShapeType"] = "ColShapeType",
            ["alt::IEntity*"] = "IntPtr",
            ["alt::IVoiceChannel*"] = "IntPtr",
            ["alt::IBlip*"] = "IntPtr",
            ["alt::IResource*"] = "IntPtr",
            ["alt::Array<alt::String>&"] = "ref StringArray",
            ["alt::MValue::List&"] = "ref MValueArray",
            ["const alt::MValue&"] = "ref MValue",
            ["const char**"] = "string[]",
            ["alt::IResource::Impl*"] = "IntPtr",
            ["CSharpResourceImpl*"] = "IntPtr",
            ["alt::MValueFunction::Invoker*"] = "IntPtr",
            ["MValueFunctionCallback"] = "MValue.Function",
            ["CustomInvoker*"] = "IntPtr",
            ["double"] = "double",
            ["alt::MValue[]"] = "MValue[]",
            ["alt::MValueList&"] = "ref MValue", //no c# representation for MValue list memory layout yet
            ["const alt::MValueList&"] = "ref MValue", //no c# representation for MValue list memory layout yet
            ["alt::MValueDict&"] = "ref MValue", //no c# representation for MValue dictionary memory layout yet
            ["alt::ICheckpoint*"] = "IntPtr",
            ["uint64_t&"] = "ref ulong",
            ["alt::MValueFunction&"] =
                "ref MValue", //no c# representation for MValue function memory layout yet, this is only in commented code and not required
            ["alt::ICore*"] = "IntPtr",
            ["alt::CEvent::Type"] = "ushort",
            ["alt::CEvent*"] = "IntPtr",
            ["alt::EventCallback"] = "AltV.Net.Server.EventCallback",
            ["alt::TickCallback"] = "AltV.Net.Server.TickCallback",
            ["alt::CommandCallback"] = "AltV.Net.Server.CommandCallback",
            ["alt::Array<alt::IPlayer*>*"] = "ref PlayerPointerArray",
            ["alt::Array<alt::IVehicle*>*"] = "ref VehiclePointerArray",
            ["alt::Array<alt::IPlayer*>&"] = "ref PlayerPointerArray",
            ["alt::Array<alt::IVehicle*>&"] = "ref VehiclePointerArray",
            ["alt::Array<alt::StringView>*"] = "ref StringViewArray",
            ["alt::Array<alt::String>*"] = "ref StringArray",
            ["alt::Array<alt::MValue>*"] = "ref MValueArray",
            ["alt::MValueConst*"] = "IntPtr",
            ["alt::MValueConst*[]"] = "IntPtr[]",
            ["const char*[]"] = "IntPtr[]",
            ["alt::MValue*[]"] = "IntPtr[]",
            ["alt::IPlayer*[]"] = "IntPtr[]",
            ["alt::IVehicle*[]"] = "IntPtr[]",
            ["char[]"] = "IntPtr",
            ["uint8_t&"] = "ref byte",
            ["rgba_t"] = "Rgba",
            ["void*"] = "IntPtr",
            ["const void*"] = "IntPtr"
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
            foreach (var method in methods)
            {
                var template = $@"[DllImport(DllName, CallingConvention = NativeCallingConvention)]
internal static extern {TypeToCSharp(method.ReturnType)} {method.Name}({string.Join(", ", method.Params.Select(param => TypeToCSharp(param.Type, param.Name) + " " + TransformParameterName(param.Name)).ToArray())});";
                template += Environment.NewLine;
                fullFile.Append(template);
            }

            return fullFile.ToString();
        }
    }
}