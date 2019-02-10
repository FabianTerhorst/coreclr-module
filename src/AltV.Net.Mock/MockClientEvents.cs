using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public static class MockClientEvents
    {
        public class ClientEvent
        {
            public readonly string name;

            public readonly object[] args;

            public ClientEvent(string name, object[] args)
            {
                this.name = name;
                this.args = args;
            }
        }

        private static readonly Dictionary<IntPtr, Queue<ClientEvent>> ClientEvents =
            new Dictionary<IntPtr, Queue<ClientEvent>>();

        public static ClientEvent DequeueEvent(this IPlayer player)
        {
            return ClientEvents.TryGetValue(player.NativePointer, out var events) ? events.Dequeue() : null;
        }

        public static void PushEvent(this IPlayer player, string eventName, object[] args)
        {
            if (!ClientEvents.TryGetValue(player.NativePointer, out _))
            {
                ClientEvents.Add(player.NativePointer, new Queue<ClientEvent>());
            }

            ClientEvents[player.NativePointer].Enqueue(new ClientEvent(eventName, args));
        }

        public static void PushEvent(this IPlayer player, string eventName, MValue[] args)
        {
            var obj = new object[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                obj[i] = args[i].ToObject();
            }

            player.PushEvent(eventName, obj);
        }
    }
}