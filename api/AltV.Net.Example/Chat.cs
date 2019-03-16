using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class Chat
    {
        private readonly Action<string> broadcast;

        private readonly Action<IPlayer, string> send;

        private readonly Action<string, Function> registerCmd;

        public Chat()
        {
            Alt.Import("chat", "broadcast", out broadcast);
            Alt.Import("chat", "send", out send);
            Alt.Import("chat", "registerCmd", out registerCmd);
        }

        public void Broadcast(string message)
        {
            broadcast?.Invoke(message);
        }

        public void Send(IPlayer player, string message)
        {
            send?.Invoke(player, message);
        }

        public void RegisterCommand(string command, Action<IPlayer, string[]> callback)
        {
            registerCmd?.Invoke(command, Function.Create(callback));
        }
    }
}