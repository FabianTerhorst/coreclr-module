using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class MyPlayer : Player, IMyPlayer
    {
        public int MyData { get; set; }

        public MyPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            MyData = 6;
        }
    }
}