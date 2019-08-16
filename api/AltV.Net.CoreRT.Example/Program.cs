using System;

namespace AltV.Net.CoreRT.Example
{
    class Program
    {
        class MyResource : Resource
        {
            public override void OnStart()
            {
                Alt.OnServerEvent += (name, args) =>
                {
                    Alt.Log(name + " " + args.Length);
                };
                Alt.Emit("test");
            }

            public override void OnStop()
            {
            }
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");

            //new ResourceBuilder(args, new MyResource()).Start();
        }
    }
}