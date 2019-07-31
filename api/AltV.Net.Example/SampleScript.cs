using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Example
{
    public class SampleScript : IScript
    {
        public SampleScript()
        {
            Alt.OnPlayerConnect += MyPlayerConnect;
        }

        [Event("eventName")]
        public void MyEvent(IPlayer player)
        {
        }

        [Event]
        public void MyEventName(string message)
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
    }
}