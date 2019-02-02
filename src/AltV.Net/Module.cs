using System;
using System.Collections.Generic;
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

        private static IEntityPool entityPool;

        public static void Main(IntPtr serverPointer)
        {
            entityPool = new EntityPool();
            server = new Server(serverPointer, entityPool);

            var vehicle = server.CreateVehicle(server.Hash("adder"), new Position(1, 2, 3), 1f);

            server.TriggerServerEvent("event_name", "param_string_1", "param_string_2", 1, new[] {"array_1", "array_2"},
                new object[] {"test", new[] {1337}}, vehicle, new Dictionary<string, object> {["test"] = "test"});


            /*var dictMValue = MValue.Nil;
            
            var values = new []{MValue.Create(true)};

            var stringView = StringView.Empty;

            Alt.MValueCreate.String_Create("test", ref stringView);
            
            var keys = new [] {stringView};
            
            Alt.MValueCreate.MValue_CreateDict(values, keys, (ulong) values.Length, ref dictMValue);*/

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
            var valueList = MValueArray.Nil;
            var stringViewArray = StringViewArray.Nil;
            var stringValue = string.Empty;
            var entityPointer = IntPtr.Zero;
            foreach (var mValue in values)
            {
                value = mValue;
                server.LogInfo("event value type: " + ((MValue.Type) mValue.type).ToString());
                switch (mValue.type)
                {
                    case MValue.Type.STRING:
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
                    case MValue.Type.LIST:
                        Alt.MValueGet.MValue_GetList(ref value, ref valueList);
                        var mValues = valueList.ToArray();

                        foreach (var currListmValue in mValues)
                        {
                            value = currListmValue;
                            switch (currListmValue.type)
                            {
                                case MValue.Type.STRING:
                                    Alt.MValueGet.MValue_GetString(ref value, ref stringValue);
                                    server.LogInfo("event-value: " + stringValue);
                                    break;
                            }
                        }

                        server.LogInfo("event-value: " + mValues.Length);
                        break;
                    case MValue.Type.ENTITY:
                        server.LogInfo("event-entity-type:" + mValue.type);
                        Alt.MValueGet.MValue_GetEntity(ref value, ref entityPointer);
                        if (entityPool.Get(entityPointer, out var entity))
                        {
                            server.LogInfo("entity type:" + entity.Type.ToString());
                        }

                        break;
                    case MValue.Type.DICT:
                        server.LogInfo("event-type-dict: " + mValue.type);
                        Alt.MValueGet.MValue_GetDict(ref value, ref stringViewArray, ref valueList);
                        var mValues2 = valueList.ToArray();
                        server.LogInfo("value-size:" + mValues2.Length);

                        foreach (var currListmValue in mValues2)
                        {
                            value = currListmValue;
                            switch (currListmValue.type)
                            {
                                case MValue.Type.STRING:
                                    Alt.MValueGet.MValue_GetString(ref value, ref stringValue);
                                    server.LogInfo("value: " + stringValue);
                                    break;
                            }
                            server.LogInfo("dict-value-type:" + value.type);
                        }

                        var mStringValues = stringViewArray.ToArray();
                        server.LogInfo("key-size:" + mValues2.Length);
                        foreach (var currListmValue in mStringValues)
                        {
                            server.LogInfo("key: " + currListmValue.Text);
                        }

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