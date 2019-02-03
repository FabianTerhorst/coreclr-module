using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Entities;
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

            server.LogInfo("driver:" + vehicle.Driver);

            var function = new MValue.Function((ref MValue args, ref MValue result) =>
            {
                server.LogInfo("args:" + args.GetList().Length);
                result = MValue.Create("test7");
            });

            //var func = Function.Create<Func<string>>(MyFunction2);

            var func = Function.Create<Action<string, object[], int[], IVehicle[], IVehicle, Dictionary<string, IVehicle>>>(MyFunction2);
            func.Call(entityPool,
                MValue.Create(new[]
                {
                    MValue.Create("bla7"), MValue.Create(new[] {MValue.Create("bla2")}),
                    MValue.Create(new[] {MValue.Create(1337)}), MValue.Create(new[] {MValue.Create(vehicle)}),
                    MValue.Create(vehicle), MValue.Create(new[] {MValue.Create(vehicle)}, new[] {"key"})
                }));

            server.TriggerServerEvent("event_name", "param_string_1", "param_string_2", 1, new[] {"array_1", "array_2"},
                new object[] {"test", new[] {1337}}, vehicle,
                /*new Dictionary<string, object> {["test"] = "test", ["invoker"] = MValue.Create(MyFunction)},
                MValue.Create(MyFunction),*/ (MValue.Function) MyFunction, function,
                Function.Create<Func<bool, string, string>>(MyFunction3));


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
            var entityPointer = IntPtr.Zero;
            foreach (var mValue in values)
            {
                server.LogInfo("event value type: " + ((MValue.Type) mValue.type).ToString());
                switch (mValue.type)
                {
                    case MValue.Type.STRING:
                        server.LogInfo("event-value: " + mValue.GetString());
                        break;
                    case MValue.Type.BOOL:
                        server.LogInfo("event-value: " + mValue.GetBool());
                        break;
                    case MValue.Type.INT:
                        server.LogInfo("event-value: " + mValue.GetInt());
                        break;
                    case MValue.Type.UINT:
                        server.LogInfo("event-value: " + mValue.GetUint());
                        break;
                    case MValue.Type.DOUBLE:
                        server.LogInfo("event-value: " + mValue.GetDouble());
                        break;
                    case MValue.Type.LIST:

                        foreach (var currListmValue in mValue.GetList())
                        {
                            switch (currListmValue.type)
                            {
                                case MValue.Type.STRING:
                                    server.LogInfo("event-value: " + currListmValue.GetString());
                                    break;
                            }
                        }

                        break;
                    case MValue.Type.ENTITY:
                        mValue.GetEntityPointer(ref entityPointer);
                        if (entityPool.Get(entityPointer, out var entity))
                        {
                            server.LogInfo("entity type:" + entity.Type.ToString());
                        }

                        break;
                    case MValue.Type.DICT:
                        var dictionary = mValue.GetDictionary();
                        foreach (var (key, value) in dictionary)
                        {
                            server.LogInfo(key + " " + value.ToString());
                        }

                        break;
                    case MValue.Type.FUNCTION:
                        server.LogInfo("result:" + mValue.CallFunction(new[]
                                           {MValue.Create(true), MValue.Create("test_Arg")}));
                        break;
                }
            }
        }

        public static void MyFunction(ref MValue args, ref MValue result)
        {
            var values = args.GetList();
            server.LogInfo("called function with args:" + values.Length);
            foreach (var mValue in values)
            {
                server.LogInfo("arg: " + mValue.ToString());
            }

            result = MValue.Create("bla");
        }

        public static void MyFunction2(string text, object[] bla, int[] bla2, IVehicle[] vehicles, IVehicle vehicle, Dictionary<string, IVehicle> dictionary)
        {
            server.LogInfo("text=" + text);
            server.LogInfo("pos:" + vehicle.Position.x + " " + vehicle.Position.y + " " + vehicle.Position.z);
            server.LogInfo("key=" + dictionary["key"].Position.x + " " + dictionary["key"].Position.y + " " + dictionary["key"].Position.z);
            if (vehicles.Length == 0) return;
            server.LogInfo(
                "pos:" + vehicles[0].Position.x + " " + vehicles[0].Position.y + " " + vehicles[0].Position.z);
        }

        public static string MyFunction3(bool boolValue, string text)
        {
            server.LogInfo("text=" + text + " " + boolValue);
            return "test2";
        }
    }
}