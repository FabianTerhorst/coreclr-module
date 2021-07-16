using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape.Tests
{
    public class MockPlayer : Player
    {
        public MockPlayer(IServer server):base(server, IntPtr.Zero, 0)
        {
            Exists = true;
        }
    }
}