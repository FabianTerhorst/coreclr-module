using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Mock2")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        private const string DllName = "csharp-module";
        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;

        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        internal static extern void FreeUIntArray(ref UIntArray array);
        
        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        internal static extern void FreePlayerPointerArray(ref PlayerPointerArray array);
        
        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        internal static extern void FreeVehiclePointerArray(ref VehiclePointerArray array);
        
        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        internal static extern void FreeStringViewArray(ref StringViewArray array);
        
        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        internal static extern void FreeStringArray(ref StringArray array);
        
        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        internal static extern void FreeMValueArray(ref MValueArray array);
    }
}