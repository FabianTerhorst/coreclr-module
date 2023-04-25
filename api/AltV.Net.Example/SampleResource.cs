using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Enums;
using System.Drawing;
using AltV.Net.BenchmarkRunners;
using AltV.Net.Resources.Chat.Api;

namespace AltV.Net.Example
{
    public class SampleResource : AsyncResource
    {
        public override void OnStart()
        {
            //var benchmarkRunner = new BenchmarkRunner();
            //benchmarkRunner.Run();

            long currentTraceSize = 0;
            AltTrace.OnTraceFileSizeChange += size => { currentTraceSize = size; };

            Alt.OnConsoleCommand += (name, args) =>
            {
                Console.WriteLine("Command name: " + name);
                foreach (var arg in args)
                {
                    Console.WriteLine("arg:" + arg);
                }

                switch (name)
                {
                    case "trace_start":
                        if (args.Length != 1)
                        {
                            Console.WriteLine("trace_start {name}");
                            return;
                        }

                        AltTrace.Start(args[0]);
                        break;
                    case "trace_stop":
                        AltTrace.Stop();
                        break;
                    case "trace_size":
                        Console.WriteLine("trace file size: " + currentTraceSize + " bytes");
                        break;
                }
            };

            Alt.OnServer<object[]>("array_test", objects =>
            {
                Console.WriteLine("count:" + objects.Length);
                Console.WriteLine("1:" + objects[0]);
                Console.WriteLine("3:" + objects[1]);
                Console.WriteLine("2:" + ((object[])objects[2]).Length);
                Console.WriteLine("2:" + string.Join(",", objects[1]));
                Console.WriteLine("2:" + ((object[])objects[2])[0]);
            });
            Alt.Emit("array_test", new object[] { new object[] { "test", "test4", new[] { 1337 } } });
            Alt.OnServer<object[]>("array_test2", objects =>
            {
                Console.WriteLine("count2:" + objects.Length);
                Console.WriteLine("count3:" + ((object[])objects[0])[0]);
            });
            Alt.Emit("array_test2", new object[] { new object[] { new object[] { 1337 } } });


            var mValues = new MValueConst[1];
            var mInnerValues = new MValueConst[1];
            Alt.Core.CreateMValueInt(out mInnerValues[0], 5);
            Alt.Core.CreateMValueList(out mValues[0], mInnerValues, 1);
            Alt.Core.CreateMValueList(out var mValueList, mValues, 1);
            var mValuesListGet = mValueList.GetList();
            for (var i = 0; i < mValuesListGet.Length; i++)
            {
                Console.WriteLine("val: " + mValuesListGet[i]);
                mValuesListGet[i].Dispose();
            }

            Alt.RegisterMValueAdapter(new ConvertibleObject.ConvertibleObjectAdapter());
            Alt.OnServer("convertible_test", delegate(ConvertibleObject convertible)
            {
                Console.WriteLine("convertible_test received");
                Console.WriteLine(convertible.Test);
                foreach (var t in convertible.List)
                {
                    Console.WriteLine("-" + t.Test);
                }
            });
            var convertibleObject = new ConvertibleObject();
            /*var writer = new MValueWriter2();
            convertibleObject.GetAdapter().ToMValue(convertibleObject, writer);
            writer.ToMValue(out var mValueFromConvertible);
            foreach (var entry in  mValueFromConvertible.GetDictionary())
            {
                Console.WriteLine("key="+ entry.Key + " =" + entry.Value.type);
                entry.Value.Dispose();
            }*/

            //Console.WriteLine("obj:" + mValueFromConvertible.type + " " + mValueFromConvertible.nativePointer);
            //mValueFromConvertible.Dispose();
            Alt.Emit("convertible_test", convertibleObject);

            Alt.OnServer<string>("test", s => { Alt.Log("test=" + s); });
            //Alt.OnServer<object[]>("test", args => { Alt.Log("args=" + args[0]); });
            Alt.Emit("test", "bla");
            Alt.OnServer("bla", bla);
            Alt.OnServer<string>("bla2", bla2);
            Alt.OnServer<string, bool>("bla3", bla3);
            Alt.OnServer<string, string>("bla4", bla4);
            Alt.OnServer<IMyVehicle>("vehicleTest", myVehicle =>
            {
                Console.WriteLine("inside invoke");
                Alt.Log("myData: " + myVehicle?.MyData);
                Console.WriteLine("inside invoke2");
            });

            Console.WriteLine("vehicleTestDone");

            Alt.OnPlayerConnect += OnPlayerConnect;
            Alt.OnPlayerDisconnect += OnPlayerDisconnect;
            AltAsync.OnPlayerDisconnect += OnPlayerDisconnectAsync;
            AltAsync.OnPlayerConnect += OnPlayerConnectAsync;
            Alt.OnConsoleCommand += (name, args) => { };
            Alt.OnPlayerEvent += (player, name, args) => { Alt.Log("event:" + name); };
            AltAsync.OnPlayerEvent += (player, name, args) =>
            {
                AltAsync.Log("event:" + name);
                return Task.CompletedTask;
            };
            AltAsync.OnServer<object[]>("bla",
                async args => { await AltAsync.Do(() => Alt.Log("bla with no args:" + args.Length)); });
            Alt.Emit("bla");

            var blip = Alt.CreateBlip(BlipType.Area, Position.Zero);
            blip.Color = 1;

            var checkpoint = Alt.CreateCheckpoint(CheckpointType.Cyclinder, Position.Zero, 1f, 1f, Rgba.Zero, 50);
            Alt.Log(checkpoint.Color.ToString());

            var voiceChannel = Alt.CreateVoiceChannel(true, 10f);
            Alt.Log(voiceChannel.MaxDistance.ToString("R"));

            var vehicle = Alt.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), new Rotation(1, 2, 3));
            vehicle.SetSyncedMetaData("test", 123);
            Alt.Log(vehicle.Position.ToString());
            /*var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < int.MaxValue; i++)
            {
                vehicle.PrimaryColor = (i % 2 == 0) ? (byte) 1 : (byte) 0;
            }
            watch.Stop();
            var elapsedMs = watch.Elapsed;
            Console.WriteLine("primaryColor took " + elapsedMs);*/
            vehicle.NumberplateText = "AltV-C#";
            vehicle.NumberplateIndex = 2;
            vehicle.SetMod(0, 0);
            vehicle.GetMod(0);
            vehicle.GetModsCount(0);
            vehicle.Dimension = 0;
            vehicle.LockState = VehicleLockState.Locked;
            vehicle.PrimaryColorRgb = new Rgba
            {
                R = 1,
                G = 8,
                B = 7,
                A = 0
            };

