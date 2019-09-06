using System;

namespace AltV.Net.Executable.Example
{
    internal class MyResource : Resource
    {
        public override void OnStart()
        {
            Alt.OnServerEvent += (name, args) => { Alt.Log(name + " " + args.Length); };
            Alt.Emit("test");

            Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            Console.WriteLine("Stopped");
        }
    }
}