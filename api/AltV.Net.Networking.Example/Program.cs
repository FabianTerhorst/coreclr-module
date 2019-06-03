using System;
using System.Collections.Generic;
using AltV.Net.NetworkingEntity;
using AltV.Net.NetworkingEntity.Elements.Factories;
using AltV.Net.NetworkingEntity.Elements.Providers;
using Entity;

namespace AltV.Net.Networking.Example
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            AltNetworking.Init(new NetworkingModule(new IdProvider(), new NetworkingEntityFactory(),
                new ClientTokenProvider(), new NetworkingClientFactory(),
                new NonePlayerAuthenticationProviderFactory()));
            var data = new Dictionary<string, object>();
            AltNetworking.CreateEntity(new Position {X = 0, Y = 0, Z = 0}, 1, 50, data);
            Console.ReadKey();
        }
    }
}