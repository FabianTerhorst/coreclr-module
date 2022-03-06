using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockPlayer : Player
    {
        public MockPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
        }
    }
}