using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.FunctionParser;

namespace AltV.Net.Resources.Chat.Api
{
    public class ChatModule : IModule
    {
        private delegate void CommandDelegate(IPlayer player, string[] arguments);

        private static readonly LinkedList<Function> Functions = new LinkedList<Function>();

        private static readonly LinkedList<GCHandle> Handles = new LinkedList<GCHandle>();

        private readonly IDictionary<string, LinkedList<CommandDelegate>> commandDelegates =
            new Dictionary<string, LinkedList<CommandDelegate>>();

        private static readonly string[] EmptyArgs = new string[0];

        public void OnScriptsStarted(IScript[] scripts)
        {
            //var chat = new Chat();
            //AltChat.Init(chat);
            foreach (var script in scripts)
            {
                RegisterEvents(script /*, chat*/);
            }

            Alt.OnClient<IPlayer, string>("chat:message", OnChatMessage, OnChatMessageParser);
            //Alt.OnServer<IPlayer, string>("chat:message", OnChatMessage, OnChatMessageParserServer);
        }

        private static void OnChatMessageParser(IPlayer player, MValueConst[] mValueArray,
            Action<IPlayer, string> action)
        {
            if (mValueArray.Length != 1) return;
            var arg = mValueArray[0];
            if (arg.type != MValueConst.Type.STRING) return;
            action(player, arg.GetString());
        }

        /*private static void OnChatMessageParserServer(MValueConst[] mValueArray, Action<IPlayer, string> action)
        {
            if (mValueArray.Length != 1) return;
            var argMsg = mValueArray[0];
            if (argMsg.type != MValueConst.Type.STRING) return;
            action(null, argMsg.GetString());
        }*/

        private void OnChatMessage(IPlayer player, string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            if (!message.StartsWith("/")) return;
            message = message.Trim().Remove(0, 1);
            if (message.Length > 0)
            {
                var args = message.Split(' ');
                var argsLength = args.Length;
                if (argsLength < 1) return;
                var cmd = args[0];
                LinkedList<CommandDelegate> delegates;
                if (argsLength < 2)
                {
                    if (commandDelegates.TryGetValue(cmd, out delegates) && delegates.Count > 0)
                    {
                        foreach (var commandDelegate in delegates)
                        {
                            commandDelegate(player, EmptyArgs);
                        }
                    }
                    else
                    {
                        foreach (var doesNotExistsDelegate in AltChat.CommandDoesNotExistsDelegates)
                        {
                            doesNotExistsDelegate(player, cmd);
                        }
                    }

                    return;
                }

                var argsArray = new string[argsLength - 1];
                Array.Copy(args, 1, argsArray, 0, argsLength - 1);
                if (commandDelegates.TryGetValue(cmd, out delegates) && delegates.Count > 0)
                {
                    foreach (var commandDelegate in delegates)
                    {
                        commandDelegate(player, argsArray);
                    }
                }
                else
                {
                    foreach (var doesNotExistsDelegate in AltChat.CommandDoesNotExistsDelegates)
                    {
                        doesNotExistsDelegate(player, cmd);
                    }
                }
            }
        }

        public void OnStop()
        {
            Functions.Clear();
            //AltChat.Chat.Dispose();
            foreach (var handle in Handles)
            {
                handle.Free();
            }

            Handles.Clear();
        }

        private void RegisterEvents(object target /*, Chat chat*/)
        {
            ModuleScriptMethodIndexer.Index(target, new[] {typeof(Command), typeof(CommandEvent)},
                (baseEvent, eventMethod, eventMethodDelegate) =>
                {
                    if (baseEvent is Command command)
                    {
                        var commandName = command.Name ?? eventMethod.Name;
                        Handles.AddLast(GCHandle.Alloc(eventMethodDelegate));
                        var function = Function.Create(eventMethodDelegate);
                        if (function == null)
                        {
                            Alt.Log("Unsupported Command method: " + eventMethod);
                            return;
                        }

                        Functions.AddLast(function);
                        /*chat.RegisterCommand(commandName,
                            (player, arguments) =>
                            {
                                function.InvokeNoResult(function.CalculateStringInvokeValues(arguments, player));
                            });*/
                        LinkedList<CommandDelegate> delegates;
                        if (!commandDelegates.TryGetValue(commandName, out delegates))
                        {
                            delegates = new LinkedList<CommandDelegate>();
                            commandDelegates[commandName] = delegates;
                        }

                        if (command.GreedyArg)
                        {
                            delegates.AddLast((player, arguments) =>
                            {
                                var args = function.CalculateStringInvokeValues(new[] {string.Join(" ", arguments)},
                                    player);
                                if (args == null) return;
                                function.InvokeNoResult(args);
                            });
                        }
                        else
                        {
                            delegates.AddLast((player, arguments) =>
                            {
                                //var args = function.CalculateStringInvokeValues(arguments, player);
                                //if (args == null) return;
                                function.Call(arguments, player);
                            });
                        }

                        var aliases = command.Aliases;
                        if (aliases != null)
                        {
                            foreach (var alias in aliases)
                            {
                                if (!commandDelegates.TryGetValue(alias, out delegates))
                                {
                                    delegates = new LinkedList<CommandDelegate>();
                                    commandDelegates[alias] = delegates;
                                }

                                if (command.GreedyArg)
                                {
                                    delegates.AddLast((player, arguments) =>
                                    {
                                        var args = function.CalculateStringInvokeValues(
                                            new[] {string.Join(" ", arguments)},
                                            player);
                                        if (args == null) return;
                                        function.InvokeNoResult(args);
                                    });
                                }
                                else
                                {
                                    delegates.AddLast((player, arguments) =>
                                    {
                                        var args = function.CalculateStringInvokeValues(arguments, player);
                                        if (args == null) return;
                                        function.InvokeNoResult(args);
                                    });
                                }
                            }
                        }
                    }
                    else if (baseEvent is CommandEvent commandEvent)
                    {
                        var commandEventType = commandEvent.EventType;
                        ScriptFunction scriptFunction;
                        switch (commandEventType)
                        {
                            case CommandEventType.CommandNotFound:
                                scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                    new[] {typeof(IPlayer), typeof(string)});
                                if (scriptFunction == null) return;
                                AltChat.OnCommandDoesNotExists += (player, commandName) =>
                                {
                                    scriptFunction.Set(player);
                                    scriptFunction.Set(commandName);
                                    scriptFunction.Call();
                                };
                                break;
                        }
                    }
                });
        }
    }
}