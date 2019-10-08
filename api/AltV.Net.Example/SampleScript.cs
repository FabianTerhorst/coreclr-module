using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Example
{
    public class SampleScript : IScript
    {
        [Event("eventName")]
        public void MyEvent(IPlayer player)
        {
        }

        [Event]
        public void MyEventName(string message)
        {
            Console.WriteLine(message);
        }

        [Event("MyEventName")]
        public static void MyEventName2(string message)
        {
            Console.WriteLine(message);
        }

        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void MyPlayerConnect(IPlayer player, string reason)
        {
            player.Emit("connect_event");
            player.SetDateTime(DateTime.Now);
            player.Model = (uint) PedModel.FreemodeMale01;
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
    }
}