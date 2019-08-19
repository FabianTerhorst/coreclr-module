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
            AltColShape.OnEntityEnterColShape = (o, shape) =>
            {
                if (shape.Id != 0) return;
                enter = true;
            };
            AltColShape.Create(0, 0, new Position(1, 1, 1), 50);
            Thread.Sleep(1000);
            Assert.True(enter);
            AltColShape.OnEntityExitColShape = (o, shape) =>
            {
                if (shape.Id != 0) return;
                enter = false;
            };
            lock (player)
            {
                player.Position = new Position(52, 1, 1);
            }

            Thread.Sleep(1000);
            Assert.False(enter);
            Assert.Pass();
        }
        
        [Test]
        public void PlayerEnterExitTest2()
        {
            var enter = false;
            AltColShape.OnEntityEnterColShape = (o, shape) =>
            {
                if (shape.Id != 1) return;
                enter = true;
            };
            AltColShape.Create(1, 0, new Position(452, 157, 731), 50);
            lock (player)
            {
                player.Position = new Position(452, 157, 731);
            }
            Thread.Sleep(1000);
            Assert.True(enter);
            AltColShape.OnEntityExitColShape = (o, shape) =>
            {
                if (shape.Id != 1) return;
                enter = false;
            };
            lock (player)
            {
                player.Position = new Position(1000, 1000, 1000);
            }

            Thread.Sleep(1000);
            Assert.False(enter);
            Assert.Pass();
        }
    }
}