            var (x, y, z) = vehicle.GetPosition();
            vehicle.SetPosition(1, 1, 1);
            vehicle.SetPosition((x, y, z));
            var tuple = vehicle.GetPosition();
            vehicle.SetPosition(tuple);


            Task.Factory.StartNew(() =>
                AltAsync.CreateVehicleBuilder(VehicleModel.Apc, new Position(1, 2, 3), new Rotation(1, 2, 3))
                    .PrimaryColorRgb(Color.GreenYellow)
                    .SecondaryColor(24)
                    .NumberplateText("C#")
                    .LockState(VehicleLockState.Locked)
                    .Build()
            );

            Alt.Log("ptr:" + vehicle.NativePointer);

            Alt.Log("number-plate:" + vehicle.NumberplateText + " " + vehicle.NumberplateIndex);

            Alt.Emit("vehicleTest", vehicle);

            Alt.OnServer("event_name",
                delegate(string s, string s1, long i1, string[] arg3, object[] arg4, IMyVehicle arg5,
                    Dictionary<string, object> arg6, IMyVehicle[] myVehicles, string probablyNull, string[] nullArray,
                    Dictionary<string, double> bla)
                {
                    Alt.Log("param1:" + s);
                    Alt.Log("param2:" + s1);
                    Alt.Log("bla:" + ((object[])arg4[1])[0]);
                    Alt.Log("myData-2: " + arg5.Position.X + " " + arg5.MyData);
                    Alt.Log("myData-4-veh-array: " + myVehicles[0].Position.X + " " + myVehicles[0].MyData);
                    Alt.Log("myData-3: " + arg6["test"]);
                    Alt.Log("null?" + (probablyNull == null ? "y" : "n"));
                    Alt.Log("null2?" + (nullArray[0] == null ? "y" : "n"));
                    Alt.Log("bla2:" + bla["test"]);
                });

