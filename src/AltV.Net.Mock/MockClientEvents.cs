using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public static class MockClientEvents
    {
        public delegate void ClientAnyEventMockDelegate(string eventName, object[] args);

        public delegate void ClientEventMockDelegate(object[] args);

        public class ClientEvent
        {
            public readonly string Name;

            public readonly object[] Args;

            public ClientEvent(string name, object[] args)
            {
                Name = name;
                Args = args;
            }
        }

        private static readonly Dictionary<IntPtr, Queue<ClientEvent>> ClientEvents =
            new Dictionary<IntPtr, Queue<ClientEvent>>();

        private static readonly Dictionary<IntPtr, Dictionary<string, ClientEventMockDelegate>> PlayerEvents =
            new Dictionary<IntPtr, Dictionary<string, ClientEventMockDelegate>>();

        private static readonly Dictionary<IntPtr, List<ClientAnyEventMockDelegate>> PlayerAnyEvents =
            new Dictionary<IntPtr, List<ClientAnyEventMockDelegate>>();

        public static ClientEvent DequeueEvent(this IPlayer player)
        {
            return ClientEvents.TryGetValue(player.NativePointer, out var events) ? events.Dequeue() : null;
        }

        internal static void PushEvent(this IPlayer player, string eventName, object[] args)
        {
            if (!ClientEvents.TryGetValue(player.NativePointer, out _))
            {
                ClientEvents.Add(player.NativePointer, new Queue<ClientEvent>());
            }

            ClientEvents[player.NativePointer].Enqueue(new ClientEvent(eventName, args));
        }

        internal static void PushEvent(this IPlayer player, string eventName, MValue[] args)
        {
            var obj = new object[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                obj[i] = args[i].ToObject();
            }

            player.PushEvent(eventName, obj);
            if (PlayerEvents.TryGetValue(player.NativePointer, out var eventMockDelegates))
            {
                if (eventMockDelegates.TryGetValue(eventName, out var @delegate))
                {
                    @delegate(obj);
                }
            }

            if (PlayerAnyEvents.TryGetValue(player.NativePointer, out var anyEventMockDelegates))
            {
                foreach (var @delegate in anyEventMockDelegates)
                {
                    @delegate(eventName, obj);
                }
            }
        }

        public static void On(this IPlayer player, string eventName, ClientEventMockDelegate clientEventMockDelegate)
        {
            if (!PlayerEvents.TryGetValue(player.NativePointer, out var eventMockDelegates))
            {
                PlayerEvents[player.NativePointer] = new Dictionary<string, ClientEventMockDelegate>();
            }

            PlayerEvents[player.NativePointer][eventName] = clientEventMockDelegate;
        }

        public static void On(this IPlayer player, ClientAnyEventMockDelegate clientEventMockDelegate)
        {
            if (!PlayerAnyEvents.TryGetValue(player.NativePointer, out var eventMockDelegates))
            {
                PlayerAnyEvents[player.NativePointer] = new List<ClientAnyEventMockDelegate>();
            }

            PlayerAnyEvents[player.NativePointer].Add(clientEventMockDelegate);
        }
    }
}