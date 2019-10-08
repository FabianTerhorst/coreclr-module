using System.Collections.Generic;
using System.Runtime.InteropServices;
using AltV.Net.FunctionParser;

namespace AltV.Net.Resources.Chat.Api
{
    public class ChatModule : IModule
    {
        private static readonly LinkedList<Function> Functions = new LinkedList<Function>();

        private static readonly LinkedList<GCHandle> Handles = new LinkedList<GCHandle>();

        public void OnScriptsStarted(IScript[] scripts)
        {
            var chat = new Chat();
            AltChat.Init(chat);
            foreach (var script in scripts)
            {
                RegisterEvents(script, chat);
            }
        }

        public void OnStop()
        {
            Functions.Clear();
            AltChat.Chat.Dispose();
            foreach (var handle in Handles)
            {
                handle.Free();
            }
            Handles.Clear();
        }

        private static void RegisterEvents(object target, Chat chat)
        {
            ModuleScriptMethodIndexer.Index(target, new[] {typeof(Command)},
                (baseEvent, eventMethod, eventMethodDelegate) =>
                {
                    if (!(baseEvent is Command command)) return;
                    var commandName = command.Name ?? eventMethod.Name;
                    Handles.AddLast(GCHandle.Alloc(eventMethodDelegate));
                    var function = Function.Create(eventMethodDelegate);
                    Functions.AddLast(function);
                    chat.RegisterCommand(commandName,
                        (player, arguments) =>
                        {
                            function.InvokeNoResult(function.CalculateStringInvokeValues(arguments, player));
                        });
                });
        }
    }
}