using System.Collections.Generic;
using System.Threading;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using NUnit.Framework;

namespace AltV.Net.ColShape.Tests
{
    public class Tests
    {
        private List<IPlayer> players;

        private IPlayer player;

        [SetUp]
        public void Setup()
        {
            player = new MockPlayer {Position = new Position(1, 1, 1)};
            players = new List<IPlayer> {player};
            AltColShape.Init(new MockColShapeModule(new MockPlayerPool(players), new MockVehiclePool()));
        }

        [Test]
        public void PlayerEnterExitTest()
        {
            var enter = false;
            AltColShape.OnEntityEnterColShape = (o, shape) => { enter = true; };
            AltColShape.Create(0, 0, new Position(1, 1, 1), 50);
            Thread.Sleep(1000);
            Assert.True(enter);
            AltColShape.OnEntityExitColShape = (o, shape) => { enter = false; };
            player.Position = new Position(52, 1, 1);
            Thread.Sleep(1000);
            Assert.False(enter);
            Assert.Pass();
        }
    }
}