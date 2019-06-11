using System;
using System.Collections.Generic;
using System.Threading;
using AltV.Net.NetworkingEntity;
using Entity;

namespace AltV.Net.Networking.Example
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //AltNetworking.Init() is enough for most projects
            AltNetworking.Init(new NetworkingModuleBuilder()
                .SetPort(46429)
                .SetAuthenticationProviderFactory(new NonePlayerAuthenticationProviderFactory())
                .Build()
            );

            var data = new Dictionary<string, object>();
            var data2 = new Dictionary<string, object>();
            data["bla"] = "123";
            data["bla2"] = 1235;
            var entityToUpdate = AltNetworking.CreateEntity(new Position {X = 0, Y = 0, Z = 0}, 1, 50, data);
            AltNetworking.CreateEntity(new Position {X = 1, Y = 1, Z = 1}, 1, 50, data2);
            AltNetworking.OnEntityStreamIn = (entity, client) =>
            {
                Console.WriteLine("streamed in " + entity.Id + " in client " + client.Token);
            };
            AltNetworking.OnEntityStreamOut = (entity, client) =>
            {
                Console.WriteLine("streamed out " + entity.Id + " in client " + client.Token);
            };

            var random = new Random();

            int i = 0;

            while (true)
            {
                if (random.Next() % 2 == 0)
                {
                    entityToUpdate.SetData("myData", 1);
                }
                else
                {
                    entityToUpdate.SetDataNull("myData");
                }

                Thread.Sleep(2000);
                i++;
                if (i == 3)
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}