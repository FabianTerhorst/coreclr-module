using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Example;

namespace AltV.Net.Mock.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var mockAltV =
                new MockAltV<IPlayer, IMyVehicle, IPed, INetworkObject, IBlip, ICheckpoint, IVoiceChannel, IColShape, IVirtualEntity, IVirtualEntityGroup, IMarker, IConnectionInfo>("resource/AltV.Net.Example.dll");
            Alt.EmitAllClients("bla");
            var player = mockAltV.ConnectPlayer("bla", "direct connect", iPlayer =>
            {
                iPlayer.On("bla", objects => { });
                iPlayer.On((name, objects) => { });
            });
            Console.WriteLine(player.DequeueEvent().Name);
            Alt.EmitAllClients("bla");
            Console.WriteLine(player.DequeueEvent().Name);
            player.On("bla2", objects => { Alt.Log("ev:" + objects.Length); });
            player.Emit("bla2");
            Console.WriteLine(player.DequeueEvent().Name);
            player.Damage(null, 1, 10, 5);
            var checkpoint = Alt.CreateCheckpoint(1, Position.Zero, 10, 10, Rgba.Zero, 50);
            checkpoint.EntityExit(player);
            checkpoint.EntityExit(player);
            player.Death(null, 1);
            player.Disconnect("disconnect");
        }
    }
}