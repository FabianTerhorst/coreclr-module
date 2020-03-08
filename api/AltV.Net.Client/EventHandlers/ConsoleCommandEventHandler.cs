using System;
using AltV.Net.Client.Events;
using Array = WebAssembly.Core.Array;

namespace AltV.Net.Client.EventHandlers
{
    internal class ConsoleCommandEventHandler : NativeEventHandler<NativeConsoleCommandEventDelegate, ConsoleCommandEventDelegate>
    {
        private readonly NativeConsoleCommandEventDelegate nativeConsoleCommandEventDelegate;

        public ConsoleCommandEventHandler()
        {
            nativeConsoleCommandEventDelegate = new NativeConsoleCommandEventDelegate(OnConsoleCommand);
        }

        private void OnConsoleCommand(string name, Array nativeArgs)
        {
            try
            {
                var length = nativeArgs.Length;
                var args = new string[length];
                for (var i = 0; i < length; i++)
                {
                    args[i] = (string) nativeArgs[i];
                }
                var scriptEventHandler = EventHandlers.First;
                while (scriptEventHandler != null)
                {
                    scriptEventHandler.Value(name, args);
                    scriptEventHandler = scriptEventHandler.Next;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception in ConsoleCommandEventHandler:" + exception);
            }
        }

        public override NativeConsoleCommandEventDelegate GetNativeEventHandler()
        {
            return nativeConsoleCommandEventDelegate;
        }
    }
}