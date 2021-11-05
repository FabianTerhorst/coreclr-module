using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using AltV.Net.Elements.Entities;
using AltV.Net.Async.CodeGen;
using AltV.Net.Data;

namespace AltV.Net.Example
{
    public partial interface IMyAutoAsyncPlayer : IPlayer
    {
        int MyData { get; set; }
        int CalculateOtherData();
        bool GetSomethingToOut([MaybeNullWhen(false)] out string data);
        void GetSomethingToRef(ref int data);
        int TakeSomethingToIn(in int data);
        new void Spawn(Position position, uint delayMs = 0);
    }

    [AsyncEntity(typeof(IMyAutoAsyncPlayer))]
    public partial class MyAutoAsyncPlayer : Player, IMyAutoAsyncPlayer
    {
        public int MyData { get; set; }

        public int CalculateOtherData()
        {
            return MyData * 2;
        }

        public bool GetSomethingToOut([MaybeNullWhen(false)] out string data)
        {
            if (MyData > 5)
            {
                data = "something";
                return true;
            }

            data = default;
            return false;
        }

        public void GetSomethingToRef(ref int data)
        {
            data *= 5;
        }

        public int TakeSomethingToIn(in int data)
        {
            return data * 5;
        }

        // example of base class member hiding support via the new keyword
        public new void Spawn(Position position, uint delayMs = 0)
        {
            Alt.Log("Spawned! " + position);
            base.Spawn(position, delayMs);
        }

        public MyAutoAsyncPlayer(IServer server, IntPtr nativePointer, ushort id) : base(server, nativePointer, id)
        {
            MyData = 6;
        }
    }
}