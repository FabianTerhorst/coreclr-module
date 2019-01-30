using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Server
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogInfo(IntPtr serverPointer, String message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogDebug(IntPtr serverPointer, String message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogWarning(IntPtr serverPointer, String message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogError(IntPtr serverPointer, String message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogColored(IntPtr serverPointer, String message);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern uint Server_Hash(IntPtr serverPointer, string hash);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern IntPtr Server_CreateVehicle(IntPtr serverPointer, uint model, Alt.Position pos, float heading);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_RemoveEntity(IntPtr serverPointer, IntPtr entityPointer);
        }
    }
}