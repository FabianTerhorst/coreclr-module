using System;
using AltV.Net.Async;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public interface IMyPlayer : IPlayer
    {
        int MyData { get; set; }
    }

    public class MyPlayer : AsyncPlayer, IMyPlayer
    {
        public int MyData { get; set; }

        public MyPlayer(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
        {
            MyData = 6;
        }
    }
}
