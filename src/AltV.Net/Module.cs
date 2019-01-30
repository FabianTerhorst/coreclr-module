using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

namespace AltV.Net
{
    public static class Module
    {
        public static IntPtr server;

        public static void Main(IntPtr serverPointer)
        {
            server = serverPointer;
            Alt.Server.Server_LogInfo(serverPointer, "Hello from C#");
            uint hash = Alt.Server.Server_Hash(serverPointer, "adder");
            Alt.Server.Server_LogInfo(serverPointer, "hash:" + hash.ToString());
            Alt.Position position = new Alt.Position();
            position.x = 1;
            position.y = 2;
            position.z = 3;
            var vehiclePointer = Alt.Server.Server_CreateVehicle(serverPointer, hash, position, 1f);


            //var array = Alt.MValueArray.MValueArray_Create();

            //Alt.Server.Server_LogInfo(serverPointer, array.capacity.ToString() + " " + array.size.ToString());
            /* Alt.MValueArray.MValueArray_Push(array, new Alt.MValue {
                type = Alt.MValueType.NIL,
                storagePointer = IntPtr.Zero
            });*/

            //var mValue = Alt.MValueCreate.MValue_CreateString("test");
            //Alt.Server.Server_LogInfo(serverPointer, "1 " + mValue.type.ToString());
            //var mValue2 = Alt.MValueCreate.MValue_CreateNil();
            var mValue2 = new Alt.MValue
            {
                type = (byte)Alt.MValueType.NIL,
                storagePointer = IntPtr.Zero
            };
            Alt.Server.Server_LogInfo(serverPointer, "type:" + mValue2.type.ToString());
            Alt.Entity.Entity_SetMetaData(vehiclePointer, "test_key", ref mValue2);
            Alt.MValue mValue4 = Alt.MValue.Nil;
            Alt.Entity.Entity_GetMetaData(vehiclePointer, "test_key", ref mValue4);
            Alt.Server.Server_LogInfo(serverPointer, "3" + mValue4.type.ToString());

            Alt.Entity.Entity_GetPosition(vehiclePointer, ref position);
            Alt.Server.Server_LogInfo(serverPointer, position.x.ToString() + " " + position.y.ToString() + " " + position.z.ToString());
            var primaryColor = Alt.Vehicle.Vehicle_GetPrimaryColorRGB(vehiclePointer);
            Alt.Server.Server_LogInfo(serverPointer, primaryColor.a.ToString() + " " + primaryColor.r.ToString() + " " + primaryColor.g.ToString() + " " + primaryColor.b.ToString());
            var rotation = Alt.Rotation.Zero;
            Alt.Entity.Entity_GetRotation(vehiclePointer, ref rotation);
            Alt.Server.Server_LogInfo(serverPointer, rotation.roll.ToString() + " " + rotation.pitch.ToString() + " " + rotation.yaw.ToString());
            var position2 = new Alt.Position
            {
                x = 4,
                y = 5,
                z = 6
            };
            Alt.Entity.Entity_SetPosition(vehiclePointer, ref position2);
            Alt.Entity.Entity_GetPosition(vehiclePointer, ref position);
            Alt.Server.Server_LogInfo(serverPointer, position.x.ToString() + " " + position.y.ToString() + " " + position.z.ToString());
            Alt.Server.Server_RemoveEntity(serverPointer, vehiclePointer);
        }

        public static void OnPlayerConnect(IntPtr playerPointer, string reason)
        {

        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {

        }

        public static void OnEntityRemove(IntPtr entityPointer)
        {
            Alt.Server.Server_LogInfo(server, "entity remove");
        }
    }
}