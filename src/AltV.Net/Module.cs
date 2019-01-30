using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

namespace AltV.Net
{
    public static class Module
    {
        public static void Main(IntPtr serverPointer)
        {
            Alt.Server.Server_LogInfo(serverPointer, "Hello from C#");
        }

        public static void OnPlayerConnect(IntPtr playerPointer, string reason)
        {

        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {

        }
    }
}