            Alt.OnServer<object[]>("entity-array-obj",
                delegate(object[] myVehicles)
                {
                    Alt.Log("entity-array-obj: " + ((MyVehicle)myVehicles[0]).Position.X + " " +
                            ((MyVehicle)myVehicles[0]).MyData);
                });

            AltAsync.OnServer("event_name",
                async delegate(string s, string s1, long i1, string[] arg3, object[] arg4, IMyVehicle arg5,
                    Dictionary<string, object> arg6, IMyVehicle[] myVehicles, string probablyNull, string[] nullArray,
                    Dictionary<string, double> bla)
                {
                    await Task.Delay(500);
                    await AltAsync.CreateVehicle(VehicleModel.Apc, Position.Zero, new Rotation(1, 2, 3));

                    AltAsync.Log("async-param1:" + s);
                    AltAsync.Log("async-param2:" + s1);
                    AltAsync.Log("async-bla:" + ((object[])arg4[1])[0]);
                    AltAsync.Log("exists:" + arg5.Exists);
                    AltAsync.Log("async-myData-2: " + arg5.Position.X + " " + arg5.MyData);
                    AltAsync.Log("async-myData-4: " + myVehicles[0].Position.X + " " + myVehicles[0].MyData);
                    AltAsync.Log("async-myData-3: " + arg6["test"]);
                    AltAsync.Log("async-null?" + (probablyNull == null ? "y" : "n"));
                    AltAsync.Log("async-null2?" + (nullArray[0] == null ? "y" : "n"));
                    AltAsync.Log("async-bla2:" + bla["test"]);
                });

            Alt.Emit("event_name", "param_string_1", "param_string_2", 1, new[] { "array_1", "array_2" },
                new object[] { "test", new[] { 1337 } }, vehicle,
                new Dictionary<string, object>
                {
                    ["test"] = "test" //,
                    //["test2"] = new Dictionary<string, long> {["test"] = 1},
                    //["test3"] = new Dictionary<string, long> {["test"] = 42}
                },
                new[] { (IMyVehicle)vehicle }, null, new string[] { null },
                new Dictionary<string, object>
                {
                    ["test"] = null
                });

            Alt.OnServer<string[]>("test_string_array", s => { Alt.Log("string-array-entry-0:" + s[0]); });

            Alt.Emit("test_string_array", new object[] { new[] { "bla" } });

            Alt.OnServer("function_event", delegate(Function.Func func)
            {
                var result = func("parameter1");
                Alt.Log("result:" + result);
            });

            Alt.Emit("function_event", Function.Create(Alt.Core, delegate(string bla)
            {
                Console.WriteLine(bla + " " + (bla == null));
                Alt.Log("parameter=" + bla);
                return 42;
            }));

            Alt.OnServer("function_event_action", delegate(Function.Func func)
            {
                var result = func("parameter1");
                Alt.Log("result:" + result);
            });

            Alt.Emit("function_event_action", Function.Create(Alt.Core, delegate(string bla)
            {
                Console.WriteLine(bla + " " + (bla == null));
                Alt.Log("parameter=" + bla);
            }));

            foreach (var pl in Alt.GetAllPlayers())
            {
                Alt.Log("player:" + pl.Position.X + " " + pl.Position.Y + " " + pl.Position.Z);
            }

