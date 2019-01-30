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
            uint hash = Alt.Server.Server_Hash(serverPointer, "adder");
            Alt.Server.Server_LogInfo(serverPointer, "hash:" + hash.ToString());
            Alt.Position position = new Alt.Position();
            position.x = 1;
            position.y = 2;
            position.z = 3;
            var vehiclePointer = Alt.Server.Server_CreateVehicle(serverPointer, hash, position, 1f);
            position = Alt.Entity.Entity_GetPosition(vehiclePointer);
            Alt.Server.Server_LogInfo(serverPointer, position.x.ToString() + " " + position.y.ToString() + " " + position.z.ToString());
            var primaryColor = Alt.Vehicle.Vehicle_GetPrimaryColorRGB(vehiclePointer);
            Alt.Server.Server_LogInfo(serverPointer, primaryColor.a.ToString() + " " + primaryColor.r.ToString() + " " + primaryColor.g.ToString() + " " + primaryColor.b.ToString());
        }

        public static void OnPlayerConnect(IntPtr playerPointer, string reason)
        {

        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {

        }
    }
}