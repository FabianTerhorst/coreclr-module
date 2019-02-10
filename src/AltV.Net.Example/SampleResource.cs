using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Example
{
    public class SampleResource : IResource
    {
        public void OnStart()
        {
            Alt.On<string>("test", s => { Alt.Log("test=" + s); });
            Alt.On("test", args => { Alt.Log("args=" + args[0]); });
            Alt.Emit("test", "bla");
            Alt.On("bla", bla);
            Alt.On<string>("bla2", bla2);
            Alt.On<string, bool>("bla3", bla3);
            Alt.On<string, string>("bla4", bla4);
            Alt.On<MyVehicle>("vehicleTest", myVehicle => { Alt.Server.LogInfo("myData: " + myVehicle.MyData); });

            Alt.OnPlayerConnect += OnPlayerConnect;
            Alt.OnPlayerDisconnect += OnPlayerDisconnect;
            Alt.OnEntityRemove += OnEntityRemove;

            var vehicle = Alt.CreateVehicle(VehicleHash.Apc, new Position(1, 2, 3), float.MinValue);
            Alt.Server.LogInfo(vehicle.Position.ToString());
            vehicle.PrimaryColor = 7;
            vehicle.NumberPlateText = "AltV-C#";
            vehicle.NumberPlateIndex = 2;
            vehicle.SetMod(0, 0);
            vehicle.GetMod(0);
            vehicle.GetModsCount(0);
            vehicle.GetModKitsCount();
            vehicle.PrimaryColorRgb = new Rgba
            {
                r = 1,
                g = 8,
                b = 7,
                a = 0
            };

            Alt.Log("number-plate:" + vehicle.NumberPlateText + " " + vehicle.NumberPlateIndex);

            var bla200 = MValue.Create(vehicle);
            //var veh2 = bla2.ToObject();
            Alt.Log(bla200.ToString());

            Alt.Emit("vehicleTest", vehicle);

            Alt.On("event_name",
                delegate(string s, string s1, long i1, string[] arg3, object[] arg4, MyVehicle arg5,
                    Dictionary<string, object> arg6, IMyVehicle[] myVehicles, string probablyNull, string[] nullArray,
                    Dictionary<string, double> bla)
                {
                    Alt.Server.LogInfo("param1:" + s);
                    Alt.Server.LogInfo("param2:" + s1);
                    Alt.Server.LogInfo("bla:" + ((object[]) arg4[1])[0]);
                    Alt.Server.LogInfo("myData-2: " + arg5.Position.x + " " + arg5.MyData);
                    Alt.Server.LogInfo("myData-4: " + myVehicles[0].Position.x + " " + myVehicles[0].MyData);
                    Alt.Server.LogInfo("myData-3: " + arg6["test"]);
                    Alt.Server.LogInfo("null?" + (probablyNull == null ? "y" : "n"));
                    Alt.Server.LogInfo("null2?" + (nullArray[0] == null ? "y" : "n"));
                    Alt.Server.LogInfo("bla2:" + bla["test"]);
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

            Alt.On("function_event", delegate(Function.Func func)
            {
                var result = func("parameter1");
                Alt.Server.LogInfo("result:" + result);
            });

            Alt.Emit("function_event", Function.Create(delegate(string bla)
            {
                Alt.Server.LogInfo("parameter=" + bla);
                return 42;
            }));

            foreach (var player in Alt.GetAllPlayers())
            {
            }

            foreach (var veh in Alt.GetAllVehicles())
            {
                Alt.Log("vehicle:" + veh.Position.x + " " + veh.Position.y + " " + veh.Position.z);
            }

            vehicle.Remove();
        }

        public void OnStop()
        {
        }

        public IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new PlayerFactory();
        }

        public IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new MyVehicleFactory();
        }

        public IEntityFactory<IBlip> GetBlipFactory()
        {
            return new BlipFactory();
        }

        public IEntityFactory<ICheckpoint> GetCheckpointFactory()
        {
            return new CheckpointFactory();
        }

        private void OnPlayerConnect(IPlayer player, string reason)
        {
            player.Emit("bla");
        }

        private void OnPlayerDisconnect(IPlayer player, string reason)
        {
            var readOnlyPlayer = player.Copy();
            //Do async processing here even when player got already removed
        }

        private void OnEntityRemove(IEntity entity)
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