            foreach (var veh in Alt.GetAllVehicles())
            {
                Alt.Log("vehicle:" + veh.Position.X + " " + veh.Position.Y + " " + veh.Position.Z);
            }

            Alt.OnServer("1337", delegate(int int1) { Alt.Log("int1:" + int1); });

            AltAsync.OnServer("1337", delegate(int int1) { Alt.Log("int1:" + int1); });

            Alt.Emit("1337", 1);

            Alt.OnServer<IMyVehicle>("MyServerEvent3", MyServerEventHandler2, MyServerEventParser3);

            Alt.OnServer<IMyVehicle>("MyServerEvent3", MyServerEventHandlerAsync, MyServerEventParserAsync);

            Alt.Emit("MyServerEvent3", vehicle);

            Alt.Emit("entity-array-obj", new object[] { new[] { vehicle } });

            Bla();

            Alt.OnClient<IPlayer, string>("MyEvent", MyEventHandler, MyParser);

            Alt.OnServer<string>("MyServerEvent", MyServerEventHandler, MyServerEventParser);

            Alt.OnServer<string>("MyServerEvent2", MyServerEventHandler, MyServerEventParser2);

            Alt.Emit("MyServerEvent", "test-custom-parser");

            Alt.Emit("MyServerEvent2", new object[] { new[] { "test-custom-parser-array" } });

            //dynamic dynamic = new ExpandoObject();

            //Alt.Emit("dynamic_test", dynamic);

            Alt.Export("GetBla", () => { Alt.Log("GetBla called"); });

            Alt.Import(Alt.Core.Resource.Name, "GetBla", out Action action);

            action();

            Alt.Export("functionExport", delegate(string name) { Alt.Log("called with:" + name); });

            Alt.Import(Alt.Core.Resource.Name, "functionExport", out Action<string> action2);

            action2("123");
            /*if (Alt.Import("Bla", "GetBla", out Action value))
            {
                value();
            }*/

            Alt.Emit("none-existing-event", new WritableObject());

            Alt.Emit("none-existing-event", new ConvertibleObject());

            // You need to catch this with a exception because its not possible to construct a invalid entity
            // Remember not all vehicles you receive from events has to be constructed by this constructor when there got created from different resources ect.
            // But when you don't use a entity factory you can validate that by checking if the ivehicle is a imyvehicle
            try
            {
                IMyVehicle unused =
                    new MyVehicle((uint)VehicleModel.Apc, new Position(1, 1, 1), new Rotation(1, 1, 1));
            }
            catch (BaseObjectRemovedException)
            {
            }

            Alt.RegisterEvents(this);

            Alt.Emit("bla2", "bla");

            AltAsync.RegisterEvents(this);

            Alt.Emit("asyncBla3", "bla");

            Alt.OnColShape += (shape, entity, state) =>
            {
                Console.WriteLine("collision shape test:" + shape + " " + shape.GetData("bla", out int id1) + " " +
                                  id1);
                Console.WriteLine(" " + shape + " " + shape.GetMetaData("bla", out long id2) + " " + id2 + " " +
                                  entity + " " + state);
            };

            var colShapeCylinder = Alt.CreateColShapeCylinder(new Position(1337, 1337, 1337), 10, 10);
            colShapeCylinder.SetMetaData("bla", 1);
            colShapeCylinder.SetData("bla", 2);

            var colShapeCircle = Alt.CreateColShapeCircle(new Position(1337, 1337, 1337), 10);
            colShapeCircle.SetMetaData("bla", 3);
            colShapeCircle.SetData("bla", 4);

            AltChat.SendBroadcast("Test");

            var vehicle2 = Alt.CreateVehicle(VehicleModel.Adder, new Position(1337, 1337, 1337), Rotation.Zero);
            Alt.OnServer<IVehicle, VehicleModel>("onEnum", OnEnum);
            Alt.Emit("onEnum", vehicle2, VehicleModel.Adder.ToString());

