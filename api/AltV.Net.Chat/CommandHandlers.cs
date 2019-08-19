using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Chat
{
    public static class CommandHandlers
    {
        private static readonly IDictionary<string, HashSet<Action<IPlayer, string, string[]>>> commandHandlers =
            new Dictionary<string, HashSet<Action<IPlayer, string, string[]>>>();

        public static void Add(string command, Action<IPlayer, string, string[]> handler)
        {
            if (!commandHandlers.TryGetValue(command, out var handlers))
            {
                handlers = new HashSet<Action<IPlayer, string, string[]>>();
                commandHandlers[command] = handlers;
            }

            handlers.Add(handler);
        }
        
        public static void InvokeCommand(IPlayer player, string cmd, string[] args)
        {
            if (!commandHandlers.TryGetValue(cmd, out var handlers))
            {
                player.SendChatMessage("{FF0000} Unknown command /" + cmd + "");
                return;
            }

            foreach (var handler in handlers)
            {
                handler(player, cmd, args);
            }
        }
    }
}