using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Example
{
    public class SampleResource : AsyncResource
    {
        public override void OnStart()
        {
            Alt.On<string>("test", s => { Alt.Log("test=" + s); });
            Alt.OnServer("test", args => { Alt.Log("args=" + args[0]); });
            Alt.Emit("test", "bla");
            Alt.On("bla", bla);
            Alt.On<string>("bla2", bla2);
            Alt.On<string, bool>("bla3", bla3);
            Alt.On<string, string>("bla4", bla4);
            Alt.On<IMyVehicle>("vehicleTest", myVehicle => { Alt.Log("myData: " + myVehicle.MyData); });

            Alt.OnPlayerConnect += OnPlayerConnect;
            Alt.OnPlayerDisconnect += OnPlayerDisconnect;
            Alt.OnEntityRemove += OnEntityRemove;
            AltAsync.OnPlayerConnect += OnPlayerConnectAsync;
            Alt.OnPlayerEvent += (player, name, args) => { Alt.Log("event:" + name); };
            AltAsync.OnPlayerEvent += (player, name, args) =>
            {
                AltAsync.Log("event:" + name);
                return Task.CompletedTask;
            };
            AltAsync.On("bla", async args => { await AltAsync.Do(() => Alt.Log("bla with no args:" + args.Length)); });
            Alt.Emit("bla");

            var vehicle = Alt.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), float.MinValue);
            Alt.Log(vehicle.Position.ToString());
            vehicle.PrimaryColor = 7;
            vehicle.NumberPlateText = "AltV-C#";
            vehicle.NumberPlateIndex = 2;
            vehicle.SetMod(0, 0);
            vehicle.GetMod(0);
            vehicle.GetModsCount(0);
            vehicle.Dimension = 0;
            vehicle.LockState = VehicleLockState.Locked;
            vehicle.PrimaryColorRgb = new Rgba
            {
                r = 1,
                g = 8,
                b = 7,
                a = 0
            };

            Alt.Log("ptr:" + vehicle.NativePointer);

            Alt.Log("number-plate:" + vehicle.NumberPlateText + " " + vehicle.NumberPlateIndex);

            Alt.Emit("vehicleTest", vehicle);

            Alt.On("event_name",
                delegate(string s, string s1, long i1, string[] arg3, object[] arg4, IMyVehicle arg5,
                    Dictionary<string, object> arg6, IMyVehicle[] myVehicles, string probablyNull, string[] nullArray,
                    Dictionary<string, double> bla)
                {
                    Alt.Log("param1:" + s);
                    Alt.Log("param2:" + s1);
                    Alt.Log("bla:" + ((object[]) arg4[1])[0]);
                    Alt.Log("myData-2: " + arg5.Position.X + " " + arg5.MyData);
                    Alt.Log("myData-4-veh-array: " + myVehicles[0].Position.X + " " + myVehicles[0].MyData);
                    Alt.Log("myData-3: " + arg6["test"]);
                    Alt.Log("null?" + (probablyNull == null ? "y" : "n"));
                    Alt.Log("null2?" + (nullArray[0] == null ? "y" : "n"));
                    Alt.Log("bla2:" + bla["test"]);
                });

            Alt.On("entity-array-obj",
                delegate(object[] myVehicles)
                {
                    Alt.Log("entity-array-obj: " + ((MyVehicle) myVehicles[0]).Position.X + " " +
                            ((MyVehicle) myVehicles[0]).MyData);
                });

            AltAsync.On("event_name",
                async delegate(string s, string s1, long i1, string[] arg3, object[] arg4, IMyVehicle arg5,
                    Dictionary<string, object> arg6, IMyVehicle[] myVehicles, string probablyNull, string[] nullArray,
                    Dictionary<string, double> bla)
                {
                    await Task.Delay(500);
                    var asyncVehicle = await AltAsync.CreateVehicle(VehicleModel.Apc, Position.Zero, float.MaxValue);

                    AltAsync.Log("async-param1:" + s);
                    AltAsync.Log("async-param2:" + s1);
                    AltAsync.Log("async-bla:" + ((object[]) arg4[1])[0]);
                    AltAsync.Log("exists:" + arg5.Exists);
                    AltAsync.Log("async-myData-2: " + arg5.Position.X + " " + arg5.MyData);
                    AltAsync.Log("async-myData-4: " + myVehicles[0].Position.X + " " + myVehicles[0].MyData);
                    AltAsync.Log("async-myData-3: " + arg6["test"]);
                    AltAsync.Log("async-null?" + (probablyNull == null ? "y" : "n"));
                    AltAsync.Log("async-null2?" + (nullArray[0] == null ? "y" : "n"));
                    AltAsync.Log("async-bla2:" + bla["test"]);
                });

            Alt.Emit("event_name", "param_string_1", "param_string_2", 1, new[] {"array_1", "array_2"},
                new object[] {"test", new[] {1337}}, vehicle,
                new Dictionary<string, object>
                {
                    ["test"] = "test" //,
                    //["test2"] = new Dictionary<string, long> {["test"] = 1},
                    //["test3"] = new Dictionary<string, long> {["test"] = 42}
                },
                new IMyVehicle[] {(IMyVehicle) vehicle}, null, new string[] {null},
                new Dictionary<string, object>
                {
                    ["test"] = null
                });

            Alt.On<string[]>("test_string_array", s => { Alt.Log("string-array-entry-0:" + s[0]); });

            Alt.Emit("test_string_array", new object[] {new string[] {"bla"}});

            Alt.On("function_event", delegate(Function.Func func)
            {
                var result = func("parameter1");
                Alt.Log("result:" + result);
            });

            Alt.Emit("function_event", Function.Create(delegate(string bla)
            {
                Alt.Log("parameter=" + bla);
                return 42;
            }));

            foreach (var player in Alt.GetAllPlayers())
            {
            }

            foreach (var veh in Alt.GetAllVehicles())
            {
                Alt.Log("vehicle:" + veh.Position.X + " " + veh.Position.Y + " " + veh.Position.Z);
            }

            Alt.On("1337", delegate(int int1) { Alt.Log("int1:" + int1); });

            AltAsync.On("1337", delegate(int int1) { Alt.Log("int1:" + int1); });

            Alt.Emit("1337", 1);

            Alt.On<IMyVehicle>("MyServerEvent3", MyServerEventHandler2, MyServerEventParser3);

            Alt.On<IMyVehicle>("MyServerEvent3", MyServerEventHandlerAsync, MyServerEventParserAsync);

            Alt.Emit("MyServerEvent3", vehicle);

            Alt.Emit("entity-array-obj", new[] {new[] {vehicle}});

            vehicle.Remove();

            Bla();

            Alt.On<IPlayer, string>("MyEvent", MyEventHandler, MyParser);

            Alt.On<string>("MyServerEvent", MyServerEventHandler, MyServerEventParser);

            Alt.On<string>("MyServerEvent2", MyServerEventHandler, MyServerEventParser2);

            Alt.Emit("MyServerEvent", "test-custom-parser");

            Alt.Emit("MyServerEvent2", new object[] {new string[] {"test-custom-parser-array"}});

            dynamic dynamic = new ExpandoObject();

            Alt.Emit("dynamic_test", dynamic);

            Alt.Export("GetBla", () => { Alt.Log("GetBla called"); });

            /*if (Alt.Import("Bla", "GetBla", out Action value))
            {
                value();
            }*/

            Alt.Emit("none-existing-event", new WritableObject());

            Alt.Emit("none-existing-event", new ConvertibleObject());
        }

        public void MyParser(IPlayer player, ref MValueArray mValueArray, Action<IPlayer, string> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            var mValue = reader.GetNext();
            if (mValue.type != MValue.Type.STRING) return;
            func(player, mValue.GetString());
        }

        public void MyServerEventParser(ref MValueArray mValueArray, Action<string> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            if (!reader.GetNext(out string value)) return;
            func(value);
        }

        // Converts string array to string
        public void MyServerEventParser2(ref MValueArray mValueArray, Action<string> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            if (!reader.GetNext(out MValueArray array)) return;
            var valueReader = array.Reader();
            if (!valueReader.GetNext(out string value)) return;
            func(value);
        }

        public void MyServerEventParser3(ref MValueArray mValueArray, Action<IMyVehicle> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            if (!reader.GetNext(out IMyVehicle vehicle)) return;
            func(vehicle);
        }

        public void MyServerEventParserAsync(ref MValueArray mValueArray, Action<IMyVehicle> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            if (!reader.GetNext(out IMyVehicle vehicle)) return;
            Task.Run(() => func(vehicle));
        }

        public void MyParser4(IPlayer player, ref MValueArray mValueArray, Action<IPlayer, string> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            if (!reader.GetNext(out string value)) return;
            func(player, value);
        }

        public void MyParser5(IPlayer player, ref MValueArray mValueArray, Action<IPlayer, string[]> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            if (!reader.GetNext(out MValueArray values)) return;
            var strings = new string[values.Size];
            var valuesReader = values.Reader();
            var i = 0;
            while (valuesReader.GetNext(out string value))
            {
                strings[i++] = value;
            }

            func(player, strings);
        }

        public void MyParser6(IPlayer player, ref MValueArray mValueArray, Action<IPlayer, IMyVehicle> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
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
            await player.SetPositionAsync(new Position(1, 2, 3));
            var position = await player.GetPositionAsync();
            await AltAsync.Do(() => { });
            var vehicle = await AltAsync.Do(() =>
                Alt.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), float.MinValue));
        }

        public async void Bla()
        {
            var vehicle = await AltAsync.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), float.MinValue);
            var vehicle2 = await AltAsync.CreateVehicle(VehicleModel.Apc, new Position(1, 2, 3), float.MinValue);
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
            player.Emit("connect_event");
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

        private void OnEntityRemove(IBaseObject entity)
        {
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