            Alt.OnServer("EmptyParams", TestEmptyParams);
            Alt.Emit("EmptyParams", 1, 2, 3);

            Alt.Emit("chat:message", "/dynamicArgs2 7");

            Alt.Emit("chat:message", "/dynamicArgs2 7 5 test");

            Alt.Emit("chat:message", "bla");
            Alt.Emit("chat:message", "/bla");
            Alt.Emit("chat:message", "/bla 5");
            Alt.Emit("chat:message", "/bla2 3223");
            Alt.Emit("chat:message", "/bla3 3535");
            Alt.Emit("chat:message", "/invalidCommand");
            Alt.Emit("chat:message", "/invalidCommand 3535");
            Alt.Emit("chat:message", "/defaultParamsCommand test");
            Alt.Emit("chat:message", "/defaultParamsCommand test 5");
            Alt.Emit("chat:message", "/defaultParamsCommand test 6 3");
            Alt.Emit("chat:message", "/defaultParamsCommand2 test 6 3");

            Alt.Emit("chat:message", "/bladyn 6");
            Alt.Emit("chat:message", "/bladyn 6 test");
            Alt.Emit("chat:message", "/bladyn 6 test test2");
            Alt.Emit("chat:message", "/bladyn 6 test test2 test3");

            Alt.OnServer<int, object[]>("onOptionalAndParamArray", OnOptionalAndParamArray);

            Alt.Emit("onOptionalAndParamArray", 5, 42, "test");

            Alt.CreateCheckpoint(CheckpointType.Cyclinder, Position.Zero, 50f, 50f, Rgba.Zero, 50);

            var vehicle5 = Alt.CreateVehicle(VehicleModel.Adder, Position.Zero, Rotation.Zero);

