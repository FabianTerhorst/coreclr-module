using System;
using System.Collections.Generic;
using System.Linq;

namespace AltV.Net.CodeGen
{
    public static class WritePInvokes
    {
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
            ["position_t&"] = "ref Position",
            ["alt::Position"] = "Position",
            ["rotation_t&"] = "ref Rotation",
            ["alt::Rotation"] = "Rotation",
            ["const char*"] = "IntPtr",
            ["alt::MValue&"] = "ref MValue",
            ["alt::MValue*"] = "ref MValue",
            ["bool"] = "bool",
            ["const char*&"] = "ref IntPtr",
            ["int"] = "int",
            ["alt::Array<uint32_t>&"] = "ref UIntArray",
            ["float"] = "float",
            ["alt::IVehicle*"] = "IntPtr",
            ["void*"] = "IntPtr",
            ["alt::IBaseObject::Type&"] = "ref BaseObjectType",
            ["player_struct_t*"] = "ref ReadOnlyPlayer"
        };

        private static string TypeToCSharp(string cType)
        {
            cType = cType.Replace(" &", "&");
            if (CToCSharpTypes.TryGetValue(cType, out var cSharpType))
            {
                return cSharpType;
            }

            throw new ArgumentException("No csharp type found for:" + cType);
        }

        public static void Write(ParseExports.CMethod[] methods)
        {
            foreach (var method in methods)
            {
                var template = $@"[DllImport(DllName, CallingConvention = NativeCallingConvention)]
internal static extern {TypeToCSharp(method.ReturnType)} {method.Name}({string.Join(", ", method.Params.Select(param => TypeToCSharp(param.Type) + " " + param.Name).ToArray())});";
                Console.WriteLine(template);
                Console.WriteLine();
            }
        }
    }
}