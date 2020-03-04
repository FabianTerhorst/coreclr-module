using System;
using AltV.Net.Client;

namespace AltV.Net.WebAssembly.Example
{
    public class Program
    {
        public static void Main(object alt, object natives)
        {
            Alt.Init(alt, natives);
            Alt.Log($"Hello World, Im a message from C# and this message generated at {DateTime.Now}");
            Alt.OnConnectionComplete += () => { Alt.Log("on connection completed"); };
            Alt.OnDisconnect += () => { Alt.Log("on disconnect"); };
            Alt.OnServer("test", args => { Alt.Log("test event triggered"); });
            Alt.On("test14", (args) => { Alt.Log("event fired"); });
            Alt.On("test15", (args) =>
            {
                Alt.Log("event fired");
                foreach (var arg in args)
                {
                    Alt.Log(arg.ToString());
                }
            });
            Alt.Emit("test14");
            Alt.Emit("test15", "bla", "bla2");
            Alt.EveryTick += () =>
            {
                Alt.Natives.DrawRect(0.42478, 0, 0.1, 0.1, 0, 140, 183, 175);
                Alt.Natives.DrawRect(0.5, 0, 0.05, 0.1, 0, 0, 0, 175);
                Alt.Natives.DrawRect(0.575, 0, 0.1, 0.1, 0, 152, 0, 175);

                Alt.Natives.DrawRect(0.846, 0.30, 0.06, 0.035, 0, 0, 0, 175);
                Alt.Natives.DrawRect(0.9105, 0.30, 0.06, 0.035, 0, 0, 0, 175);
                Alt.Natives.DrawRect(0.975, 0.30, 0.06, 0.035, 0, 0, 0, 175);
            };
            Alt.On("connectionComplete", (args) =>
            {
                Alt.Log("connectionComplete");
            });
            Alt.On("disconnect", (args) =>
            {
                Alt.Log("disconnect");
            });
        }
    }
}