            Alt.Emit("eventNameWithEntity", null, vehicle5);
        }

        public static void OnOptionalAndParamArray(int test, params object[] args)
        {
            Console.WriteLine(
                $"Event<OnOptionalAndParamArray>({test}, [{string.Join(',', Array.ConvertAll(args ?? new object[] { "" }, el => el.ToString()))}])");
        }

        public static void TestEmptyParams()
        {
            Alt.Log("Empty params");
        }

        public static void OnEnum(IVehicle vehicle, VehicleModel vehicleModel)
        {
            Console.WriteLine("vehicle:" + vehicle.Id);
            Console.WriteLine("vehicle-model:" + vehicleModel);
        }

        [ServerEvent("bla2")]
        public void MyServerEventHandler2(string myString)
        {
            Alt.Log(myString);
        }

        [AsyncServerEvent]
        public void asyncBla3(string myString)
        {
            AltAsync.Log(myString);
        }

        public void MyParser(IPlayer player, MValueConst[] mValueArray, Action<IPlayer, string> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray); // todo move to Alt.CreateMValueBuffer
            reader.GetNext(out MValueConst mValueConst);
            if (mValueConst.type != MValueConst.Type.String) return;
            func(player, mValueConst.GetString());
        }

        public void MyServerEventParser(MValueConst[] mValueArray, Action<string> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray);
            if (!reader.GetNext(out string value)) return;
            func(value);
        }

        // Converts string array to string
        public void MyServerEventParser2(MValueConst[] mValueArray, Action<string> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray);
            if (!reader.GetNext(out MValueConst[] array)) return;
            var valueReader = new MValueBuffer2(Alt.Core, array);
            if (!valueReader.GetNext(out string value)) return;
            func(value);
        }

        public void MyServerEventParser3(MValueConst[] mValueArray, Action<IMyVehicle> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray);
            if (!reader.GetNext(out IMyVehicle vehicle)) return;
            func(vehicle);
        }

        public void MyServerEventParserAsync(MValueConst[] mValueArray, Action<IMyVehicle> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray);
            if (!reader.GetNext(out IMyVehicle vehicle)) return;
            Task.Run(() => func(vehicle));
        }

        public void MyParser4(IPlayer player, MValueConst[] mValueArray, Action<IPlayer, string> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray);
            if (!reader.GetNext(out string value)) return;
            func(player, value);
        }

        public void MyParser5(IPlayer player, MValueConst[] mValueArray, Action<IPlayer, string[]> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray);
            if (!reader.GetNext(out MValueConst[] values)) return;
            var strings = new string[values.Length];
            var valuesReader = new MValueBuffer2(Alt.Core, values);
            var i = 0;
            while (valuesReader.GetNext(out string value))
            {
                strings[i++] = value;
            }

            func(player, strings);
        }

        public void MyParser6(IPlayer player, MValueConst[] mValueArray, Action<IPlayer, IMyVehicle> func)
        {
            if (mValueArray.Length != 1) return;
            var reader = new MValueBuffer2(Alt.Core, mValueArray);
            if (!reader.GetNext(out IMyVehicle vehicle)) return;
            func(player, vehicle);
        }

        public void MyEventHandler(IPlayer player, string myString)
        {
            Alt.Log(myString);
        }

        public void MyServerEventHandler(string myString)
        {
            Alt.Log(myString);
        }

        public void MyServerEventHandler2(IMyVehicle vehicle)
        {
            Alt.Log("data-custom-parser: " + vehicle.MyData);
        }

        public async void MyServerEventHandlerAsync(IMyVehicle vehicle)
        {
            await Task.Delay(100);
            AltAsync.Log("data-custom-parser: " + vehicle.MyData);
        }

        //AltAsync.OnPlayerEvent += OnPlayerEvent;
        //...

        /*class EventHandler
        {
            //...
            public void Call(IPlayer player, object[] args)
            {
                //...
            }
        }

        private EventHandler[] eventHandlers = new EventHandler[42];

        public async Task OnPlayerEvent(IPlayer player, string eventName, object[] args)
        {
            var number = FastStringToInt(eventName);
            if (eventHandlers.Length < number)
            {
                eventHandlers[number].Call(player, args);
            }
        }

        private static int FastStringToInt(string eventName)
        {
            var y = 0;
            for (var i = 0; i < eventName.Length; i++)
                y = y * 10 + (eventName[i] - '0');
            return y;
        }*/

        public async void Bla2(IPlayer player)
        {
            player.Position = Position.Zero;
            player.Rotation = Rotation.Zero;

            await player.SetPositionAsync(new Position(1, 2, 3));
            var unused = await player.GetPositionAsync();
            await AltAsync.Do(() => { });
            var unused2 = await AltAsync.Do(() =>
                Alt.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), new Rotation(1, 2, 3)));
        }

        public async void Bla()
        {
            var vehicle = await AltAsync.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), new Rotation(1, 2, 3));
            var vehicle2 = await AltAsync.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), new Rotation(1, 2, 3));
            Alt.Log("veh:" + vehicle.Position.X + " " + vehicle2.Position.X);
        }

        public override void OnStop()
        {
        }

        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new MyVehicleFactory();
        }

        private void OnPlayerConnect(IPlayer player, string reason)
        {
            var myCustomPlayer = (MyPlayer)player;
            player.Emit("connect_event");
            player.SetDateTime(DateTime.Now);
            player.Model = (uint)PedModel.FreemodeMale01;
        }

        private async Task OnPlayerConnectAsync(IPlayer player, string reason)
        {
            await player.EmitAsync("bla");
        }

        private void OnPlayerDisconnect(IPlayer player, string reason)
        {
            //var readOnlyPlayer = player.Copy();
            //Do async processing here with the copy even when player got already removed
        }

        private async Task<int> OnPlayerDisconnectAsync(IPlayer player, string reason)
        {
            if (player is IMyPlayer unused3)
            {
            }

            await Task.Delay(1000);

            return 42;
        }

        public void bla()
        {
        }

        public void bla2(string test)
        {
        }

        public bool bla3(string test)
        {
            return true;
        }

        public void bla4(string test, string test2)
        {
        }
    }
}