using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Example;

namespace AltV.Net.Mock.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var mockAltV = new MockAltV<IPlayer, IMyVehicle, IBlip, ICheckpoint>("resource/AltV.Net.Example.dll");
            Alt.EmitAllClients("bla");
            var player = mockAltV.ConnectPlayer("bla", "direct connect");
            Console.WriteLine(player.DequeueEvent().Name);
            Alt.EmitAllClients("bla");
            Console.WriteLine(player.DequeueEvent().Name);
            player.Emit("bla2");
            Console.WriteLine(player.DequeueEvent().Name);
            player.Damage(null, 1, 10);
            player.Death(null, 1);
            player.Disconnect("disconnect");
        }
    }
}