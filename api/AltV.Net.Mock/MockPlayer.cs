using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockPlayer : Player
    {
        public MockPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
        }
    }
}