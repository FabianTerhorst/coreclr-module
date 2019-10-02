using System.Collections.Generic;
using AltV.Net.FunctionParser;

namespace AltV.Net.Resources.Chat.Api
{
    public class ChatModule : IModule
    {
        private static readonly LinkedList<Function> Functions = new LinkedList<Function>();

        public void OnScriptsStarted(IScript[] scripts)
        {
            var chat = new Chat();
            AltChat.Init(chat);
            foreach (var script in scripts)
            {
                RegisterEvents(script, chat);
            }
        }

        private static void RegisterEvents(object target, Chat chat)
        {
            ModuleScriptMethodIndexer.Index(target, new[] {typeof(Command)},
                (baseEvent, eventMethod, eventMethodDelegate) =>
                {
                    if (!(baseEvent is Command command)) return;
                    var commandName = command.Name ?? eventMethod.Name;
                    var function = Function.Create(eventMethodDelegate);
                    Functions.AddLast(function);
                    chat.RegisterCommand(commandName,
                        (player, chatCommandName, chatCommandArguments) =>
                        {
                            function.InvokeNoResult(function.CalculateStringInvokeValues(chatCommandArguments, player));
                        });
                });
        }
    }
}