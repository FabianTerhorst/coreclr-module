using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

namespace AltV.Net
{
    public static class Module
    {
        private static Server server;

        public static void Main(IntPtr serverPointer)
        {
            server = new Server(serverPointer);

            server.TriggerServerEvent("bla", "bla", "1337", 187);

            /*Alt.Server.Server_LogInfo(serverPointer, "Hello from C#");
            var hash = Alt.Server.Server_Hash(serverPointer, "adder");
            Alt.Server.Server_LogInfo(serverPointer, "hash:" + hash);
            var position = new Position {x = 1, y = 2, z = 3};
            var vehiclePointer = Alt.Server.Server_CreateVehicle(serverPointer, hash, position, 1f);

            Alt.Vehicle.Vehicle_SetNumberPlateText(vehiclePointer, "AltV-C#");
            var numberPlateText = Alt.StringView.Empty;
            Alt.Vehicle.Vehicle_GetNumberPlateText(vehiclePointer, ref numberPlateText);
            Alt.Server.Server_LogInfo(serverPointer, numberPlateText.Text);
            var mValue2 = new Alt.MValue
            {
                type = (byte) Alt.MValueType.NIL,
                storagePointer = IntPtr.Zero
            };
            Alt.Server.Server_LogInfo(serverPointer, "type:" + mValue2.type);
            Alt.Entity.Entity_SetMetaData(vehiclePointer, "test_key", ref mValue2);
            var mValue4 = Alt.MValue.Nil;
            Alt.Entity.Entity_GetMetaData(vehiclePointer, "test_key", ref mValue4);
            Alt.Server.Server_LogInfo(serverPointer, "3" + mValue4.type);

            Alt.Entity.Entity_GetPosition(vehiclePointer, ref position);
            Alt.Server.Server_LogInfo(serverPointer, position.x + " " + position.y + " " + position.z);
            var primaryColor = Alt.Vehicle.Vehicle_GetPrimaryColorRGB(vehiclePointer);
            Alt.Server.Server_LogInfo(serverPointer,
                primaryColor.a + " " + primaryColor.r + " " + primaryColor.g + " " + primaryColor.b);
            var rotation = Rotation.Zero;
            Alt.Entity.Entity_GetRotation(vehiclePointer, ref rotation);
            Alt.Server.Server_LogInfo(serverPointer, rotation.roll + " " + rotation.pitch + " " + rotation.yaw);
            var position2 = new Position
            {
                x = 4,
                y = 5,
                z = 6
            };
            Alt.Entity.Entity_SetPosition(vehiclePointer, ref position2);
            Alt.Entity.Entity_GetPosition(vehiclePointer, ref position);
            Alt.Server.Server_LogInfo(serverPointer, position.x + " " + position.y + " " + position.z);
            Alt.Server.Server_RemoveEntity(serverPointer, vehiclePointer);*/
        }

        public static void OnPlayerConnect(IntPtr playerPointer, string reason)
        {
        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
        }

        public static void OnEntityRemove(IntPtr entityPointer)
        {
            server.LogInfo("entity remove");
        }

        public static void OnServerEvent(string name, ref MValueArray args)
        {
            var values = args.ToArray();

            server.LogInfo("server event " + name + " " + args.size);
            var value = MValue.Nil;
            foreach (var mValue in values)
            {
                value = mValue;
                server.LogInfo("event value type: " + ((MValue.Type) mValue.type).ToString());
                switch (mValue.type)
                {
                    case MValue.Type.STRING:
                        var stringValue = string.Empty;
                        Alt.MValueGet.MValue_GetString(ref value, ref stringValue);
                        server.LogInfo("event-value: " + stringValue);
                        break;
                    case MValue.Type.BOOL:
                        server.LogInfo("event-value: " + Alt.MValueGet.MValue_GetBool(ref value));
                        break;
                    case MValue.Type.INT:
                        server.LogInfo("event-value: " + Alt.MValueGet.MValue_GetInt(ref value));
                        break;
                    case MValue.Type.UINT:
                        server.LogInfo("event-value: " + Alt.MValueGet.MValue_GetUInt(ref value));
                        break;
                    case MValue.Type.DOUBLE:
                        server.LogInfo("event-value: " + Alt.MValueGet.MValue_GetDouble(ref value));
                        break;
                }
            }
        }

        public static ref MValue Bla(MValue args)
        {
            server.LogInfo("called function");
            return ref MValue.Nil;
        }
    }
}