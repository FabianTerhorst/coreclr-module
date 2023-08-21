using System;
using System.Threading.Tasks;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;

namespace AltV.Net.Example
{
    public class SampleScript : IScript
    {
        [AsyncScriptEvent(ScriptEventType.Checkpoint)]
        public async Task Checkpoint(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            await Task.Delay(100);
            Console.WriteLine("checkpoint event");
        }

        [AsyncScriptEvent(ScriptEventType.ColShape)]
        public async Task ColShape(IColShape checkpoint, IEntity entity, bool state)
        {
            await Task.Delay(100);
            Console.WriteLine("colshape event");
        }

        [Command]
        public void MyCommand(IPlayer player, string myArgument)
        {
        }

        [Command("bla")]
        public void MyCommand2(IPlayer player, int? myArgument)
        {
            Console.WriteLine("bla with arg:" + myArgument);
        }

        [Command("bladyn")]
        public void MyCommand(IPlayer player, int myArgument, params string[] message)
        {
            Console.WriteLine("bladync with arg:" + myArgument + string.Join(" ", message));
        }

        [Command("bla", true, new[] { "bla2", "bla3" })]
        public void MyCommand2(IPlayer player, string myArgument)
        {
            Console.WriteLine("bla with greedy arg:" + myArgument);
        }

        [CommandEvent(CommandEventType.CommandNotFound)]
        public void MyCommandNotFoundHandler(IPlayer player, string command)
        {
            Console.WriteLine("Command not found:" + command);
        }

        [Command("dynamicArgs")]
        public void MyCommandWithDynamicArgs(IPlayer player, int arg1, int arg2, params string[] args)
        {
            Console.WriteLine("Command:" + arg1 + " " + arg2 + " remaining args " + string.Join(",", args));
        }

        [Command("dynamicArgs2")]
        public void MyCommandWithDynamicArgs2(IPlayer player, int arg1, int? arg2, params string[] args)
        {
            Console.WriteLine("Command:" + arg1 + " " + arg2 + " remaining args " + string.Join(",", args));
        }

        [Command("defaultParamsCommand", aliases: new[] { "defaultParamsCommand2" })]
        public void DefaultParamsCommand(IPlayer player, string test, int arg1 = 1, int arg2 = 2)
        {
            Console.WriteLine("Command:" + test + " " + arg1 + " " + arg2);
        }

        [ServerEvent("eventName")]
        public void MyEvent(IPlayer player)
        {
        }

        [ServerEvent("eventNameWithEntity")]
        public void MyEvent2(IPlayer player, IEntity entity)
        {
            Console.WriteLine("eventNameWithEntity:" + entity.Id + " " + (player == null));
        }

        [ServerEvent]
        public void MyEventName(string message)
        {
            Console.WriteLine(message);
        }

        /*[Event("MyEventName")]
        public static void MyEventName2(string message)
        {
            Console.WriteLine(message);
        }*/

        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void MyPlayerConnect(IPlayer player, string reason)
        {
            player.Emit("connect_event");
            player.SetDateTime(DateTime.Now);
            player.Model = (uint)PedModel.FreemodeMale01;
        }

        [ScriptEvent(ScriptEventType.ServerEvent)]
        public void MyServerEvent(string eventName, object[] args)
        {
            Console.WriteLine(eventName + ": " + string.Join(",", args));
        }

        [ScriptEvent(ScriptEventType.VehicleRemove)]
        public void VehicleRemove(IVehicle vehicle)
        {
            Console.WriteLine("vehicle removed: " + vehicle);
        }

        [ScriptEvent(ScriptEventType.VehicleRemove)]
        public void VehicleRemove2(IMyVehicle vehicle)
        {
            Console.WriteLine("vehicle removed2: " + vehicle?.MyData);
        }

        [ScriptEvent(ScriptEventType.VehicleRemove)]
        public void VehicleRemove3(MyVehicle vehicle)
        {
            Console.WriteLine("vehicle removed3: " + vehicle);
        }

        [ScriptEvent(ScriptEventType.VehicleRemove)]
        public void VehicleRemoveInvalidMethodSignature(MyPlayer player)
        {
            Console.WriteLine("vehicle removed invalid: " + player);
        }

        [ScriptEvent(ScriptEventType.VehicleRemove)]
        public void VehicleRemoveInvalidMethodSignature2(IMyInvalidVehicle vehicle)
        {
            Console.WriteLine("vehicle removed invalid2: " + vehicle);
        }

        [AsyncScriptEvent(ScriptEventType.VehicleRemove)]
        public Task VehicleRemove2Async(IMyVehicle vehicle)
        {
            Console.WriteLine("vehicle removed2 async: " + vehicle?.MyData);
            return Task.CompletedTask;
        }
    }
}