using System;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Chat
{
    public class Chat : Resource
    {
        private static Action<string, Action<IPlayer, string, string[]>> registerCmd;

        public override void OnStart()
        {
            Alt.On<IPlayer, string>("chatmessage", OnChatMessage, OnChatMessageParser);

            registerCmd = delegate(string s, Action<IPlayer, string, string[]> action)
            {
                CommandHandlers.Add(s, action);
            };

            Alt.Export<string, Action<IPlayer, string, string[]>>("registerCmd", CommandHandlers.Add);
            Alt.Export("broadcast", delegate(string message) { ChatUtils.SendBroadcastChatMessage(message); });
            Alt.Export("send", delegate(IPlayer player, string message) { player.SendChatMessage(message); });
        }

        public override void OnStop()
        {
        }

        private void OnChatMessage(IPlayer player, string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            if (message.StartsWith("/"))
            {
                message = message.Trim().Remove(0, 1);
                if (message.Length > 0)
                {
                    Alt.Log("[chat:cmd] " + player.Name + ": /" + message);
                    var args = message.Split(' ');
                    var cmd = args[0];
                    CommandHandlers.InvokeCmd(player, cmd, args.Skip(1).ToArray());
                }
            }
            else
            {
                message = message.Trim();
                if (message.Length > 0)
                {
                    Alt.Log("[chat:msg] " + player.Name + ": " + message);

                    player.Emit("chatmessage", player.Name, message);
                }
            }
        }

        private void OnChatMessageParser(IPlayer player, ref MValueArray mValueArray,
            Action<IPlayer, string> func)
        {
            if (mValueArray.Size != 1) return;
            var reader = mValueArray.Reader();
            if (!reader.GetNext(out string message)) return;
            /*if (!reader.GetNext(out MValueArray mValueArgs)) return;
            var argsCount = (int) mValueArgs.Size;
            var args = new string[argsCount];
            var argsReader = mValueArgs.Reader();
            for (var i = 0; i < argsCount; i++)
            {
                if (!argsReader.GetNext(out string currArg)) return;
                args[i] = currArg;
            }*/

            func(player, message);
        }

        ~Chat()
        {
            Console.WriteLine("chat deinit");
        }
    }
}