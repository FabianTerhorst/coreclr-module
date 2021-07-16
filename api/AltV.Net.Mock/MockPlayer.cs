using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockPlayer : Player
    {
        public MockPlayer(IServer server, IntPtr nativePointer, ushort id) : base(server, nativePointer, id)
        {
        }
    }
}