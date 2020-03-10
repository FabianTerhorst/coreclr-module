using System;
using AltV.Net.Client;
using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.WebAssembly.Example
{
    public class Program
    {
        public static void Main(object alt, object natives, object player, object localStorageObj, object handlingDataObj)
        {
            Alt.Init(alt, natives, player, localStorageObj, handlingDataObj);
            Alt.Log($"Hello World, Im a message from C# and this message generated at {DateTime.Now}");
            Alt.OnConnectionComplete += () => { Alt.Log("on connection completed"); };
            Alt.OnDisconnect += () => { Alt.Log("on disconnect"); };
            Alt.OnServer("test", args => { Alt.Log("test event triggered"); });
            Alt.On("test14", (args) => { Alt.Log("event fired"); });
            Alt.On("test15", (args) =>
            {
                Alt.Log("event fired start");
                if (args != null)
                {
                    foreach (var arg in args)
                    {
                        Alt.Log(arg?.ToString());
                    }
                }

                Alt.Log("event fired end");
            });
            Alt.Emit("test14");
            Alt.Emit("test15", "bla", "bla2");
            Alt.OnEveryTick += () =>
            {
                Alt.Natives.DrawRect(0.42478, 0, 0.1, 0.1, 0, 140, 183, 175, false);
                Alt.Natives.DrawRect(0.5, 0, 0.05, 0.1, 0, 0, 0, 175, false);
                Alt.Natives.DrawRect(0.575, 0, 0.1, 0.1, 0, 152, 0, 175, false);

                Alt.Natives.DrawRect(0.846, 0.30, 0.06, 0.035, 0, 0, 0, 175, false);
                Alt.Natives.DrawRect(0.9105, 0.30, 0.06, 0.035, 0, 0, 0, 175, false);
                Alt.Natives.DrawRect(0.975, 0.30, 0.06, 0.035, 0, 0, 0, 175, false);
            };

            var localStorage = LocalStorage.Get();
            localStorage.Set("bla", "123");
            Console.WriteLine(localStorage.Get("bla"));
            localStorage.Save();

            var localPlayer = Player.Local();
            Console.WriteLine(localPlayer.Name);
            Console.WriteLine(localPlayer.Id);
            
            Console.WriteLine(Alt.GetCursorPos().ToString());
            Console.WriteLine(Alt.GetLicenseHash());
            Console.WriteLine(Alt.GetLocale());
            Console.WriteLine(Alt.Hash("dinghy"));
            
            Console.WriteLine(Alt.IsConsoleOpen());
            Console.WriteLine(Alt.IsInSandbox());
            Console.WriteLine(Alt.IsMenuOpen());
            
            Alt.LogError("This is an error");
            Alt.LogWarning("This is a warning");
            
            Alt.SetMsPerGameMinute(100);
            Console.WriteLine(Alt.GetMsPerGameMinute());
            
            Alt.SetStat("STAMINA", 100);
            Console.WriteLine(Alt.GetStat("STAMINA"));
            
            Alt.SetWeatherCycle(new int[]{7, 2}, new int[]{2, 1});

            var obj = HandlingData.GetForModel(0x81794C70);
            
            foreach(var prop in obj.GetType().GetProperties())
            {
                object value=prop.GetValue(obj);
                Console.WriteLine("{0}={1}",prop.Name,value);
            }
        }
    }
}