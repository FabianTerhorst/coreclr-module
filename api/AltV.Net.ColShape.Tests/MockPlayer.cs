using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape.Tests
{
    public class MockPlayer : Player
    {
        public MockPlayer(ICore core):base(core, IntPtr.Zero, 0)
        {
            Exists = true;
        }
    }
}