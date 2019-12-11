using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Resources.Chat.Api
{
    public static class AltChat
    {
        //internal static Chat Chat;

        internal static readonly HashSet<CommandDoesNotExistsDelegate> CommandDoesNotExistsDelegates =
            new HashSet<CommandDoesNotExistsDelegate>();

        public delegate void CommandDoesNotExistsDelegate(IPlayer player, string command);

        public static event CommandDoesNotExistsDelegate OnCommandDoesNotExists
        {
            add => CommandDoesNotExistsDelegates.Add(value);
            remove => CommandDoesNotExistsDelegates.Remove(value);
        }

        public static void SendBroadcast(string message)
        {
            //Chat.Broadcast(message);
            Alt.EmitAllClients("chat:message", null, message);
        }

        /*internal static void Init(Chat chat)
        {
            Chat = chat;
        }*/
    }
}