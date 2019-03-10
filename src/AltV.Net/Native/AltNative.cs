using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        private const string DllName = "csharp-module";
        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;
    }
}